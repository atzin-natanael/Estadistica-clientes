using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using FirebirdSql.Data.FirebirdClient;
using SpreadsheetLight;
using System.Diagnostics;
using System.Windows.Forms;

namespace Clientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Config();
            CB_Sucursal.Items.Clear();
            CB_Almacen.Items.Clear();
            CB_Almacen.Items.Add("Tienda");
            CB_Almacen.Items.Add("Surtido");
            CB_Almacen.SelectedIndex = 0;
            CB_Sucursal.Items.Add("Periférico");
            CB_Sucursal.Items.Add("Hidalgo");
            CB_Sucursal.Items.Add("Culiacán");
            SucursalComboBox();

        }
        public void Config()
        {
            string filePath = "C:\\ConfigDB\\DB.txt"; // Ruta de tu archivo de texto
            List<string> lineas = new List<string>();

            // Verificar si el archivo existe
            if (File.Exists(filePath))
            {
                // Leer todas las líneas del archivo
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        GlobalSettings.Instance.Config.Add(linea);
                    }

                }
                GlobalSettings.Instance.Ip = GlobalSettings.Instance.Config[0];
                GlobalSettings.Instance.Puerto = GlobalSettings.Instance.Config[1];
                GlobalSettings.Instance.Direccion = GlobalSettings.Instance.Config[2];
                GlobalSettings.Instance.User = GlobalSettings.Instance.Config[3];
                GlobalSettings.Instance.Pw = GlobalSettings.Instance.Config[4];
            }

        }
        private void SucursalComboBox()
        {
            CB_Sucursal.Items.Clear();
            if (CB_Almacen.SelectedIndex == 1) // Surtido
            {
                CB_Sucursal.Items.Add("Periférico");
                CB_Sucursal.Items.Add("Culiacán");
            }
            else if (CB_Almacen.SelectedIndex == 0) // Tienda
            {
                CB_Sucursal.Items.Add("Periférico");
                CB_Sucursal.Items.Add("Hidalgo");
                CB_Sucursal.Items.Add("Culiacán");
            }
            CB_Sucursal.SelectedIndex = 0;
        }
        private void Btn_Generar_Click(object sender, EventArgs e)
        {
            FbConnection con = new FbConnection("User=" + GlobalSettings.Instance.User + ";" + "Password=" + GlobalSettings.Instance.Pw + ";" + "Database=" + GlobalSettings.Instance.Direccion + ";" + "DataSource=" + GlobalSettings.Instance.Ip + ";" + "Port=" + GlobalSettings.Instance.Puerto + ";" + "Dialect=3;" + "Charset=UTF8;");
            try
            {
                con.Open();
                // Utiliza parámetros para evitar la inyección de SQL
                string almacen_id;
                switch (CB_Sucursal.Text)
                {
                    case "Periférico":
                        almacen_id = "108403";
                        break;
                    case "Hidalgo":
                        almacen_id = "108402";
                        break;
                    case "Culiacán":
                        almacen_id = "108405";
                        break;
                    default:
                        almacen_id = "108403";
                        break;

                }
                string query7;
                switch (CB_Almacen.Text)
                {
                    case "Surtido":
                        query7 = "SELECT DISTINCT DV.CLAVE_CLIENTE, C.NOMBRE, E.EMAIL, DV.FECHA FROM DOCTOS_VE DV JOIN CLIENTES C ON DV.CLIENTE_ID = C.CLIENTE_ID JOIN DIRS_CLIENTES E ON DV.CLIENTE_ID = E.CLIENTE_ID AND E.NOMBRE_CONSIG = 'Dirección principal' WHERE DV.FECHA BETWEEN '" + DateInicio1.Value.ToString("yyyy-MM-dd") + "' AND '" + DateFin1.Value.ToString("yyyy-MM-dd") + "' AND TIPO_DOCTO = 'F' AND ALMACEN_ID = '"+almacen_id+ "' ORDER BY DV.CLAVE_CLIENTE; ";
                        break;
                    case "Tienda":
                        query7 = "SELECT DISTINCT DV.CLAVE_CLIENTE, C.NOMBRE, E.EMAIL, DV.FECHA FROM DOCTOS_PV DV JOIN CLIENTES C ON DV.CLIENTE_ID = C.CLIENTE_ID JOIN DIRS_CLIENTES E ON DV.CLIENTE_ID = E.CLIENTE_ID AND E.NOMBRE_CONSIG = 'Dirección principal' WHERE DV.FECHA BETWEEN '" + DateInicio1.Value.ToString("yyyy-MM-dd") + "' AND '" + DateFin1.Value.ToString("yyyy-MM-dd") + "' AND TIPO_DOCTO = 'V' AND ALMACEN_ID = '" + almacen_id + "' ORDER BY DV.CLAVE_CLIENTE; ";
                        break;
                    default:
                        query7 = "SELECT DISTINCT DV.CLAVE_CLIENTE, C.NOMBRE, E.EMAIL, DV.FECHA FROM DOCTOS_VE DV JOIN CLIENTES C ON DV.CLIENTE_ID = C.CLIENTE_ID JOIN DIRS_CLIENTES E ON DV.CLIENTE_ID = E.CLIENTE_ID AND E.NOMBRE_CONSIG = 'Dirección principal' WHERE DV.FECHA BETWEEN '" + DateInicio1.Value.ToString("yyyy-MM-dd") + "' AND '" + DateFin1.Value.ToString("yyyy-MM-dd") + "' AND TIPO_DOCTO = 'F' AND ALMACEN_ID = '" + almacen_id + "' ORDER BY DV.CLAVE_CLIENTE; ";
                        break;
                }
                //string query7 = "SELECT CLIENTE_ID FROM DOCTOS_VE WHERE FECHA BETWEEN '" + DateInicio1.Value.ToString("dd.MM.yyyy") + "' AND '" + DateFin1.Value.ToString("dd.MM.yyyy") + "' ";
                FbCommand command0 = new FbCommand(query7, con);
                FbDataReader reader0 = command0.ExecuteReader();
                List<List<string>> ResultadoQ1= new List<List<string>>();
                SLDocument sl = new();
                sl.RenameWorksheet("Sheet1","DATASET INICIO");
                int i = 2;
                while (reader0.Read())
                {
                    List<string> list = new List<string>();
                    list.Add(reader0.GetString(0));
                    list.Add(reader0.GetString(1));
                    list.Add(reader0.GetString(2));
                    list.Add(reader0.GetDateTime(3).ToShortDateString());
                    ResultadoQ1.Add(list);
                    sl.SetCellValue("A" + i, list[0]);
                    sl.SetCellValue("B" + i, list[1]);
                    sl.SetCellValue("C" + i, list[2]);
                    sl.SetCellValue("D" + i, list[3]);
                    ++i;
                }

                MessageBox.Show("PRIMERO ASIGNALE UN NOMBRE AL ARCHIVO Y SU UBICACIÓN");
                string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog1.InitialDirectory = desktopFolder;
                saveFileDialog1.Title = "ASIGNAR NOMBRE";
                saveFileDialog1.FileName = "Reporte " + DateTime.Now.ToString("dddd dd-MM-yy");
                saveFileDialog1.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
                saveFileDialog1.DefaultExt = "xlsx";
                saveFileDialog1.AddExtension = true;
                string filePath;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Aquí puedes escribir el código para guardar el archivo en la ubicación seleccionada
                    filePath = saveFileDialog1.FileName;
                }
                else
                    return;
                sl.SetCellValue("A1", "CLAVE");
                sl.SetCellValue("B1", "NOMBRE");
                sl.SetCellValue("C1", "EMAIL");
                sl.SetCellValue("D1", "FECHA");
                int[] columnas = { 1, 2, 3, 4 };
                foreach (int columna in columnas)
                {
                    if (columna == 1)
                        sl.SetColumnWidth(columna, 8);
                    if (columna == 2)
                        sl.SetColumnWidth(columna, 50);
                    if (columna == 3)
                        sl.SetColumnWidth(columna, 50);
                    if (columna == 4)
                        sl.SetColumnWidth(columna, 10);
                }
                int filas = i-1;
                SLTable table = sl.CreateTable("A1", "D"+filas);
                table.SetTableStyle(SLTableStyleTypeValues.Medium9);
                sl.InsertTable(table);             
                sl.SaveAs(filePath);
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se perdió la conexión :( , contacta a 06 o intenta de nuevo", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
                return;
            }

        }

        private void CB_Almacen_SelectedValueChanged(object sender, EventArgs e)
        {
            SucursalComboBox();
        }
    }
}