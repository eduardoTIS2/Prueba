using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using Npgsql;

namespace BD_Pandillas
{
    public partial class MostrarPersona : Form
    {
        DataTable tabla = new DataTable();

        public MostrarPersona()
        {
            InitializeComponent();
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            p.Show();
            this.Hide();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == 0 || cmbStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Debes seleccionar un status y un tipo de las personas que quieres que se muestren");
            }
            else
            {
                try
                {
                    tabla.Rows.Clear();
                    tabla.Columns.Clear();
                    NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;"
                            + "Database=BD_Pandillas;" +
                        "User ID=mags;");
                    if (cmbTipo.SelectedIndex == 3 && cmbStatus.SelectedIndex == 3)
                    {
                        //tabla.Columns.Clear();
                        tabla.Columns.Add("ID_PERSONA");
                        tabla.Columns.Add("NOMBRE");
                        tabla.Columns.Add("EDAD");
                        tabla.Columns.Add("FECHA_NAC");
                        tabla.Columns.Add("EMAIL");
                        tabla.Columns.Add("DIRECCION");
                        tabla.Columns.Add("TEL");
                        tabla.Columns.Add("CEL");
                        tabla.Columns.Add("CARGO");
                        tabla.Columns.Add("STATUS");
                        tabla.Columns.Add("TIPO");
                        NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select * from persona", conexion);

                        datosConsulta.Fill(tabla);

                        dtgPersona.DataSource = tabla.DefaultView;
                    }
                    else if (cmbTipo.SelectedIndex == 2 && cmbStatus.SelectedIndex == 3)
                    {
                        //tabla.Columns.Clear();
                        tabla.Columns.Add("ID_PERSONA");
                        tabla.Columns.Add("NOMBRE");
                        tabla.Columns.Add("EDAD");
                        tabla.Columns.Add("FECHA_NAC");
                        tabla.Columns.Add("EMAIL");
                        tabla.Columns.Add("DIRECCION");
                        tabla.Columns.Add("TEL");
                        tabla.Columns.Add("CEL");
                        tabla.Columns.Add("STATUS");

                        NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select id_persona,nombre,edad,fecha_nac,email,direccion,tel,cel,status from persona where tipo='Asistente'", conexion);

                        datosConsulta.Fill(tabla);

                        dtgPersona.DataSource = tabla.DefaultView;
                    }
                    else if (cmbTipo.SelectedIndex == 1 && cmbStatus.SelectedIndex == 3)
                    {
                        //tabla.Columns.Clear();
                        tabla.Columns.Add("ID_PERSONA");
                        tabla.Columns.Add("NOMBRE");
                        tabla.Columns.Add("EDAD");
                        tabla.Columns.Add("FECHA_NAC");
                        tabla.Columns.Add("EMAIL");
                        tabla.Columns.Add("DIRECCION");
                        tabla.Columns.Add("TEL");
                        tabla.Columns.Add("CEL");
                        tabla.Columns.Add("CARGO");
                        tabla.Columns.Add("STATUS");

                        NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select id_persona,nombre,edad,fecha_nac,email,direccion,tel,cel,cargo,status from persona where tipo='Servidor'", conexion);

                        datosConsulta.Fill(tabla);

                        dtgPersona.DataSource = tabla.DefaultView;
                    }
                    else if (cmbTipo.SelectedIndex == 3 && cmbStatus.SelectedIndex == 2)
                    {
                        //tabla.Columns.Clear();
                        tabla.Columns.Add("ID_PERSONA");
                        tabla.Columns.Add("NOMBRE");
                        tabla.Columns.Add("EDAD");
                        tabla.Columns.Add("FECHA_NAC");
                        tabla.Columns.Add("EMAIL");
                        tabla.Columns.Add("DIRECCION");
                        tabla.Columns.Add("TEL");
                        tabla.Columns.Add("CEL");
                        tabla.Columns.Add("TIPO");

                        NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select id_persona,nombre,edad,fecha_nac,email,direccion,tel,cel,tipo from persona where status='Inactivo'", conexion);

                        datosConsulta.Fill(tabla);

                        dtgPersona.DataSource = tabla.DefaultView;
                    }
                    else if (cmbTipo.SelectedIndex == 2 && cmbStatus.SelectedIndex == 2)
                    {
                        //tabla.Columns.Clear();
                        tabla.Columns.Add("ID_PERSONA");
                        tabla.Columns.Add("NOMBRE");
                        tabla.Columns.Add("EDAD");
                        tabla.Columns.Add("FECHA_NAC");
                        tabla.Columns.Add("EMAIL");
                        tabla.Columns.Add("DIRECCION");
                        tabla.Columns.Add("TEL");
                        tabla.Columns.Add("CEL");
                        dtgPersona.DataSource = tabla.DefaultView;

                        NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select id_persona,nombre,edad,fecha_nac,email,direccion,tel,cel from persona where status='Inactivo' and tipo='Asistente'", conexion);

                        datosConsulta.Fill(tabla);
                    }
                    else if (cmbTipo.SelectedIndex == 1 && cmbStatus.SelectedIndex == 2)
                    {
                        //tabla.Columns.Clear();
                        tabla.Columns.Add("ID_PERSONA");
                        tabla.Columns.Add("NOMBRE");
                        tabla.Columns.Add("EDAD");
                        tabla.Columns.Add("FECHA_NAC");
                        tabla.Columns.Add("EMAIL");
                        tabla.Columns.Add("DIRECCION");
                        tabla.Columns.Add("TEL");
                        tabla.Columns.Add("CEL");

                        NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select id_persona,nombre,edad,fecha_nac,email,direccion,tel,cel from persona where status='Inactivo' and tipo='Servidor'", conexion);

                        datosConsulta.Fill(tabla);

                        dtgPersona.DataSource = tabla.DefaultView;
                    }
                    else if (cmbTipo.SelectedIndex == 3 && cmbStatus.SelectedIndex == 1)
                    {
                        //tabla.Columns.Clear();
                        tabla.Columns.Add("ID_PERSONA");
                        tabla.Columns.Add("NOMBRE");
                        tabla.Columns.Add("EDAD");
                        tabla.Columns.Add("FECHA_NAC");
                        tabla.Columns.Add("EMAIL");
                        tabla.Columns.Add("DIRECCION");
                        tabla.Columns.Add("TEL");
                        tabla.Columns.Add("CEL");
                        tabla.Columns.Add("CARGO");
                        tabla.Columns.Add("TIPO");

                        NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select id_persona,nombre,edad,fecha_nac,email,direccion,tel,cel,cargo,tipo from persona where status='Activo'", conexion);

                        datosConsulta.Fill(tabla);

                        dtgPersona.DataSource = tabla.DefaultView;
                    }
                    else if (cmbTipo.SelectedIndex == 2 && cmbStatus.SelectedIndex == 1)
                    {
                        //tabla.Columns.Clear();
                        tabla.Columns.Add("ID_PERSONA");
                        tabla.Columns.Add("NOMBRE");
                        tabla.Columns.Add("EDAD");
                        tabla.Columns.Add("FECHA_NAC");
                        tabla.Columns.Add("EMAIL");
                        tabla.Columns.Add("DIRECCION");
                        tabla.Columns.Add("TEL");
                        tabla.Columns.Add("CEL");

                        NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select id_persona,nombre,edad,fecha_nac,email,direccion,tel,cel from persona where status='Activo' and tipo='Asistente'", conexion);

                        datosConsulta.Fill(tabla);

                        dtgPersona.DataSource = tabla.DefaultView;
                    }
                    else if (cmbTipo.SelectedIndex == 1 && cmbStatus.SelectedIndex == 1)
                    {
                        //tabla.Columns.Clear();
                        tabla.Columns.Add("ID_PERSONA");
                        tabla.Columns.Add("NOMBRE");
                        tabla.Columns.Add("EDAD");
                        tabla.Columns.Add("FECHA_NAC");
                        tabla.Columns.Add("EMAIL");
                        tabla.Columns.Add("DIRECCION");
                        tabla.Columns.Add("TEL");
                        tabla.Columns.Add("CEL");
                        tabla.Columns.Add("CARGO");

                        NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select id_persona,nombre,edad,fecha_nac,email,direccion,tel,cel,cargo from persona where status='Activo' and tipo='Servidor'", conexion);

                        datosConsulta.Fill(tabla);

                        dtgPersona.Rows.Clear();

                        dtgPersona.DataSource = tabla.DefaultView;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void MostrarPersona_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            cmbTipo.SelectedIndex = 0;
        }

        private void printDocument1_PrintPage(object sender,System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                IDbConnection dbcon = new NpgsqlConnection("Server=localhost;"
                            + "Database=BD_Pandillas;" +
                        "User ID=mags;");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = "select * from persona";

                IDataReader reader = dbcmd.ExecuteReader();
                int superior = 150;
                
                while (reader.Read())
                {
                    /*if (superior > 750)
                    {
                        e.HasMorePages = true;
                        superior = 150;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }*/
                    int ID = reader.GetInt32(reader.GetOrdinal("id_persona"));
                    string nombre = reader.GetString(reader.GetOrdinal("nombre"));
                    string fecha_nac;
                    string edad;
                    string direccion;
                    string email;
                    string tel;
                    string cel;
                    try
                    {
                        fecha_nac = reader.GetDateTime(reader.GetOrdinal("fecha_nac")).ToShortDateString();
                        edad = reader.GetInt32(reader.GetOrdinal("edad")).ToString();
                    }
                    catch
                    {
                        fecha_nac = "";
                        edad = "";
                    }
                    try
                    {
                        direccion = reader.GetString(reader.GetOrdinal("direccion"));
                    }
                    catch
                    {
                        direccion = "";
                    }
                    try
                    {
                        email = reader.GetString(reader.GetOrdinal("email"));
                    }
                    catch
                    {
                        email = "";
                    }
                    try
                    {
                        tel = reader.GetString(reader.GetOrdinal("tel"));
                    }
                    catch
                    {
                        tel = "";
                    }
                    try
                    {
                        cel = reader.GetString(reader.GetOrdinal("tel"));
                    }
                    catch
                    {
                        cel = "";
                    }
                    string tipo = reader.GetString(reader.GetOrdinal("tipo"));
                    string cargo = reader.GetString(reader.GetOrdinal("cargo"));
                    string status = reader.GetString(reader.GetOrdinal("status"));

                    Image im;
                    try
                    {
                        im = Image.FromFile("Imagenes\\" + ID + ".jpg");
                    }
                    catch
                    {
                        im = Image.FromFile("Imagenes\\default.jpg");
                    }

                    e.Graphics.DrawImage(im, 100, superior, 180, 200);
                    e.Graphics.DrawString("Id Persona: " + ID, new Font("Tahoma", 14), Brushes.Black, 300, superior);
                    e.Graphics.DrawString("Nombre: " + nombre, new Font("Tahoma", 14), Brushes.Black, 300, superior + 30);
                    e.Graphics.DrawString("Fecha de Nacimiento: " + fecha_nac, new Font("Tahoma", 14), Brushes.Black, 300, superior + 60);
                    e.Graphics.DrawString("Edad: " + edad, new Font("Tahoma", 14), Brushes.Black, 300, superior + 90);
                    e.Graphics.DrawString("Email: " + email, new Font("Tahoma", 14), Brushes.Black, 300, superior + 120);
                    e.Graphics.DrawString("Dirección: " + direccion, new Font("Tahoma", 14), Brushes.Black, 300, superior + 150);
                    e.Graphics.DrawString("Tel: " + tel, new Font("Tahoma", 14), Brushes.Black, 300, superior + 180);
                    e.Graphics.DrawString("Cel: " + tel, new Font("Tahoma", 14), Brushes.Black, 500, superior + 180);
                    e.Graphics.DrawString("Cargo: " + cargo, new Font("Tahoma", 14), Brushes.Black, 300, superior + 210);
                    e.Graphics.DrawString("Tipo: " + tipo, new Font("Tahoma", 14), Brushes.Black, 500, superior + 210);
                    e.Graphics.DrawString("Status: " + status, new Font("Tahoma", 14), Brushes.Black, 300, superior + 240);
                    superior += 300;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error...\n\n" + exc.ToString());
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
