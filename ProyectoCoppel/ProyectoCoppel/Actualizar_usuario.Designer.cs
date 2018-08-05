namespace ProyectoCoppel
{
    partial class Actualizar_usuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.cbClave = new System.Windows.Forms.CheckBox();
            this.cbDatos = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNclave = new System.Windows.Forms.TextBox();
            this.txtRNclave = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpUsuario = new System.Windows.Forms.DateTimePicker();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSAlir = new System.Windows.Forms.Button();
            this.errorP = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clave";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(253, 24);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(253, 59);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(40, 20);
            this.txtClave.TabIndex = 3;
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            // 
            // cbClave
            // 
            this.cbClave.AutoSize = true;
            this.cbClave.Location = new System.Drawing.Point(62, 157);
            this.cbClave.Name = "cbClave";
            this.cbClave.Size = new System.Drawing.Size(103, 17);
            this.cbClave.TabIndex = 5;
            this.cbClave.Text = "cambiar la clave";
            this.cbClave.UseVisualStyleBackColor = true;
            this.cbClave.CheckedChanged += new System.EventHandler(this.cbClave_CheckedChanged);
            // 
            // cbDatos
            // 
            this.cbDatos.AutoSize = true;
            this.cbDatos.Location = new System.Drawing.Point(320, 154);
            this.cbDatos.Name = "cbDatos";
            this.cbDatos.Size = new System.Drawing.Size(163, 17);
            this.cbDatos.TabIndex = 6;
            this.cbDatos.Text = "Cambiar los datos del usuario";
            this.cbDatos.UseVisualStyleBackColor = true;
            this.cbDatos.CheckedChanged += new System.EventHandler(this.cbDatos_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Clave Nueva";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Repita la clave";
            // 
            // txtNclave
            // 
            this.txtNclave.Enabled = false;
            this.txtNclave.Location = new System.Drawing.Point(137, 184);
            this.txtNclave.Name = "txtNclave";
            this.txtNclave.Size = new System.Drawing.Size(38, 20);
            this.txtNclave.TabIndex = 7;
            // 
            // txtRNclave
            // 
            this.txtRNclave.Enabled = false;
            this.txtRNclave.Location = new System.Drawing.Point(137, 219);
            this.txtRNclave.Name = "txtRNclave";
            this.txtRNclave.Size = new System.Drawing.Size(38, 20);
            this.txtRNclave.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(206, 96);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(383, 208);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 10;
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatus.Enabled = false;
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Location = new System.Drawing.Point(383, 275);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(121, 21);
            this.cmbEstatus.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Estatus";
            // 
            // dtpUsuario
            // 
            this.dtpUsuario.CustomFormat = "yyyy/MM/dd";
            this.dtpUsuario.Enabled = false;
            this.dtpUsuario.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUsuario.Location = new System.Drawing.Point(383, 242);
            this.dtpUsuario.Name = "dtpUsuario";
            this.dtpUsuario.Size = new System.Drawing.Size(88, 20);
            this.dtpUsuario.TabIndex = 11;
            this.dtpUsuario.Value = new System.DateTime(2018, 7, 30, 0, 0, 0, 0);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(383, 180);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Fecha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Apellido";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(302, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Nombre";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new System.Drawing.Point(90, 327);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 13;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSAlir
            // 
            this.btnSAlir.Location = new System.Drawing.Point(320, 327);
            this.btnSAlir.Name = "btnSAlir";
            this.btnSAlir.Size = new System.Drawing.Size(75, 23);
            this.btnSAlir.TabIndex = 15;
            this.btnSAlir.Text = "Salir";
            this.btnSAlir.UseVisualStyleBackColor = true;
            this.btnSAlir.Click += new System.EventHandler(this.btnSAlir_Click);
            // 
            // errorP
            // 
            this.errorP.ContainerControl = this;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(206, 327);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Actualizar_usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(532, 402);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSAlir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.cmbEstatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpUsuario);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtRNclave);
            this.Controls.Add(this.txtNclave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbDatos);
            this.Controls.Add(this.cbClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Actualizar_usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.errorP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.CheckBox cbClave;
        private System.Windows.Forms.CheckBox cbDatos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNclave;
        private System.Windows.Forms.TextBox txtRNclave;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpUsuario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSAlir;
        private System.Windows.Forms.ErrorProvider errorP;
        private System.Windows.Forms.Button btnCancelar;
    }
}