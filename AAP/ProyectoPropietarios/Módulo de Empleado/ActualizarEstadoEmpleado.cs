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
    public partial class DardeBajaEmpleado : Form
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
        //   SqlConnection conexion = new SqlConnection("server=DESKTOP-T3II60T\\SQLEXPRESS  ; database=SGEI ; integrated security = true");
        public DardeBajaEmpleado()
        {
            InitializeComponent();
            this.CenterToScreen();
            comboBox1.Items.Add("Activo");
            comboBox1.Items.Add("Inactivo");
            textBusquedaCedula.MaxLength = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonApellido.Checked)
                textBusquedaCedula.Enabled = false;
                textBusquedaApellido.Enabled = true;
                textBusquedaApellido.Text = "";
                textBusquedaCedula.Text = "";
                textBusquedaApellido.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCedula.Checked)
                textBusquedaApellido.Enabled = false;
                textBusquedaCedula.Enabled = true;
                textBusquedaApellido.Text = "";
                textBusquedaCedula.Text = "";
                textBusquedaCedula.Focus();
        }

       

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (radioButtonApellido.Checked)
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("Select * from empleado where apellido_empleado = '" + textBusquedaApellido.Text + "'", conexion);
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Empleado no existe");

                    else
                    {
                        comboBox1.Enabled = true;
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].HeaderText = "ID Empleado";
                        dataGridView1.Columns[1].HeaderText = "Cédula";
                        dataGridView1.Columns[2].HeaderText = "Nombre";
                        dataGridView1.Columns[3].HeaderText = "Apellido";
                        dataGridView1.Columns[4].HeaderText = "Teléfono Móvil";
                        dataGridView1.Columns[5].HeaderText = "Dirección";
                        dataGridView1.Columns[6].HeaderText = "Cargo";
                        dataGridView1.Columns[7].HeaderText = "Salario";
                        dataGridView1.Columns[8].HeaderText = "Estado";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
                }

            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from empleado where cedula = '" + textBusquedaCedula.Text + "'", conexion);
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                        MessageBox.Show("Empleado no existe");
                    else
                    {
                        comboBox1.Enabled = true;
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].HeaderText = "ID Empleado";
                        dataGridView1.Columns[1].HeaderText = "Cédula";
                        dataGridView1.Columns[2].HeaderText = "Nombre";
                        dataGridView1.Columns[3].HeaderText = "Apellido";
                        dataGridView1.Columns[4].HeaderText = "Teléfono Móvil";
                        dataGridView1.Columns[5].HeaderText = "Dirección";
                        dataGridView1.Columns[6].HeaderText = "Cargo";
                        dataGridView1.Columns[7].HeaderText = "Salario";
                        dataGridView1.Columns[8].HeaderText = "Estado";
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
                }

            }
            conexion.Close();
        
    }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            textBusquedaApellido.Text = "";
            textBusquedaCedula.Text = "";
            textCedula.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            textCargo.Text = "";
            textTelefono.Text = "";
            textDireccion.Text = "";
            comboBox1.Text = "";
            dataGridView1.DataSource = null;

            if (radioButtonApellido.Checked)
                radioButtonApellido.Checked = false;
            else if (radioButtonCedula.Checked)
                radioButtonCedula.Checked = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
          
            try
            {
                SqlCommand cmd = new SqlCommand("Update Empleado set estado_empleado='"+comboBox1.Text+"' where cedula= '"+ textCedula.Text+"'", conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Estado del empleado actualizado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ingreso el Empleado " + ex.ToString());
            }
            conexion.Close();
        }

       
        private void textBusquedaApellido_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textNombre.Text = dataGridView1.CurrentRow.Cells["nombre_empleado"].Value.ToString();
            textApellido.Text = dataGridView1.CurrentRow.Cells["apellido_empleado"].Value.ToString();
            textTelefono.Text = dataGridView1.CurrentRow.Cells["telefonoMovil_empleado"].Value.ToString();
            textDireccion.Text = dataGridView1.CurrentRow.Cells["direccion_empleado"].Value.ToString();
            textCargo.Text = dataGridView1.CurrentRow.Cells["cargo"].Value.ToString();
            textSueldo.Text = dataGridView1.CurrentRow.Cells["salario"].Value.ToString();
            textCedula.Text = dataGridView1.CurrentRow.Cells["cedula"].Value.ToString();
        }

        private void DardeBajaEmpleado_Load(object sender, EventArgs e)
        {
            lectura();
        }
    }

   
}

