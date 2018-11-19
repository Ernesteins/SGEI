namespace ProyectoPropietarios.Módulo_Empleados
{
    partial class ConsultarEmpleado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarEmpleado));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBusquedaCedula = new System.Windows.Forms.TextBox();
            this.textBusquedaApellido = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.radioButtonCedula = new System.Windows.Forms.RadioButton();
            this.radioButtonApellido = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textSalario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textEstado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.textCargo = new System.Windows.Forms.TextBox();
            this.textTelefonoMovil = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textCedula = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBusquedaCedula);
            this.groupBox1.Controls.Add(this.textBusquedaApellido);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.radioButtonCedula);
            this.groupBox1.Controls.Add(this.radioButtonApellido);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 160);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
            // 
            // textBusquedaCedula
            // 
            this.textBusquedaCedula.BackColor = System.Drawing.Color.White;
            this.textBusquedaCedula.Enabled = false;
            this.textBusquedaCedula.Location = new System.Drawing.Point(258, 81);
            this.textBusquedaCedula.Name = "textBusquedaCedula";
            this.textBusquedaCedula.Size = new System.Drawing.Size(167, 22);
            this.textBusquedaCedula.TabIndex = 20;
            this.textBusquedaCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBusquedaCedula_KeyPress_1);
            // 
            // textBusquedaApellido
            // 
            this.textBusquedaApellido.BackColor = System.Drawing.Color.White;
            this.textBusquedaApellido.Enabled = false;
            this.textBusquedaApellido.Location = new System.Drawing.Point(258, 38);
            this.textBusquedaApellido.Name = "textBusquedaApellido";
            this.textBusquedaApellido.Size = new System.Drawing.Size(167, 22);
            this.textBusquedaApellido.TabIndex = 18;
            this.textBusquedaApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBusquedaApellido_KeyPress_1);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBuscar.Enabled = false;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnBuscar.Location = new System.Drawing.Point(232, 109);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 33);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // radioButtonCedula
            // 
            this.radioButtonCedula.AutoSize = true;
            this.radioButtonCedula.Location = new System.Drawing.Point(151, 81);
            this.radioButtonCedula.Name = "radioButtonCedula";
            this.radioButtonCedula.Size = new System.Drawing.Size(75, 20);
            this.radioButtonCedula.TabIndex = 19;
            this.radioButtonCedula.Text = "Cédula";
            this.radioButtonCedula.UseVisualStyleBackColor = true;
            this.radioButtonCedula.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonApellido
            // 
            this.radioButtonApellido.AutoSize = true;
            this.radioButtonApellido.Checked = true;
            this.radioButtonApellido.Location = new System.Drawing.Point(151, 38);
            this.radioButtonApellido.Name = "radioButtonApellido";
            this.radioButtonApellido.Size = new System.Drawing.Size(84, 20);
            this.radioButtonApellido.TabIndex = 18;
            this.radioButtonApellido.TabStop = true;
            this.radioButtonApellido.Text = "Apellido";
            this.radioButtonApellido.UseVisualStyleBackColor = true;
            this.radioButtonApellido.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textSalario);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textEstado);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textDireccion);
            this.groupBox2.Controls.Add(this.textCargo);
            this.groupBox2.Controls.Add(this.textTelefonoMovil);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textCedula);
            this.groupBox2.Controls.Add(this.textApellido);
            this.groupBox2.Controls.Add(this.textNombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 206);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Empleado";
            // 
            // textSalario
            // 
            this.textSalario.BackColor = System.Drawing.SystemColors.Control;
            this.textSalario.Enabled = false;
            this.textSalario.Location = new System.Drawing.Point(375, 152);
            this.textSalario.Name = "textSalario";
            this.textSalario.ReadOnly = true;
            this.textSalario.Size = new System.Drawing.Size(126, 22);
            this.textSalario.TabIndex = 65;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 64;
            this.label8.Text = "Sueldo:";
            // 
            // textEstado
            // 
            this.textEstado.BackColor = System.Drawing.SystemColors.Control;
            this.textEstado.Enabled = false;
            this.textEstado.Location = new System.Drawing.Point(375, 110);
            this.textEstado.Name = "textEstado";
            this.textEstado.ReadOnly = true;
            this.textEstado.Size = new System.Drawing.Size(126, 22);
            this.textEstado.TabIndex = 63;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(305, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 62;
            this.label7.Text = "Estado:";
            // 
            // textDireccion
            // 
            this.textDireccion.BackColor = System.Drawing.SystemColors.Control;
            this.textDireccion.Enabled = false;
            this.textDireccion.Location = new System.Drawing.Point(85, 152);
            this.textDireccion.Multiline = true;
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.ReadOnly = true;
            this.textDireccion.Size = new System.Drawing.Size(214, 48);
            this.textDireccion.TabIndex = 61;
            // 
            // textCargo
            // 
            this.textCargo.BackColor = System.Drawing.SystemColors.Control;
            this.textCargo.Enabled = false;
            this.textCargo.Location = new System.Drawing.Point(375, 73);
            this.textCargo.Name = "textCargo";
            this.textCargo.ReadOnly = true;
            this.textCargo.Size = new System.Drawing.Size(126, 22);
            this.textCargo.TabIndex = 59;
            // 
            // textTelefonoMovil
            // 
            this.textTelefonoMovil.BackColor = System.Drawing.SystemColors.Control;
            this.textTelefonoMovil.Enabled = false;
            this.textTelefonoMovil.Location = new System.Drawing.Point(375, 34);
            this.textTelefonoMovil.Name = "textTelefonoMovil";
            this.textTelefonoMovil.ReadOnly = true;
            this.textTelefonoMovil.Size = new System.Drawing.Size(126, 22);
            this.textTelefonoMovil.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 16);
            this.label6.TabIndex = 57;
            this.label6.Text = "Teléfono Móvil:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 56;
            this.label5.Text = "Apellido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 55;
            this.label4.Text = "Cargo:";
            // 
            // textCedula
            // 
            this.textCedula.BackColor = System.Drawing.SystemColors.Control;
            this.textCedula.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textCedula.Enabled = false;
            this.textCedula.Location = new System.Drawing.Point(85, 107);
            this.textCedula.Name = "textCedula";
            this.textCedula.ReadOnly = true;
            this.textCedula.Size = new System.Drawing.Size(126, 22);
            this.textCedula.TabIndex = 42;
            // 
            // textApellido
            // 
            this.textApellido.BackColor = System.Drawing.SystemColors.Control;
            this.textApellido.Enabled = false;
            this.textApellido.Location = new System.Drawing.Point(85, 70);
            this.textApellido.Name = "textApellido";
            this.textApellido.ReadOnly = true;
            this.textApellido.Size = new System.Drawing.Size(126, 22);
            this.textApellido.TabIndex = 41;
            // 
            // textNombre
            // 
            this.textNombre.BackColor = System.Drawing.SystemColors.Control;
            this.textNombre.Enabled = false;
            this.textNombre.Location = new System.Drawing.Point(85, 34);
            this.textNombre.Name = "textNombre";
            this.textNombre.ReadOnly = true;
            this.textNombre.Size = new System.Drawing.Size(126, 22);
            this.textNombre.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Dirección:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Cédula:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Nombre:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnCancelar.Location = new System.Drawing.Point(336, 561);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 33);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnVolver.Location = new System.Drawing.Point(486, 561);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(106, 33);
            this.btnVolver.TabIndex = 30;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(16, 390);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(592, 150);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ConsultarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(639, 624);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsultarEmpleado";
            this.Text = "Consultar Empleado";
            this.Load += new System.EventHandler(this.ConsultarEmpleado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBusquedaCedula;
        private System.Windows.Forms.TextBox textBusquedaApellido;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.RadioButton radioButtonCedula;
        private System.Windows.Forms.RadioButton radioButtonApellido;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textCargo;
        private System.Windows.Forms.TextBox textTelefonoMovil;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCedula;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.TextBox textEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textSalario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}