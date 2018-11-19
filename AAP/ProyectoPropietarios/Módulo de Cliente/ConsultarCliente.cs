using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace ProyectoPropietarios.Módulo_Clientes
{
    public partial class ConsultarCliente : Form
    {
        //SqlConnection conexion = new SqlConnection("server=DESKTOP-T3II60T\\SQLEXPRESS; database=SGEI; integrated security = true");
        public ConsultarCliente()
        {
            InitializeComponent();
            this.CenterToScreen();
            radioButtonApellido.Checked = false;
            radioButtonRUC.Checked = false;
            btnBuscar.Enabled = false;
            textBusquedaApellido.Enabled = false;
            textBusquedaRUC.Enabled = false;
            textBusquedaRUC.MaxLength = 13;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            btnBuscar.Enabled = true;
            if (radioButtonApellido.Checked)
                textBusquedaRUC.Enabled = false;
            textBusquedaApellido.Enabled = true;
            textBusquedaApellido.Text = "";
            textBusquedaRUC.Text = "";
            textBusquedaApellido.Focus();


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            btnBuscar.Enabled = true;
            if (radioButtonRUC.Checked)
                textBusquedaApellido.Enabled = false;
            textBusquedaRUC.Enabled = true;
            textBusquedaApellido.Text = "";
            textBusquedaRUC.Text = "";
            textBusquedaRUC.Focus();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();


            if (radioButtonApellido.Checked)
            {
                if (textBusquedaApellido.Text == "")
                {

                    textBusquedaApellido.Select(0, textBusquedaApellido.Text.Length);
                    errorProvider1.SetError(textBusquedaApellido, "Campo Obligatorio");
                    textBusquedaApellido.Focus();
                }
                else
                {

                    try
                    {

                        SqlCommand cmd = new SqlCommand("Select * from cliente where apellido_cliente = '" + textBusquedaApellido.Text + "'", conexion);
                        conexion.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No existe el cliente, verifique el apellido por favor.");
                            textBusquedaApellido.Text = "";
                            textBusquedaApellido.Focus();
                        }
                        else
                        {
                            btnBuscar.Enabled = false;
                            textBusquedaRUC.Enabled = false;
                            textBusquedaApellido.Enabled = false;
                            radioButtonApellido.Enabled = false;
                            radioButtonRUC.Enabled = false;
                            dataGridView1.DataSource = dt;

                            dataGridView1.Columns[0].HeaderText = "RUC";
                            dataGridView1.Columns[1].HeaderText = "Nombre";
                            dataGridView1.Columns[2].HeaderText = "Apellido";
                            dataGridView1.Columns[3].HeaderText = "Teléfono Móvil";
                            dataGridView1.Columns[4].HeaderText = "Dirección";
                            dataGridView1.Columns[5].HeaderText = "Correo";
                            dataGridView1.Columns[6].HeaderText = "Estado";
                            dataGridView1.Columns[7].HeaderText = "Empresa Representada";

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
                if (textBusquedaRUC.Text == "")
                {

                    textBusquedaRUC.Select(0, textBusquedaRUC.Text.Length);
                    errorProvider1.SetError(textBusquedaRUC, "Campo Obligatorio");
                    textBusquedaRUC.Focus();
                }
                else
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Select * from cliente where RUC = '" + textBusquedaRUC.Text + "'", conexion);
                        conexion.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No existe el cliente, verifique el RUC por favor");
                            textBusquedaRUC.Text = "";
                            textBusquedaRUC.Focus();
                        }

                        else
                        {
                            btnBuscar.Enabled = false;
                            textBusquedaRUC.Enabled = false;
                            textBusquedaApellido.Enabled = false;
                            radioButtonApellido.Enabled = false;
                            radioButtonRUC.Enabled = false;
                            dataGridView1.DataSource = dt;
                            dataGridView1.Columns[0].HeaderText = "RUC";
                            dataGridView1.Columns[1].HeaderText = "Nombre";
                            dataGridView1.Columns[2].HeaderText = "Apellido";
                            dataGridView1.Columns[3].HeaderText = "Teléfono Móvil";
                            dataGridView1.Columns[4].HeaderText = "Dirección";
                            dataGridView1.Columns[5].HeaderText = "Correo";
                            dataGridView1.Columns[6].HeaderText = "Estado";
                            dataGridView1.Columns[7].HeaderText = "Empresa Representada";
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

        private void button2_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            textBusquedaApellido.Enabled = false;
            textBusquedaRUC.Enabled = false;
            radioButtonApellido.Enabled = true;
            radioButtonRUC.Enabled = true;

            textBusquedaRUC.Text = "";
            textBusquedaApellido.Text = "";
           
            textRUC.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            textCorreo.Text = "";
            textMovil.Text = "";
            textDireccion.Text = "";
            textEstado.Text = "";
            textEmpresa.Text = "";
            dataGridView1.DataSource = null;

            if (radioButtonApellido.Checked)
                radioButtonApellido.Checked = false;
            else if (radioButtonRUC.Checked)
                radioButtonRUC.Checked = false;

        }

        private void textBusquedaApellido_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBusquedaRUC_KeyPress(object sender, KeyPressEventArgs e)
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

            textRUC.Text = dataGridView1.CurrentRow.Cells["ruc"].Value.ToString();
            textNombre.Text = dataGridView1.CurrentRow.Cells["nombre_cliente"].Value.ToString();
            textApellido.Text = dataGridView1.CurrentRow.Cells["apellido_cliente"].Value.ToString();
            textMovil.Text = dataGridView1.CurrentRow.Cells["telefonomovil_cliente"].Value.ToString();
            textDireccion.Text = dataGridView1.CurrentRow.Cells["direccion_cliente"].Value.ToString();
            textCorreo.Text = dataGridView1.CurrentRow.Cells["correo_cliente"].Value.ToString();
            textEstado.Text = dataGridView1.CurrentRow.Cells["estado_cliente"].Value.ToString();
            textEmpresa.Text = dataGridView1.CurrentRow.Cells["empresa_cliente"].Value.ToString();

        }

        private void ConsultarCliente_Load(object sender, EventArgs e)
        {
            lectura();
        }
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

        private void textBusquedaApellido_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

