using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace ProyectoPropietarios.Módulo_Empleados
{
    public partial class RegistrarEntradaEmpleado : Form
    {
        SqlConnection conexion = null;
        public void lectura()
        {
            string[] conexstring = new string[4];
            string ruta_conexion = "C:\\SGEI\\conexion.csv";
            string line = null;
            String pattern = "(#\\.*)";
            try
            {
                StreamReader sr = new StreamReader(ruta_conexion);
                //Read the first line of text
                line = sr.ReadLine();
                if (Regex.IsMatch(line, pattern) && line != null)
                {
                    line = sr.ReadLine();
                }
                while (line != null)
                {
                    string phrase = line;
                    conexstring = phrase.Split(';');
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión a la base de datos: " + ex + "\nPor favor revise el archivo C:\\SGEI\\conexion.csv");
            }
            finally
            { conexion = new SqlConnection("server=" + conexstring[0] + "; database=SGEI; integrated security = true"); }

        }

        String ultimoID = "";
        //SqlConnection conexion = new SqlConnection("server=DESKTOP-T3II60T\\SQLEXPRESS; database=SGEI; integrated security = true");
        public RegistrarEntradaEmpleado()
        {
            InitializeComponent();
            this.CenterToScreen();
            textBusquedaCedula.MaxLength = 10;
            textBusquedaCedula.Focus();
        }


        private void RegistrarEntradaEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void BuscarEmpleadoAsis()
        {
            conexion.Close();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from Asistencia where idempleado = '" + ultimoID + "'", conexion);
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "ID  Asistencia";
                dataGridView1.Columns[1].HeaderText = "ID Empleado";
                dataGridView1.Columns[2].HeaderText = "Fecha Registro";
                dataGridView1.Columns[3].HeaderText = "Hora de Entrada";
                dataGridView1.Columns[4].HeaderText = "Hora de Salida";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
            }
            conexion.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexion.Close();
            try
            {

                SqlCommand cmd = new SqlCommand("Select * from empleado where cedula = '" + textBusquedaCedula.Text + "'", conexion);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() && reader["idempleado"].ToString() != "")
                {
                    btnBuscar.Enabled = false;
                    ultimoID = reader["idempleado"].ToString();
                    textNombre.Text = reader["nombre_empleado"].ToString();
                    textApellido.Text = reader["apellido_empleado"].ToString();
                    BuscarEmpleadoAsis();
                    btnRegistrarE.Enabled = true;
                    btnRegistrarS.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Empleado no registrado");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
            }
            conexion.Close();
           
        }


        private void RegistrarEntrada()
        {
            String fecha;
            String hora;
            fecha = dtp.Value.Date.ToString("yyyy/MM/dd");
            hora = DateTime.Now.TimeOfDay.ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("Insert into Asistencia(fecharegistro,horaentrada,idempleado) values('" + fecha + "','" + hora + "','" + ultimoID + "')", conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Registro de Hora de entrada registrada exitosamente");
                BuscarEmpleadoAsis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
            }
        }

        private void RegistrarSalida()
        {
            String fecha;
            String hora;
            fecha = dtp.Value.Date.ToString("yyyy/MM/dd");
            hora = DateTime.Now.TimeOfDay.ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("Update Asistencia set fecharegistro = '" + fecha + "', horaSalida = '" + hora + "' where idempleado = " + ultimoID, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Empleado Registrado");
                BuscarEmpleadoAsis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarEntrada();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            textBusquedaCedula.Text = "";
            textBusquedaCedula.Focus();
            btnBuscar.Enabled = true;
            textNombre.Text = "";
            textApellido.Text = "";
            dataGridView1.DataSource = null;
            btnRegistrarE.Enabled = false;
            btnRegistrarS.Enabled = false;
        }

        private void btnRegistrarS_Click(object sender, EventArgs e)
        {
            RegistrarSalida();
        }

        private void textBusquedaCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void RegistrarEntradaEmpleado_Load_1(object sender, EventArgs e)
        {
            lectura();
        }
    }
}

