using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPropietarios.Módulo_Empleados
{
    public partial class ActualizarEmpleado : Form
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

        public ActualizarEmpleado()
        {
            InitializeComponent();
            this.CenterToScreen();
            radioButtonApellido.Checked = false;
            radioButtonCedula.Checked = false;
            btnBuscar.Enabled = false;
            txtBusquedaApellido.Enabled = false;
            txtBusquedaCedula.Enabled = false;
            txtBusquedaCedula.MaxLength = 10;
            textMovil.MaxLength = 10;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }

        
        private void Editar()
        {
                                 
                try
                {
                    SqlCommand cmd = new SqlCommand("update empleado set telefonomovil_empleado= '" + textMovil.Text + "', direccion_empleado='" + textDireccion.Text + "', cargo = '" + textCargo.Text + "',salario='"+textSueldo.Text+"' where cedula='" + dataGridView1.CurrentRow.Cells["cedula"].Value.ToString() + "'", conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Datos del empleado modificados exitosamente.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error durante la actualización del empleado \nError: " + ex.ToString());
                }

            
            conexion.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            textDireccion.Enabled = true;
            textCargo.Enabled = true;
            textMovil.Enabled = true;
            textSueldo.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            btnBuscar.Enabled = true;
            if (radioButtonApellido.Checked)
            {
                txtBusquedaCedula.Enabled = false;
                txtBusquedaApellido.Enabled = true;
                txtBusquedaApellido.Text = "";
                txtBusquedaCedula.Text = "";
                textNombre.Focus();
                
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            btnBuscar.Enabled = true;
            if (radioButtonCedula.Checked)
            {
                txtBusquedaApellido.Enabled = false;
                txtBusquedaCedula.Enabled = true;
                txtBusquedaApellido.Text = "";
                txtBusquedaCedula.Text = "";
                txtBusquedaCedula.Focus();
                
            }
                
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexion.Close();
            if (radioButtonApellido.Checked)
            {
                if (txtBusquedaApellido.Text == "")
                {

                    txtBusquedaApellido.Select(0, txtBusquedaApellido.Text.Length);
                    errorProvider1.SetError(txtBusquedaApellido, "Campo Obligatorio");
                    txtBusquedaApellido.Focus();
                }
                else {  

                   try
                     {

                    SqlCommand cmd = new SqlCommand("select * from empleado where apellido_empleado = '" + txtBusquedaApellido.Text + "'", conexion);
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No existe el empleado, verifique la el apellido por favor.");
                            txtBusquedaApellido.Text = "";
                            txtBusquedaApellido.Focus();
                        }
                        else
                        {
                            btnBuscar.Enabled = false;
                            txtBusquedaCedula.Enabled = false;
                            txtBusquedaApellido.Enabled = false;
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

                if (txtBusquedaCedula.Text == "")
                {
                    txtBusquedaCedula.Select(0, txtBusquedaCedula.Text.Length);
                    errorProvider1.SetError(txtBusquedaCedula, "Campo Obligatorio");
                    txtBusquedaCedula.Focus();
                }
                else
                {
                    try
                {
                    SqlCommand cmd = new SqlCommand("Select * from empleado where cedula = '" + txtBusquedaCedula.Text + "'", conexion);
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No existe el empleado, verifique la cédula  por favor.");
                            txtBusquedaCedula.Text = "";
                            txtBusquedaCedula.Focus();
                        }
                        else
                        {
                            btnBuscar.Enabled = false;
                            txtBusquedaCedula.Enabled = false;
                            txtBusquedaApellido.Enabled = false;
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
            conexion.Close();
            }
        }

        void limpiar()
        {
            textNombre.Text = "";
            textApellido.Text = "";
            textMovil.Text = "";
            textDireccion.Text = "";
            textCargo.Text = "";
            textSueldo.Text = "";
            txtBusquedaApellido.Text = "";
            txtBusquedaCedula.Text = "";
            textNombre.Enabled = false;
            textApellido.Enabled = false;
            textDireccion.Enabled = false;
            textSueldo.Enabled = false;
            textCargo.Enabled = false;
            textMovil.Enabled = false;
            radioButtonApellido.Enabled = true;
            radioButtonCedula.Enabled = true;
            dataGridView1.DataSource = null;

            if (radioButtonApellido.Checked)
                radioButtonApellido.Checked = false;
            else if (radioButtonCedula.Checked)
                radioButtonCedula.Checked = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            conexion.Close();
            Boolean aprobacion = true;
           
            if (textCargo.Text == "")
            {
                textCargo.Select(0, textCargo.Text.Length);
                errorProvider1.SetError(textCargo, "Campo Obligatorio");
                aprobacion = false;

            }
            if (textMovil.Text == "")
            {
                textMovil.Select(0, textMovil.Text.Length);
                errorProvider1.SetError(textMovil, "Campo Obligatorio");
                aprobacion = false;
            }

            if (textDireccion.Text == "")
            {
                textDireccion.Select(0, textDireccion.Text.Length);
                errorProvider1.SetError(textDireccion, "Campo Obligatorio");
                aprobacion = false;
            }
            if (textSueldo.Text == "")
            {
                textSueldo.Select(0, textSueldo.Text.Length);
                errorProvider1.SetError(textSueldo, "Campo Obligatorio");
                aprobacion = false;
            }

            if (aprobacion)
            {
                Editar();
                limpiar();
            }

            
        }

        private void textBusquedaApellido_KeyPress_1(object sender, KeyPressEventArgs e)
        {


                if ((char.IsNumber(e.KeyChar)))
                {
                    MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
                else if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    MessageBox.Show("No se permiten espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
        }

        private void textBusquedaCedula_KeyPress_1(object sender, KeyPressEventArgs e)
        {
                if ((char.IsLetter(e.KeyChar)))
                {
                    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
                else if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    MessageBox.Show("No se permiten espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
            textNombre.Text = dataGridView1.CurrentRow.Cells["nombre_empleado"].Value.ToString();
            textApellido.Text = dataGridView1.CurrentRow.Cells["apellido_empleado"].Value.ToString();
            textMovil.Text = dataGridView1.CurrentRow.Cells["telefonoMovil_empleado"].Value.ToString();
            textDireccion.Text = dataGridView1.CurrentRow.Cells["direccion_empleado"].Value.ToString();
            textCargo.Text = dataGridView1.CurrentRow.Cells["cargo"].Value.ToString();
            textSueldo.Text = dataGridView1.CurrentRow.Cells["salario"].Value.ToString();
           

        }

        private void textMovil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if ((char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("No se permiten espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if ((char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("No se permiten espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

      
            private void textSueldo_KeyPress(object sender, KeyPressEventArgs e)
            {
                if ((char.IsLetter(e.KeyChar)))
                {
                    MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
                else if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    MessageBox.Show("No se permiten espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }

        private void ActualizarEmpleado_Load(object sender, EventArgs e)
        {
            lectura();            
        }
    }
   }

