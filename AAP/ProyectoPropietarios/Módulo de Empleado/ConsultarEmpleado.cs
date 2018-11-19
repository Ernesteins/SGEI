using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace ProyectoPropietarios.Módulo_Empleados
{
    public partial class ConsultarEmpleado : Form
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
        public ConsultarEmpleado()
        {
            InitializeComponent();
            this.CenterToScreen();
            radioButtonApellido.Checked = false;
            radioButtonCedula.Checked = false;
            btnBuscar.Enabled = false;
            textBusquedaApellido.Enabled = false;
            textBusquedaCedula.Enabled = false;
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

            errorProvider1.Clear();
            btnBuscar.Enabled = true;
            if (radioButtonApellido.Checked)
                textBusquedaCedula.Enabled = false;
                textBusquedaApellido.Enabled = true;
                textBusquedaApellido.Text = "";
                textBusquedaCedula.Text = "";
                textBusquedaApellido.Focus();
        

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            btnBuscar.Enabled = true;
            if (radioButtonCedula.Checked)
                textBusquedaApellido.Enabled = false;
                textBusquedaCedula.Enabled = true;
                textBusquedaApellido.Text = "";
                textBusquedaCedula.Text = "";
                textBusquedaCedula.Focus();
        }

      
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            
            
            if (radioButtonApellido.Checked)
            {
                if (textBusquedaApellido.Text == "") { 

                    textBusquedaApellido.Select(0, textBusquedaApellido.Text.Length);
                    errorProvider1.SetError(textBusquedaApellido, "Campo Obligatorio");
                    textBusquedaApellido.Focus();
                }
                else
                {

                    try
                    {

                        SqlCommand cmd = new SqlCommand("Select * from Empleado where apellido_empleado = '" + textBusquedaApellido.Text + "'", conexion);
                        conexion.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count == 0) { 
                          MessageBox.Show("No existe el empleado, verifique el apellido por favor.");
                        textBusquedaApellido.Text = "";
                        textBusquedaApellido.Focus(); 
                            }
                        else
                        {
                         btnBuscar.Enabled = false;
                        textBusquedaCedula.Enabled = false;
                        textBusquedaApellido.Enabled = false;
                        radioButtonApellido.Enabled = false;
                        radioButtonCedula.Enabled = false;
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

            }
            else 
            {
                if (textBusquedaCedula.Text == "")
                {

                    textBusquedaCedula.Select(0, textBusquedaCedula.Text.Length);
                    errorProvider1.SetError(textBusquedaCedula, "Campo Obligatorio");
                    textBusquedaCedula.Focus();
                }
                else { 
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from Empleado where cedula = '" + textBusquedaCedula.Text + "'", conexion);
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No existe el empleado, verifique la cédula  por favor");
                            textBusquedaCedula.Text = "";
                            textBusquedaCedula.Focus();
                        }

                        else
                        {
                            btnBuscar.Enabled = false;
                            textBusquedaCedula.Enabled = false;
                            textBusquedaApellido.Enabled = false;
                            radioButtonApellido.Enabled = false;
                            radioButtonCedula.Enabled = false;
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
            }
            conexion.Close();

        }


            private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            btnBuscar.Enabled = false;
            textBusquedaApellido.Enabled = false;
            textBusquedaCedula.Enabled = false;
            radioButtonApellido.Enabled = true;
            radioButtonCedula.Enabled = true;

            textBusquedaCedula.Text = "";
            textBusquedaApellido.Text = "";
            textBusquedaCedula.Text = "";
            textCedula.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            textCargo.Text = "";
            textTelefonoMovil.Text = "";
            textDireccion.Text = "";
            textEstado.Text = "";
            textSalario.Text = "";
            dataGridView1.DataSource = null;

            if (radioButtonApellido.Checked)
                radioButtonApellido.Checked = false;
            else if (radioButtonCedula.Checked)
                radioButtonCedula.Checked = false;

        }

   
     
        private void textBusquedaApellido_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if ((char.IsNumber(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten letras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if ((char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("No se permiten espacios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }


        }

        private void textBusquedaCedula_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if ((char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("No se permiten espacios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textCedula.Text = dataGridView1.CurrentRow.Cells["cedula"].Value.ToString();
            textNombre.Text= dataGridView1.CurrentRow.Cells["nombre_empleado"].Value.ToString();
            textApellido.Text = dataGridView1.CurrentRow.Cells["apellido_empleado"].Value.ToString();
            textTelefonoMovil.Text = dataGridView1.CurrentRow.Cells["telefonoMovil_empleado"].Value.ToString();
            textDireccion.Text = dataGridView1.CurrentRow.Cells["direccion_empleado"].Value.ToString();
            textCargo.Text = dataGridView1.CurrentRow.Cells["cargo"].Value.ToString();
            textSalario.Text =dataGridView1.CurrentRow.Cells["salario"].Value.ToString();
            textEstado.Text = dataGridView1.CurrentRow.Cells["estado_empleado"].Value.ToString();

        }

        private void ConsultarEmpleado_Load(object sender, EventArgs e)
        {
            lectura();
        }
    }
}
