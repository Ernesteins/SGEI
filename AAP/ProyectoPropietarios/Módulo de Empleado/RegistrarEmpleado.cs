using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace ProyectoPropietarios.Módulo_Empleados
{
    public partial class IngresarEmpleado : Form
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
                
        public IngresarEmpleado()
        {
            InitializeComponent();
            this.CenterToScreen();
            textCedula.MaxLength = 10;
            textTelefonoMov.MaxLength = 10;
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Hide();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            conexion.Close();
            Boolean aprobacion = true;
            if (textCedula.Text == "")
            {
                textCedula.Select(0, textCedula.Text.Length);
                errorProvider1.SetError(textCedula, "Campo Obligatorio");
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
            if (textCargo.Text == "")
            {
                textCargo.Select(0, textCargo.Text.Length);
                errorProvider1.SetError(textCargo, "Campo Obligatorio");
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
            if (textSueldo.Text == "")
            {
                textSueldo.Select(0, textSueldo.Text.Length);
                errorProvider1.SetError(textSueldo, "Campo Obligatorio");
                aprobacion = false;
            }

            if (aprobacion)
            {
                lectura();
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into empleado values('" + textCedula.Text + "','" + textNombre.Text + "','" + textApellido.Text + "','" + textTelefonoMov.Text + "','" + textDireccion.Text + "','" + textCargo.Text + "','" +textSueldo.Text+  "','Activo')", conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Empleado registrado exitosamente");
                    limpiar();
                    errorProvider1.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se ingreso el empleado \nError: " + ex.ToString());
                    errorProvider1.Clear();

                }
            }
        }

        void limpiar()
        {
            textCedula.Text = "";
            textCargo.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            textDireccion.Text = "";
            textTelefonoMov.Text = "";
            textSueldo.Text = "";
        }


        private void textNombre_Enter(object sender, EventArgs e)
        {
            conexion.Close();
            SqlCommand cmd = new SqlCommand("select * from empleado where cedula= '" + textCedula.Text + "'", conexion);
            conexion.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
          
            if (textCedula.Text == "")
            {

                textCedula.Select(0, textCedula.Text.Length);
                errorProvider1.SetError(textCedula, "Campo Obligatorio");
                textCedula.Focus();
                

            }
            else if(reader.HasRows)
                {
                MessageBox.Show("Ya existe un empleado registrado con la cédula "+textCedula.Text+" , verifique los datos por favor");
                limpiar();
                textCedula.Focus();

                
       
            }
            else if(textCedula.TextLength < 10)
            {
                MessageBox.Show("La cédula no puede tener menos de 10 dígitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textCedula.Focus();
            
            }
            else
            {
                return;
            }
                
            
        }

       
        private void textCargo_Enter(object sender, EventArgs e)
        {
            if (textApellido.Text == "")
            {

                textApellido.Select(0,textApellido.Text.Length);
                errorProvider1.SetError(textApellido, "Campo Obligatorio");
                textApellido.Focus();
            }
            else
            {
                return;
            }
        }

        private void textTelefonoMov_Enter(object sender, EventArgs e)
        {
            if (textSueldo.Text == "")
            {

                textSueldo.Select(0, textSueldo.Text.Length);
                errorProvider1.SetError(textSueldo, "Campo Obligatorio");
                textSueldo.Focus();
            }
            else
            {
                return;
            }
        }
        
        private void textCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if((char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("No se permiten espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else
            {

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

      
        private void textTelefonoMov_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) )
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
        private void textCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) )
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

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            textCedula.Focus();
            errorProvider1.Clear();
        }

        private void textTelefonoMov_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Solo se permiten números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if (char.IsWhiteSpace(e.KeyChar))

            {
                MessageBox.Show("No se permiten espacios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textApellido_KeyPress_1(object sender, KeyPressEventArgs e)
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
            if ((char.IsLetter(e.KeyChar)) )
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

        private void textApellido_Enter_1(object sender, EventArgs e)
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

        private void textSueldo_Enter(object sender, EventArgs e)
        {
            if (textCargo.Text == "")
            {

                textCedula.Select(0, textCargo.Text.Length);
                errorProvider1.SetError(textCargo, "Campo Obligatorio");
                textCargo.Focus();
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

                textCedula.Select(0, textTelefonoMov.Text.Length);
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

        private void textCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void IngresarEmpleado_Load(object sender, EventArgs e)
        {
            lectura();
        }
    }


    }
    
    

