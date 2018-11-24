using ProyectoPropietarios.Módulo_de_Administración.Usuarios;
using ProyectoPropietarios.Módulo_de_Venta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPropietarios
{
    public partial class MenuPrincipalA : Form
    {
        public MenuPrincipalA()
        {
            InitializeComponent();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Empleados.DardeBajaEmpleado().Show();
            this.Hide();
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {


            new Módulo_Empleados.IngresarEmpleado().Show();
            this.Hide();

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Empleados.ConsultarEmpleado().Show();
            this.Hide();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Empleados.ActualizarEmpleado().Show();
            this.Hide();
        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_de_Cliente.RegistrarCliente().Show();
            this.Hide();
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Clientes.ConsultarCliente().Show();
            this.Hide();
        }

        private void editarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Clientes.EditarCliente().Show();
            this.Hide();
        }

        private void darDeBajaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Clientes.DardeBajaCliente().Show();
            this.Hide();
        }



        private void registrarEntradaEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Empleados.RegistrarEntradaEmpleado().Show();
            this.Hide();
        }

        private void registrarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Ventas.RegistrarVenta().Show();
            this.Hide();
        }

        private void consultarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Ventas.ConsultarVenta().Show();
            this.Hide();
        }

        private void modificarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ModificarVenta().Show();
            //new Módulo_Ventas.ModificarVenta().Show();
            this.Hide();
        }

        private void cambiarDeEstadoVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Ventas.CambiarEstadoVenta().Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void emitirFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Facturación.EmitirFactura().Show();
            this.Hide();
        }

        private void consultarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Facturación.ConsultarFactura().Show();
            this.Hide();

        }


        private void anularFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Módulo_Facturación.anularFactura().Show();
            this.Hide();

        }




        private void actualizarIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void registrarNombreDeLaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
        }

        private void actualizarDatosPersonalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void actualizarPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeSGEIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe ad = new AcercaDe();
            ad.Show();
            this.Hide();
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "C:\\Users\\Ernesteins\\Desktop\\Manual de Usuario SGEI.pdf";
            proc.Start();
            proc.Close();*/
            AcercaDe ad = new AcercaDe();
            ad.Show();
            this.Hide();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea salir del sistema?", "Saliendo del SGEI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }


        }

        private void actualizarParámetrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void actualizarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ActualizarUsuarios().Show();
            this.Hide();
        }

        private void actualizarServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Módulo_de_Administración.Parámetros.actualizarServicios().Show();
            this.Hide();
        }
    }
}
