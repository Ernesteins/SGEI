using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoPropietarios.Módulo_Ventas
{
    public partial class RegistrarVenta : Form
    {
        public RegistrarVenta()
        {
            InitializeComponent();
            this.CenterToScreen();

        }
        Boolean permitido = false;


        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Close();
        }
        private void buscar2()
        {
            errorProvider1.Clear();
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
                            btnAceptar.Enabled = false;
                            textBusquedaRUC.Enabled = false;

                            ninjaGrid.DataSource = dt;
                            textID.Text = ninjaGrid.CurrentRow.Cells[0].Value.ToString();
                            textNombre.Text = ninjaGrid.CurrentRow.Cells[1].Value.ToString();
                            textApellido.Text = ninjaGrid.CurrentRow.Cells[2].Value.ToString();
                            textIDFill.Text = ninjaGrid.CurrentRow.Cells[7].Value.ToString();
                            textTelf.Text = ninjaGrid.CurrentRow.Cells[3].Value.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
                    }
                }
            conexion.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            buscar2();
        }

        private void RegistrarVenta_Load(object sender, EventArgs e)
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
     

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (permitido)
            {
                
                if (comboBox1.SelectedItem==null || comboBox2.SelectedItem==null)
                {
                    MessageBox.Show("primero debe escojer un Servicio y un Soporte");
                }
                else
                {
                    agregar();
                    carga();
                    calculatotal();
                }
                
            }
            else
            {
                DialogResult result = MessageBox.Show("Crear una venta para el cliente " + textNombre.Text + " " + textApellido.Text + " ?", "Empezar venta", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    permitido = true;
                    crearVenta();
                    cargacmbServicio();
                    cargacmbSoporte();
                    identificarNuevaFactura();
                }
            }
        }
        private void cargacmbServicio()
        {
            String Nombre = null;
            try
            {
                SqlCommand query = new SqlCommand("SELECT NOMBRESERVICIO, PRECIOSERVICIO FROM SERVICIO", conexion);
                conexion.Open();
                SqlDataReader reader= query.ExecuteReader();
                while (reader.Read())
                {
                    {
                        Nombre = Convert.ToString(reader["NOMBRESERVICIO"]);
                        //Precio = Convert.ToString(reader["PRECIOSERVICIO"]);
                    };
                    comboBox1.Items.Add(Nombre);
                }
                conexion.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error en la carga del combobox de Servicio: "+e);
            }
        }
        private void cargacmbSoporte()
        {
            String Nombre= null;
            try
            {
                SqlCommand query = new SqlCommand("SELECT NOMBRESOPORTE, PRECIOSOPORTE FROM SOPORTE", conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    {
                        Nombre = Convert.ToString(reader["NOMBRESOPORTE"]);
                        //Precio = Convert.ToString(reader["PRECIOSOPORTE"]);
                    };
                    comboBox2.Items.Add(Nombre);
                }
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la carga del combobox de Soporte: " + e);
            }
        }

        private void crearVenta()
        {
            DateTimePicker dtp1 = new DateTimePicker();
            String fecha = dtp1.Value.Date.ToString("MM/dd/yyyy");
            String hora = DateTime.Now.TimeOfDay.ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("Insert into venta  values('" + textID.Text+ "','" + fecha + "','Deshabilitada','" + textTotal.Text + "')", conexion);
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
            
            
        }
        private void identificarNuevaFactura()
        {
            try
            {
                SqlCommand query = new SqlCommand("SELECT IDVENTA FROM VENTA", conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                    textIDVENTA.Text = Convert.ToString(reader["IDVENTA"]);
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la carga del ID de la nueva Venta: " + e);
            }
        }
        private void agregar()
        {
            if (comboBox1.SelectedItem != null || comboBox2.SelectedItem != null)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into detalleventa values('"+textIDVENTA.Text+"',(Select IDSERVICIO From SERVICIO Where NOMBRESERVICIO = '"+comboBox1.SelectedItem.ToString()+"'),(SELECT IDSOPORTE FROM SOPORTE WHERE NOMBRESOPORTE ='"+comboBox2.SelectedItem.ToString()+"'),'1','"+calcularServicioMasSoporte()+"')", conexion);
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
                
            }
            
        }
        private int calcularServicioMasSoporte()
        {
            int total = 0;
            try
            {
                SqlCommand query = new SqlCommand("SELECT PRECIOSERVICIO, PRECIOSOPORTE FROM SOPORTE,SERVICIO WHERE NOMBRESERVICIO = '"+comboBox1.SelectedItem.ToString()+"' AND NOMBRESOPORTE = '"+comboBox2.SelectedItem.ToString()+"'", conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
                if (reader.Read())
                    total = Convert.ToInt32(reader["PRECIOSERVICIO"])+Convert.ToInt32(reader["PRECIOSOPORTE"]);
                conexion.Close();
            }
            catch
            {

            }
            return total;

        }

        private void calculatotal()
        {
            textTotal.Text = "0,0";
            string tmp;
            int filas = 0;
            decimal totalVenta = 0;
            if (dataGridView1.RowCount != 0)
            {
                while (filas < dataGridView1.RowCount)
                {
                    totalVenta += Convert.ToDecimal(dataGridView1["TOTAL", filas].Value);
                    filas++;
                }
                tmp = Convert.ToString(totalVenta);
                textTotal.Text = tmp.Split(',')[0] + "." + tmp.Split(',')[1];
            }
        }
        private void carga()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Execute CreacionVenta '" + textIDVENTA.Text+"'", conexion);
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
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
            }
            conexion.Close();
            
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update venta set estadoventa= 'Habilitada', preciototalventa = '" + textTotal.Text + "' where idventa = '"+textIDVENTA.Text+"' ", conexion);
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
                carga();
                calculatotal();
                MessageBox.Show("Total de la venta Actualizado");
            }
            
            
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 1) { MessageBox.Show("Por favor seleccione solo una celda a la vez"); }
                else
                {
                    conexion.Open();
                    SqlCommand Quitar = new SqlCommand("delete detalleventa where IDDETALLEVENTA ='" + dataGridView1["IDDETALLEVENTA", dataGridView1.SelectedRows.Count].Value + "'", conexion);
                    int result = Quitar.ExecuteNonQuery();
                    conexion.Close();
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al quitar un campo: "+ex);
            }
            finally
            {
                carga();
                calculatotal();
                MessageBox.Show("Campo eliminado con exito");
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
    }
}
