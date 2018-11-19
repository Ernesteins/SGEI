using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace ProyectoPropietarios.Módulo_Clientes
{
    public partial class EditarCliente : Form
    {
        SqlConnection conexion = null;
       // SqlConnection conexion = new SqlConnection("server=DESKTOP-T3II60T\\SQLEXPRESS; database=SGEI; integrated security = true");
        public EditarCliente()
        {
            lectura();
            InitializeComponent();
            conexion.Close();
            this.CenterToScreen();
            radioButtonApellido.Checked = false;
            radioButtonRUC.Checked = false;
            btnBuscar.Enabled = false;
            btnModificar.Enabled = false;
            btnAceptar.Enabled =  false;
            textBusquedaApellido.Enabled = false;
            textBusquedaRUC.Enabled = false;
            textBusquedaRUC.MaxLength = 13;
            textMovil.MaxLength = 10;

        }


        private void Editar()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("update cliente set telefonomovil_cliente= '" + textMovil.Text + "', direccion_cliente='" + textDireccion.Text + "', correo_cliente= '" + textCorreo.Text +"', empresa_cliente= '"+textEmpresa.Text+"' where RUC='" + dataGridView1.CurrentRow.Cells["RUC"].Value.ToString() + "'", conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos del cliente modificados exitosamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante la actualización del cliente \nError: " + ex.ToString());
            }


            conexion.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textDireccion.Enabled = true;
            textCorreo.Enabled = true;
            textMovil.Enabled = true;
            textEmpresa.Enabled = true;
            btnAceptar.Enabled = true;
           
        }

    
        private void buscar()
        {
            conexion.Close();
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

                        SqlCommand cmd = new SqlCommand("select * from cliente where apellido_cliente = '" + textBusquedaApellido.Text + "'", conexion);
                        conexion.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No existe el  cliente, verifique la el apellido por favor.");
                            textBusquedaApellido.Text = "";
                            textBusquedaApellido.Focus();
                        }
                        else
                        {
                            btnBuscar.Enabled = false;
                            textBusquedaRUC.Enabled = false;
                            textBusquedaApellido.Enabled = false;
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
                            MessageBox.Show("No existe el cliente, verifique la cédula  por favor-");
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
                conexion.Close();
            }
        }
       

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

   
        void limpiar()
        {
            textNombre.Text = "";
            textApellido.Text = "";
            textMovil.Text = "";
            textDireccion.Text = "";
            textCorreo.Text = "";
            textBusquedaApellido.Text = "";
            textBusquedaRUC.Text = "";
            textEmpresa.Text = "";
            textNombre.Enabled = false;
            textApellido.Enabled = false;
            textDireccion.Enabled = false;
            textCorreo.Enabled = false;
            textMovil.Enabled = false;
            textEmpresa.Enabled = false;
            radioButtonRUC.Enabled = true;
            radioButtonApellido.Enabled = true;
            dataGridView1.DataSource = null;
            btnAceptar.Enabled = false;
            btnModificar.Enabled = false;

            if (radioButtonApellido.Checked)
                radioButtonApellido.Checked = false;
            else if (radioButtonRUC.Checked)
                radioButtonRUC.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
                conexion.Close();
                Boolean aprobacion = true;

                if (textCorreo.Text == "")
                {
                    textCorreo.Select(0, textCorreo.Text.Length);
                    errorProvider1.SetError(textCorreo, "Campo Obligatorio");
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
                if (textEmpresa.Text == "")
                {
                    textEmpresa.Select(0, textEmpresa.Text.Length);
                    errorProvider1.SetError(textEmpresa, "Campo Obligatorio");
                    aprobacion = false;
                }
                if (ComprobarFormatoEmail(textCorreo.Text) == false)
                {
                textCorreo.Select(0, textCorreo.Text.Length);
                errorProvider1.SetError(textCorreo, "El formato del correo es inválido");
                aprobacion = false;
                 }


            if (aprobacion)
                {
                    Editar();
                    buscar();
                }
        }

   
        public static bool ComprobarFormatoEmail(string eMailAComprobar)
            {
                String sFormato;
                sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(eMailAComprobar, sFormato))
                {
                    if (Regex.Replace(eMailAComprobar, sFormato, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
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

    private void textBusquedaRUC_KeyPress_1(object sender, KeyPressEventArgs e)
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
            btnModificar.Enabled = true;
        
            textNombre.Text = dataGridView1.CurrentRow.Cells["nombre_cliente"].Value.ToString();
            textApellido.Text = dataGridView1.CurrentRow.Cells["apellido_cliente"].Value.ToString();
            textMovil.Text = dataGridView1.CurrentRow.Cells["telefonomovil_cliente"].Value.ToString();
            textDireccion.Text = dataGridView1.CurrentRow.Cells["direccion_cliente"].Value.ToString();
            textCorreo.Text = dataGridView1.CurrentRow.Cells["correo_cliente"].Value.ToString();
            textEmpresa.Text = dataGridView1.CurrentRow.Cells["empresa_cliente"].Value.ToString();




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

    private void textCorreo_KeyPress(object sender, KeyPressEventArgs e)
    {
        if ((char.IsWhiteSpace(e.KeyChar)))
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

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void radioButtonApellido_CheckedChanged(object sender, EventArgs e)
        {
        
                errorProvider1.Clear();
                btnBuscar.Enabled = true;
                if (radioButtonApellido.Checked)
                {
                    textBusquedaRUC.Enabled = false;
                    textBusquedaApellido.Enabled = true;
                    textBusquedaApellido.Text = "";
                    textBusquedaRUC.Text = "";
                    textNombre.Focus();

                }

            }

        private void radioButtonRUC_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            btnBuscar.Enabled = true;
            if (radioButtonRUC.Checked)
            {
                textBusquedaApellido.Enabled = false;
                textBusquedaRUC.Enabled = true;
                textBusquedaApellido.Text = "";
                textBusquedaRUC.Text = "";
                textBusquedaRUC.Focus();

            }
        }

        private void EditarCliente_Load(object sender, EventArgs e)
        {
            lectura();
        }
        //SqlConnection conexion = null;
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
   

   

