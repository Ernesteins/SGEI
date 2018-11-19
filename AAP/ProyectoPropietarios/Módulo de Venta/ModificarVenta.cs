using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoPropietarios.Módulo_de_Venta
{
    public partial class ModificarVenta : Form
    {
        public ModificarVenta()
        {
            InitializeComponent();
            plantilla1();
            lectura();
        }
        

        private void ModificarVenta_Load(object sender, EventArgs e)
        {
            lectura();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
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
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
                }
                
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from venta where IDVENTA= '" + textBox1.Text + "'", conexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conexion.Open();
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
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnHabilitar.Visible = false;
            btnAgregar.Visible = true;
            btnQuitar.Visible = true;
            lb_venta.Visible = true;
            textIDVENTA.Visible = true;
            try
            {
                SqlCommand query = new SqlCommand("SELECT IDVENTA FROM VENTA where idventa= '" + textIDVENTA.Text +"' ", conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                    textIDVENTA.Text = Convert.ToString(reader["IDVENTA"]);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga del ID de la nueva Venta: " + ex);
            }
            cargacmbServicio();
            cargacmbSoporte();
        }

        private void cargacmbServicio()
        {
            String Nombre = null;
            try
            {
                SqlCommand query = new SqlCommand("SELECT NOMBRESERVICIO, PRECIOSERVICIO FROM SERVICIO", conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
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
            catch (Exception e)
            {
                MessageBox.Show("Error en la carga del combobox de Servicio: " + e);
            }
        }
        private void cargacmbSoporte()
        {
            String Nombre = null;
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

        private void btnElegir_Click(object sender, EventArgs e)
        {
            if (textIDVENTA.Text == "")
            {
                MessageBox.Show("Debe escojer una Venta de la lista primero.");
            }
            else
            {
                clienteNinja();
                plantilla2();
                
            }
            
            
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
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta \nError: " + ex.ToString());
                }
            }            
        }

        private void plantilla1()
        {
            //ocultos
            lb_id.Visible = false;
            lb_nombre.Visible = false;
            lb_apellido.Visible = false;
            lb_telf.Visible = false;
            lb_empresa.Visible = false;
            lb_servicio.Visible = false;
            lb_soporte.Visible = false;
            lbtotal.Visible = false;
            textID.Visible = false;
            textNombre.Visible = false;
            textApellido.Visible = false;
            textTelf.Visible = false;
            textIDFill.Visible = false;            
            textTotal.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            btnHabilitar.Enabled = false;

            //visibles
            lb_venta.Visible = true;
            textIDVENTA.Visible = true;
            btnElegir.Visible = true;
            dataGridViewVentas.Visible = true;
            dataGridView1.SetBounds(19, 114, 457, 378);
            dataGridViewVentas.SetBounds(6,20,421,212);
            //dataGridView1.SetBounds(19,198,457,243);

        }
        private void plantilla2()
        {
            //Ocultos
            btnElegir.Visible = false;
            dataGridViewVentas.Visible = false;            
            //Visibles
            lb_id.Visible = true;
            lb_nombre.Visible = true;
            lb_apellido.Visible = true;
            lb_telf.Visible = true;
            lb_empresa.Visible = true;
            lb_servicio.Visible = true;
            lb_soporte.Visible = true;
            lbtotal.Visible = true;
            lb_venta.Visible = true;
            textID.Visible = true;
            textNombre.Visible = true;
            textApellido.Visible = true;
            textTelf.Visible = true;
            textIDFill.Visible = true;
            textTotal.Visible = true;
            textIDVENTA.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            btnHabilitar.Enabled = true;
            dataGridView1.SetBounds(19, 198, 457, 243);
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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 1) { MessageBox.Show("Por favor seleccione solo una celda a la vez"); }
                else
                {
                    conexion.Open();
                    SqlCommand Quitar = new SqlCommand("delete detalleventa where IDDETALLEVENTA ='" + iddventa + "'", conexion);
                    int result = Quitar.ExecuteNonQuery();
                    conexion.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar un campo: " + ex);
            }
            finally
            {
                carga();
                calculatotal();
                //MessageBox.Show("Campo eliminado con exito");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
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
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
            }
            conexion.Close();

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
            private int calcularServicioMasSoporte()
        {
            int total = 0;
            try
            {
                SqlCommand query = new SqlCommand("SELECT PRECIOSERVICIO, PRECIOSOPORTE FROM SOPORTE,SERVICIO WHERE NOMBRESERVICIO = '" + comboBox1.SelectedItem.ToString() + "' AND NOMBRESOPORTE = '" + comboBox2.SelectedItem.ToString() + "'", conexion);
                conexion.Open();
                SqlDataReader reader = query.ExecuteReader();
                if (reader.Read())
                    total = Convert.ToInt32(reader["PRECIOSERVICIO"]) + Convert.ToInt32(reader["PRECIOSOPORTE"]);
                conexion.Close();
            }
            catch
            {

            }
            return total;

        }
        private void agregar()
        {
            if (comboBox1.SelectedItem != null || comboBox2.SelectedItem != null)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into detalleventa values('" + textIDVENTA.Text + "',(Select IDSERVICIO From SERVICIO Where NOMBRESERVICIO = '" + comboBox1.SelectedItem.ToString() + "'),(SELECT IDSOPORTE FROM SOPORTE WHERE NOMBRESOPORTE ='" + comboBox2.SelectedItem.ToString() + "'),'1','" + calcularServicioMasSoporte() + "')", conexion);
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

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update venta set estadoventa= 'Habilitada', preciototalventa = '" + textTotal.Text + "' where idventa = '" + textIDVENTA.Text + "' ", conexion);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID.Text = dataGridView1.CurrentRow.Cells["IDDETALLEVENTA"].Value.ToString();
            }
            catch
            {

            }
            
            
        }
        String iddventa="";
    }
    }
    