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
using System.Text.RegularExpressions;
using System.IO;

namespace ProyectoPropietarios.Módulo_de_Cliente
{
    public partial class RegistrarCliente : Form
    {
        //SqlConnection conexion = new SqlConnection("server=DESKTOP-T3II60T\\SQLEXPRESS; database=SGEI; integrated security = true");
        public RegistrarCliente()
        {
            InitializeComponent();
            this.CenterToScreen();
            textRUC.MaxLength = 13;
            textTelefonoMov.MaxLength = 10;
        }

      

        private void ingresarRUC()
        {
            errorProvider1.Clear();
            conexion.Close();
            Boolean aprobacion = true;
            if (textRUC.Text == "")
            {
                textRUC.Select(0, textRUC.Text.Length);
                errorProvider1.SetError(textRUC, "Campo Obligatorio");
                aprobacion = false;
            }
            if (textNombre.Text == "")
            {
                textNombre.Select(0, textNombre.Text.Length);
                errorProvider1.SetError(textNombre, "Campo Obligatorio");
                aprobacion = false;
            }
            if (textApellido.Text == "")
            {
                textApellido.Select(0, textApellido.Text.Length);
                errorProvider1.SetError(textApellido, "Campo Obligatorio");
                aprobacion = false;
            }

            if (textTelefonoMov.Text == "")
            {
                textTelefonoMov.Select(0, textTelefonoMov.Text.Length);
                errorProvider1.SetError(textTelefonoMov, "Campo Obligatorio");
                aprobacion = false;
            }

            if (textDireccion.Text == "")
            {
                textDireccion.Select(0, textDireccion.Text.Length);
                errorProvider1.SetError(textDireccion, "Campo Obligatorio");
                aprobacion = false;
            }
            if (textCorreo.Text == "")
            {
                textCorreo.Select(0, textCorreo.Text.Length);
                errorProvider1.SetError(textCorreo, "Campo Obligatorio");
                aprobacion = false;
            }
            if (ComprobarFormatoEmail(textCorreo.Text) == false)
            {
                textCorreo.Select(0, textCorreo.Text.Length);
                errorProvider1.SetError(textCorreo, "El formato del correo es inválido");
                aprobacion = false;
            }
            if (textEmpresa.Text == "")
            {
                textEmpresa.Select(0, textEmpresa.Text.Length);
                errorProvider1.SetError(textEmpresa, "Campo Obligatorio");
                aprobacion = false;
            }

            if (aprobacion)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into cliente values('" + textRUC.Text + "','" + textNombre.Text + "','" + textApellido.Text + "','" + textTelefonoMov.Text + "','" + textDireccion.Text + "','" + textCorreo.Text + "','Activo','" + textEmpresa.Text + "')", conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente registrado exitosamente.");
                    limpiar();
                    errorProvider1.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se ingreso el cliente \nError: " + ex.ToString());
                    errorProvider1.Clear();

                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
                ingresarRUC();
       
            
        }
        

        private void textNombre_Enter(object sender, EventArgs e)
        {
            conexion.Close();
            SqlCommand cmd = new SqlCommand("select * from cliente where RUC= '" + textRUC.Text + "'", conexion);
            conexion.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            if (textRUC.Text == "")
            {

                textRUC.Select(0, textRUC.Text.Length);
                errorProvider1.SetError(textRUC, "Campo Obligatorio");
                textRUC.Focus();


            }
            else if (reader.HasRows)
            {
                MessageBox.Show("Ya existe un cliente registrado con el RUC " + textRUC.Text + " , verifique los datos por favor");
                limpiar();
                textRUC.Focus();



            }
            else if (textRUC.TextLength < 13)
            {
                MessageBox.Show("El RUC no puede tener menos de 13 dígitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textRUC.Focus();

            }
            else
            {
                return;
            }
        }
        void limpiar()
        {
            textRUC.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            textDireccion.Text = "";
            textTelefonoMov.Text = "";
            textCorreo.Text = "";
            textEmpresa.Text = "";
            textRUC.Focus();
            errorProvider1.Clear();
        }

        private void textApellido_Enter(object sender, EventArgs e)
        {
            if (textNombre.Text == "")
            {

                textNombre.Select(0, textNombre.Text.Length);
                errorProvider1.SetError(textNombre, "Campo Obligatorio");
                textNombre.Focus();

            }
            else
            {
                return;
            }
        }

        private void textTelefonoMov_Enter(object sender, EventArgs e)
        {

            if (textApellido.Text == "")
            {

                textApellido.Select(0, textApellido.Text.Length);
                errorProvider1.SetError(textApellido, "Campo Obligatorio");
                textApellido.Focus();
            }
            else
            {
                return;
            }
        }

        private void textDireccion_Enter(object sender, EventArgs e)
        {
            if (textTelefonoMov.Text == "")
            {

                textTelefonoMov.Select(0, textTelefonoMov.Text.Length);
                errorProvider1.SetError(textTelefonoMov, "Campo Obligatorio");
                textTelefonoMov.Focus();
            }
            else if (textTelefonoMov.TextLength < 10)
            {
                MessageBox.Show("El número de teléfono no puede tener menos de 10 dígitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textTelefonoMov.Focus();
                return;
            }
            else
            {
                return;
            }
        }

        private void textCorreo_Enter(object sender, EventArgs e)
        {
            if (textDireccion.Text == "")
            {

                textDireccion.Select(0, textDireccion.Text.Length);
                errorProvider1.SetError(textDireccion, "Campo Obligatorio");
                textDireccion.Focus();
            }
            else
            {
                return;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }

        private void textRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
             if ((char.IsLetter(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if((char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("No se permiten espacios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textApellido_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textTelefonoMov_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("No se permiten espacios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
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

        private void RegistrarCliente_Load(object sender, EventArgs e)
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

        private void textCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textEmpresa_Enter(object sender, EventArgs e)
        {
            if (textEmpresa.Text == "")
            {

                textEmpresa.Select(0, textEmpresa.Text.Length);
                errorProvider1.SetError(textEmpresa, "Campo Obligatorio");
                textEmpresa.Focus();
            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void radioButtonCedula_CheckedChanged(object sender, EventArgs e)
        { }
           

        private void radioButtonRUC_CheckedChanged(object sender, EventArgs e)
        {
           
        }
  

        private void textRUC_KeyPress_1(object sender, KeyPressEventArgs e)
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
    }



}
