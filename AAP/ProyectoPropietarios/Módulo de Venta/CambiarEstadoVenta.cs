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
    public partial class CambiarEstadoVenta : Form
    {
        public CambiarEstadoVenta()
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                textBox2.Enabled = false;
                textBox6.Enabled = true;
                textBox6.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                textBox6.Enabled = false;
                textBox2.Enabled = true;
                textBox2.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Ventas();
            
        }

        private void Ventas()
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
                        dataGridView1.DataSource = dt;

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
                    SqlCommand cmd = new SqlCommand("Select * from venta where IDVENTA= '" +textBox2.Text+ "'", conexion);
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
                        dataGridView1.DataSource = dt;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
                }
                conexion.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CambiarEstadoVenta_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Habilitada");
            comboBox1.Items.Add("Deshabilitada");
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update venta set estadoventa= '"+comboBox1.SelectedItem.ToString()+"' where idventa = '" + dataGridView1.CurrentRow.Cells["IDVENTA"].Value.ToString() + "' ", conexion);
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
            }
            finally
            {
                MessageBox.Show("Estado de la venta Actualizado");
                Ventas();
            }
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
            textIDVENTA.Text = dataGridView1.CurrentRow.Cells["IDVENTA"].Value.ToString();
        }
    }
}
