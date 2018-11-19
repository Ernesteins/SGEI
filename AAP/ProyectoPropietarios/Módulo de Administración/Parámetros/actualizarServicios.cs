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

namespace ProyectoPropietarios.Módulo_de_Administración.Parámetros
{
    public partial class actualizarServicios : Form
    {
        public actualizarServicios()
        {
            InitializeComponent();
        }

        private void actualizarServicios_Load(object sender, EventArgs e)
        {
            lectura();
            actualizarS();
        }
        SqlConnection conexion = null;
        public void actualizarS()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Select * from Servicio", conexion);
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();
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
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipalA menu = new MenuPrincipalA();
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtD.Text!=""|| txtP.Text != "" || txtPrecio.Text != ""|| txtN.Text != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into servicio values('"+txtN.Text+"','"+ txtD.Text + "','"+ txtPrecio.Text + "','"+ txtP.Text + "')", conexion);
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
                    actualizarS();
                }
            }
            else
            {
                MessageBox.Show("Se necesita todos los parámetros");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("delete servicio where idservicio = '"+textBox1.Text +"'", conexion);
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
                actualizarS();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["IDservicio"].Value.ToString();
            }
            catch
            {

            }
            
        }
    }
}
