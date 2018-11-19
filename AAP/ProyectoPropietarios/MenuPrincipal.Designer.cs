namespace ProyectoPropietarios
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarEntradaEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darDeBajaClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarDeEstadoVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeSGEIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelUSER = new System.Windows.Forms.Label();
            this.moduloDeAdministraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarServiciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empleadosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.moduloDeAdministraciónToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(17, 6, 0, 6);
            this.menuStrip1.Size = new System.Drawing.Size(825, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarToolStripMenuItem,
            this.consultarToolStripMenuItem,
            this.actualizarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.registrarEntradaEmpleadoToolStripMenuItem});
            this.empleadosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(152, 21);
            this.empleadosToolStripMenuItem.Text = "Módulo de Empleado";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // ingresarToolStripMenuItem
            // 
            this.ingresarToolStripMenuItem.Name = "ingresarToolStripMenuItem";
            this.ingresarToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.ingresarToolStripMenuItem.Text = "Registrar Empleado";
            this.ingresarToolStripMenuItem.Click += new System.EventHandler(this.ingresarToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.consultarToolStripMenuItem.Text = "Consultar Empleado";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.actualizarToolStripMenuItem.Text = "Modificar Empleado";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.eliminarToolStripMenuItem.Text = "Actualizar Estado Empleado";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // registrarEntradaEmpleadoToolStripMenuItem
            // 
            this.registrarEntradaEmpleadoToolStripMenuItem.Name = "registrarEntradaEmpleadoToolStripMenuItem";
            this.registrarEntradaEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.registrarEntradaEmpleadoToolStripMenuItem.Text = "Registrar Asistencia Empleado";
            this.registrarEntradaEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.registrarEntradaEmpleadoToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarClienteToolStripMenuItem,
            this.consultarClienteToolStripMenuItem,
            this.editarClienteToolStripMenuItem,
            this.darDeBajaClienteToolStripMenuItem});
            this.clientesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(134, 21);
            this.clientesToolStripMenuItem.Text = "Módulo de Cliente";
            // 
            // agregarClienteToolStripMenuItem
            // 
            this.agregarClienteToolStripMenuItem.Name = "agregarClienteToolStripMenuItem";
            this.agregarClienteToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.agregarClienteToolStripMenuItem.Text = "Registrar Cliente";
            this.agregarClienteToolStripMenuItem.Click += new System.EventHandler(this.agregarClienteToolStripMenuItem_Click);
            // 
            // consultarClienteToolStripMenuItem
            // 
            this.consultarClienteToolStripMenuItem.Name = "consultarClienteToolStripMenuItem";
            this.consultarClienteToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.consultarClienteToolStripMenuItem.Text = "Consultar Cliente";
            this.consultarClienteToolStripMenuItem.Click += new System.EventHandler(this.consultarClienteToolStripMenuItem_Click);
            // 
            // editarClienteToolStripMenuItem
            // 
            this.editarClienteToolStripMenuItem.Name = "editarClienteToolStripMenuItem";
            this.editarClienteToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.editarClienteToolStripMenuItem.Text = "Modificar Cliente";
            this.editarClienteToolStripMenuItem.Click += new System.EventHandler(this.editarClienteToolStripMenuItem_Click);
            // 
            // darDeBajaClienteToolStripMenuItem
            // 
            this.darDeBajaClienteToolStripMenuItem.Name = "darDeBajaClienteToolStripMenuItem";
            this.darDeBajaClienteToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.darDeBajaClienteToolStripMenuItem.Text = "Actualizar Estado Cliente";
            this.darDeBajaClienteToolStripMenuItem.Click += new System.EventHandler(this.darDeBajaClienteToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarVentaToolStripMenuItem,
            this.consultarVentaToolStripMenuItem,
            this.modificarVentaToolStripMenuItem,
            this.cambiarDeEstadoVentaToolStripMenuItem});
            this.ventasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(126, 21);
            this.ventasToolStripMenuItem.Text = "Módulo de Venta";
            // 
            // registrarVentaToolStripMenuItem
            // 
            this.registrarVentaToolStripMenuItem.Name = "registrarVentaToolStripMenuItem";
            this.registrarVentaToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.registrarVentaToolStripMenuItem.Text = "Registrar Venta";
            this.registrarVentaToolStripMenuItem.Click += new System.EventHandler(this.registrarVentaToolStripMenuItem_Click);
            // 
            // consultarVentaToolStripMenuItem
            // 
            this.consultarVentaToolStripMenuItem.Name = "consultarVentaToolStripMenuItem";
            this.consultarVentaToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.consultarVentaToolStripMenuItem.Text = "Consultar Venta";
            this.consultarVentaToolStripMenuItem.Click += new System.EventHandler(this.consultarVentaToolStripMenuItem_Click);
            // 
            // modificarVentaToolStripMenuItem
            // 
            this.modificarVentaToolStripMenuItem.Name = "modificarVentaToolStripMenuItem";
            this.modificarVentaToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.modificarVentaToolStripMenuItem.Text = "Modificar Venta";
            this.modificarVentaToolStripMenuItem.Click += new System.EventHandler(this.modificarVentaToolStripMenuItem_Click);
            // 
            // cambiarDeEstadoVentaToolStripMenuItem
            // 
            this.cambiarDeEstadoVentaToolStripMenuItem.Name = "cambiarDeEstadoVentaToolStripMenuItem";
            this.cambiarDeEstadoVentaToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.cambiarDeEstadoVentaToolStripMenuItem.Text = "Cambiar de estado una Venta";
            this.cambiarDeEstadoVentaToolStripMenuItem.Click += new System.EventHandler(this.cambiarDeEstadoVentaToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeSGEIToolStripMenuItem,
            this.manualDeUsuarioToolStripMenuItem});
            this.ayudaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // acercaDeSGEIToolStripMenuItem
            // 
            this.acercaDeSGEIToolStripMenuItem.Name = "acercaDeSGEIToolStripMenuItem";
            this.acercaDeSGEIToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.acercaDeSGEIToolStripMenuItem.Text = "Acerca de SGEI";
            this.acercaDeSGEIToolStripMenuItem.Click += new System.EventHandler(this.acercaDeSGEIToolStripMenuItem_Click);
            // 
            // manualDeUsuarioToolStripMenuItem
            // 
            this.manualDeUsuarioToolStripMenuItem.Name = "manualDeUsuarioToolStripMenuItem";
            this.manualDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.manualDeUsuarioToolStripMenuItem.Text = "Manual de Usuario";
            this.manualDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.manualDeUsuarioToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelUSER
            // 
            this.labelUSER.AutoSize = true;
            this.labelUSER.BackColor = System.Drawing.Color.Transparent;
            this.labelUSER.Enabled = false;
            this.labelUSER.Location = new System.Drawing.Point(699, 407);
            this.labelUSER.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUSER.Name = "labelUSER";
            this.labelUSER.Size = new System.Drawing.Size(0, 34);
            this.labelUSER.TabIndex = 3;
            // 
            // moduloDeAdministraciónToolStripMenuItem
            // 
            this.moduloDeAdministraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarServiciosToolStripMenuItem});
            this.moduloDeAdministraciónToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.moduloDeAdministraciónToolStripMenuItem.Name = "moduloDeAdministraciónToolStripMenuItem";
            this.moduloDeAdministraciónToolStripMenuItem.Size = new System.Drawing.Size(185, 21);
            this.moduloDeAdministraciónToolStripMenuItem.Text = "Modulo de Administración";
            // 
            // actualizarServiciosToolStripMenuItem
            // 
            this.actualizarServiciosToolStripMenuItem.Name = "actualizarServiciosToolStripMenuItem";
            this.actualizarServiciosToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.actualizarServiciosToolStripMenuItem.Text = "Actualizar Servicios";
            this.actualizarServiciosToolStripMenuItem.Click += new System.EventHandler(this.actualizarServiciosToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(825, 460);
            this.Controls.Add(this.labelUSER);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Symbol", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SGEI";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darDeBajaClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarEntradaEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarDeEstadoVentaToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label labelUSER;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeSGEIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moduloDeAdministraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarServiciosToolStripMenuItem;
    }
}