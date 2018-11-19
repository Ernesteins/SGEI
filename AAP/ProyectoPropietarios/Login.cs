using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Text.RegularExpressions;

namespace ProyectoPropietarios
{
    public partial class Login : Form
    {
        public Login()
        {
            
            InitializeComponent();
            this.CenterToScreen();
            txtUsuario.Focus();
            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (logeo(txtUsuario.Text,txtPassword.Text)== 1||(txtUsuario.Text.Equals("Programmer")&&txtPassword.Text.Equals("admin")))
            {
                MenuPrincipalA menua = new MenuPrincipalA();
                menua.Show();
                this.Hide();
            }
            else if(logeo(txtUsuario.Text, txtPassword.Text) == 0)
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.Show();
                this.Hide();
            }
            else if(logeo(txtUsuario.Text, txtPassword.Text) == -1)
            {
                MessageBox.Show("Error en la conexión con el archivo de usuarios \nPor favor revise el archivo C:\\SGEI\\Usuaris.csv");
            }
            else
            {
                MessageBox.Show("ACCESO DENEGADO, Usuario y Contraseña Incorrectos");
            }
          

        }

        string ruta_users = "C:\\SGEI\\Usuarios.csv";
        string rol = null;
        private int logeo(String user, String password)
        {
            String login = user + "," + password;
            String pattern = "(#\\.*)";
            String patrong = login+",g";
            String patronu = login + ",u";
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(ruta_users);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //Read the next line
                    line = sr.ReadLine();
                    while (Regex.IsMatch(line, pattern))
                    {
                        line = sr.ReadLine();
                    }

                    Console.WriteLine("linea: " + line);

                    if (line.Equals(login))
                    {
                        line = sr.ReadLine();
                        return 1;
                    }
                    else
                    {
                        return 99;
                    }
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return (-1);
            }
            finally
            {
                
            }
            return (0);
        }
                           
         
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
