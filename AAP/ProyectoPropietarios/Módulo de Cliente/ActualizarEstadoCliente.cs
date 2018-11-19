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

namespace ProyectoPropietarios.Módulo_Clientes
{
    public partial class DardeBajaCliente : Form
    {
        //SqlConnection conexion = new SqlConnection("server=DESKTOP-T3II60T\\SQLEXPRESS  ; database=SGEI ; integrated security = true");
        public DardeBajaCliente()
        {
            InitializeComponent();
            this.CenterToScreen();
            textBusquedaRUC.MaxLength = 10;
            radioButtonApellido.Checked = false;
            radioButtonRUC.Checked = false;
            btnAceptar.Enabled = false;
            btnBuscar.Enabled = false;
            textBusquedaApellido.Enabled = false;
            textBusquedaRUC.Enabled = false;
            textBusquedaRUC.MaxLength = 13;
            comboBox2.Items.Add("Activo");
            comboBox2.Items.Add("Inactivo");

        }


        private void button3_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                            dataGridView1.Columns[0].HeaderText = "ID Cliente";
                            dataGridView1.Columns[1].HeaderText = "RUC";
                            dataGridView1.Columns[2].HeaderText = "Nombre";
                            dataGridView1.Columns[3].HeaderText = "Apellido";
                            dataGridView1.Columns[4].HeaderText = "Teléfono Móvil";
                            dataGridView1.Columns[5].HeaderText = "Dirección";
                            dataGridView1.Columns[6].HeaderText = "Correo";
                            dataGridView1.Columns[7].HeaderText = "Estado";
                            dataGridView1.Columns[8].HeaderText = "Empresa Representada";
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
                            dataGridView1.Columns[0].HeaderText = "ID Cliente";
                            dataGridView1.Columns[1].HeaderText = "RUC";
                            dataGridView1.Columns[2].HeaderText = "Nombre";
                            dataGridView1.Columns[3].HeaderText = "Apellido";
                            dataGridView1.Columns[4].HeaderText = "Teléfono Móvil";
                            dataGridView1.Columns[5].HeaderText = "Dirección";
                            dataGridView1.Columns[6].HeaderText = "Correo";
                            dataGridView1.Columns[7].HeaderText = "Estado";
                            dataGridView1.Columns[8].HeaderText = "Empresa Representada";
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

        public void limpiar()
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
            textEmpresa.Text = "";
           
            dataGridView1.DataSource = null;
            comboBox2.Enabled = false;
            comboBox2.Text = "";
            btnAceptar.Enabled = false;

            if (radioButtonApellido.Checked)
                radioButtonApellido.Checked = false;
            else if (radioButtonRUC.Checked)
                radioButtonRUC.Checked = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
             String s = comboBox2.SelectedItem.ToString();
           
        
            try
            {
                SqlCommand cmd = new SqlCommand("Update cliente set estado_cliente='"+comboBox2.Text+"' where RUC= '"+ textRUC.Text+"'", conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
                
                if (s == "Activo")
                { 
                    MessageBox.Show("Cliente dado de alta exitosamente.");
                    limpiar();
                }
                else
                { 
                    MessageBox.Show("Cliente dado de baja exitosamente.");
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se actualizo el estado del cliente." + ex.ToString());
            }
            conexion.Close();
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
            String s;
            comboBox2.Enabled = true;
            comboBox2.Focus();
            textRUC.Text = dataGridView1.CurrentRow.Cells["ruc"].Value.ToString();
            textNombre.Text = dataGridView1.CurrentRow.Cells["nombre_cliente"].Value.ToString();
            textApellido.Text = dataGridView1.CurrentRow.Cells["apellido_cliente"].Value.ToString();
            textMovil.Text = dataGridView1.CurrentRow.Cells["telefonomovil_cliente"].Value.ToString();
            textDireccion.Text = dataGridView1.CurrentRow.Cells["direccion_cliente"].Value.ToString();
            textCorreo.Text = dataGridView1.CurrentRow.Cells["correo_cliente"].Value.ToString();
            textEmpresa.Text = dataGridView1.CurrentRow.Cells["empresa_cliente"].Value.ToString();
            s = dataGridView1.CurrentRow.Cells["estado_cliente"].Value.ToString();
            comboBox2.SelectedItem = s;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = true;
            
        }

        private void DardeBajaCliente_Load(object sender, EventArgs e)
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
    }
}
