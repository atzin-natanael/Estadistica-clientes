namespace Clientes
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            DateInicio1 = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            DateInicio2 = new DateTimePicker();
            DateFin1 = new DateTimePicker();
            DateFin2 = new DateTimePicker();
            Btn_Generar = new Button();
            CB_Almacen = new ComboBox();
            CB_Sucursal = new ComboBox();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(867, 9);
            label1.Name = "label1";
            label1.Size = new Size(173, 25);
            label1.TabIndex = 0;
            label1.Text = "DataSet Clientes";
            // 
            // DateInicio1
            // 
            DateInicio1.Location = new Point(406, 152);
            DateInicio1.Name = "DateInicio1";
            DateInicio1.Size = new Size(412, 31);
            DateInicio1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(517, 98);
            label2.Name = "label2";
            label2.Size = new Size(169, 25);
            label2.TabIndex = 2;
            label2.Text = "Fechas de Inicio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1203, 98);
            label3.Name = "label3";
            label3.Size = new Size(169, 25);
            label3.TabIndex = 3;
            label3.Text = "Fechas de Inicio";
            // 
            // DateInicio2
            // 
            DateInicio2.Location = new Point(1086, 152);
            DateInicio2.Name = "DateInicio2";
            DateInicio2.Size = new Size(412, 31);
            DateInicio2.TabIndex = 4;
            // 
            // DateFin1
            // 
            DateFin1.Location = new Point(406, 235);
            DateFin1.Name = "DateFin1";
            DateFin1.Size = new Size(412, 31);
            DateFin1.TabIndex = 5;
            // 
            // DateFin2
            // 
            DateFin2.Location = new Point(1086, 235);
            DateFin2.Name = "DateFin2";
            DateFin2.Size = new Size(412, 31);
            DateFin2.TabIndex = 6;
            // 
            // Btn_Generar
            // 
            Btn_Generar.BackColor = SystemColors.ActiveCaption;
            Btn_Generar.Cursor = Cursors.Hand;
            Btn_Generar.Location = new Point(867, 356);
            Btn_Generar.Name = "Btn_Generar";
            Btn_Generar.Size = new Size(155, 66);
            Btn_Generar.TabIndex = 7;
            Btn_Generar.Text = "Generar Reporte";
            Btn_Generar.UseVisualStyleBackColor = false;
            Btn_Generar.Click += Btn_Generar_Click;
            // 
            // CB_Almacen
            // 
            CB_Almacen.Cursor = Cursors.Hand;
            CB_Almacen.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Almacen.FormattingEnabled = true;
            CB_Almacen.Location = new Point(406, 32);
            CB_Almacen.Name = "CB_Almacen";
            CB_Almacen.Size = new Size(139, 33);
            CB_Almacen.TabIndex = 8;
            CB_Almacen.SelectedValueChanged += CB_Almacen_SelectedValueChanged;
            // 
            // CB_Sucursal
            // 
            CB_Sucursal.Cursor = Cursors.Hand;
            CB_Sucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Sucursal.FormattingEnabled = true;
            CB_Sucursal.Location = new Point(586, 32);
            CB_Sucursal.Name = "CB_Sucursal";
            CB_Sucursal.Size = new Size(218, 33);
            CB_Sucursal.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1924, 947);
            Controls.Add(CB_Sucursal);
            Controls.Add(CB_Almacen);
            Controls.Add(Btn_Generar);
            Controls.Add(DateFin2);
            Controls.Add(DateFin1);
            Controls.Add(DateInicio2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(DateInicio1);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DataSet Clientes";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker DateInicio1;
        private Label label2;
        private Label label3;
        private DateTimePicker DateInicio2;
        private DateTimePicker DateFin1;
        private DateTimePicker DateFin2;
        private Button Btn_Generar;
        private ComboBox CB_Almacen;
        private ComboBox CB_Sucursal;
        private SaveFileDialog saveFileDialog1;
    }
}