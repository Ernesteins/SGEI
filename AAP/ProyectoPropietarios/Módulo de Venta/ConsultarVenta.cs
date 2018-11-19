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

namespace ProyectoPropietarios.Módulo_Ventas
{
    public partial class ConsultarVenta : Form
    {
        public ConsultarVenta()
        {
            InitializeComponent();
            this.CenterToScreen();
            lectura();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void ConsultarVenta_Load(object sender, EventArgs e)
        {
            lectura();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                textBox1.Enabled = false;
            textBox6.Enabled = true;
            textBox6.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                textBox6.Enabled = false;
                textBox1.Enabled = true;
                textBox1.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("Select * from venta where ruc = '" + textBox6.Text + "'", conexion);
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No existe la venta, verifique el id del cliente");

                    }
                    else
                    {
                        dataGridViewVentas.DataSource = dt;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
                }
                conexion.Close();
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from venta where IDVENTA= '" + textBox1.Text + "'", conexion);
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No existe la venta, verifique el id de la misma");

                    }
                    else
                    {
                        dataGridViewVentas.DataSource = dt;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
                }
                conexion.Close();
            }
        
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
        private void clienteNinja()
        {

            String RUC = null;
            RUC = dataGridViewVentas.CurrentRow.Cells["RUC"].Value.ToString();
            if (RUC != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from cliente where RUC = '" + RUC + "'", conexion);
                    conexion.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Error con la lectura del cliente, por favor revise si el cliente no ha sido eliminado");
                    }

                    else
                    {
                        ninjaGrid.DataSource = dt;
                        textID.Text = ninjaGrid.CurrentRow.Cells[0].Value.ToString();
                        textNombre.Text = ninjaGrid.CurrentRow.Cells[1].Value.ToString();
                        textApellido.Text = ninjaGrid.CurrentRow.Cells[2].Value.ToString();
                        textIDFill.Text = ninjaGrid.CurrentRow.Cells[7].Value.ToString();
                        textTelf.Text = ninjaGrid.CurrentRow.Cells[3].Value.ToString();
                        textEstadoCliente.Text =  ninjaGrid.CurrentRow.Cells[6].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridViewVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textIDVENTA.Text = dataGridViewVentas.CurrentRow.Cells["IDVENTA"].Value.ToString();
            textEstadoVenta.Text = dataGridViewVentas.CurrentRow.Cells["ESTADOVENTA"].Value.ToString();
            try
            {
                SqlCommand query = new SqlCommand("EXECUTE CreacionVenta '" + textIDVENTA.Text + "' ", conexion);
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No existen registros en la venta");
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga del ID de la nueva Venta: " + ex);
            }
            finally
            {
                clienteNinja();
            }
        }
        private void carga()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Execute CreacionVenta '" + textIDVENTA.Text + "'", conexion);
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    dataGridView1.DataSource = null;
                }
                else
                {
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el llenado de la tabla de Detalle \nError: " + ex.ToString());
            }
            finally
            {
                
            }
            conexion.Close();

        }
    }
}
