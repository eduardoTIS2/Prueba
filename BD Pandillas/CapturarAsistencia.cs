using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace BD_Pandillas
{
    public partial class CapturarAsistencia : Form
    {
        int ID;
        public CapturarAsistencia()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal pr = new Principal();
            pr.Show();
            this.Hide();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DEL EVENTO DEL QUE CAPTURARÁS LA ASISTENCIA...");
                    txtId.Focus();
                }
                else
                {
                    try
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        ID = Convert.ToInt32(txtId.Text);
                        IDbCommand dbcmd = dbcon.CreateCommand();

                        dbcmd.CommandText = "select * from evento where id_evento=" + ID + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtTipo.Text = reader.GetString(reader.GetOrdinal("tipo"));
                            txtDescripcion.Text = reader.GetString(reader.GetOrdinal("descripcion"));
                            dbcon.Close();

                            cmbTipo.Enabled = true;
                            cmbTipo.Focus();
                            txtId.Enabled = false;
                        }
                        else
                        {
                            txtTipo.Text = "";
                            txtDescripcion.Text = "";
                            txtId.Text = "";
                            MessageBox.Show("Evento no encontrado, asegúrate de que el ID de evento que ingresaste esté registrado");
                        }
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.ToString());
                    }
                }
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            if (cmbTipo.SelectedIndex == 0)
            {
                try
                {
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();
                    IDbCommand dbcmdAsist = dbcon.CreateCommand();

                    dbcmd.CommandText = "select * from persona where tipo='" + cmbTipo.Text + "' and status='Activo'";
                    IDataReader reader = dbcmd.ExecuteReader();
                    IDataReader readerAsist;

                    chlbPersona.Items.Clear();
                    int ID_PERSONA;

                    for(i=0;reader.Read();i++)
                    {
                        ID_PERSONA=reader.GetInt32(reader.GetOrdinal("id_persona"));
                        dbcmdAsist.CommandText = "select * from asistencia_evento where id_evento=" + ID + " and id_persona=" + ID_PERSONA + "";
                        readerAsist=dbcmdAsist.ExecuteReader();

                        if (!readerAsist.Read())
                        {
                            string persona = reader.GetString(reader.GetOrdinal("nombre"));
                            chlbPersona.Items.Add(persona);
                        }
                    }
                    dbcon.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
            }
            else if (cmbTipo.SelectedIndex == 1)
            {
                try
                {
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();
                    IDbCommand dbcmdAsist = dbcon.CreateCommand();

                    dbcmd.CommandText = "select * from persona where tipo='" + cmbTipo.Text + "' and status='Activo'";
                    IDataReader reader = dbcmd.ExecuteReader();
                    IDataReader readerAsist;

                    chlbPersona.Items.Clear();
                    int ID_PERSONA;

                    for (i = 0; reader.Read(); i++)
                    {
                        ID_PERSONA = reader.GetInt32(reader.GetOrdinal("id_persona"));
                        dbcmdAsist.CommandText = "select * from asistencia_evento where id_evento=" + ID + " and id_persona=" + ID_PERSONA + "";
                        readerAsist = dbcmdAsist.ExecuteReader();

                        if (!readerAsist.Read())
                        {
                            string persona = reader.GetString(reader.GetOrdinal("nombre"));
                            chlbPersona.Items.Add(persona);
                        }
                    }
                    dbcon.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
            }
            else if (cmbTipo.SelectedIndex == 2)
            {
                try
                {
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();
                    IDbCommand dbcmdAsist = dbcon.CreateCommand();

                    dbcmd.CommandText = "select * from persona where status='Activo'";
                    IDataReader reader = dbcmd.ExecuteReader();
                    IDataReader readerAsist = dbcmd.ExecuteReader();

                    chlbPersona.Items.Clear();
                    int ID_PERSONA;

                    for (i = 0; reader.Read(); i++)
                    {
                        ID_PERSONA = reader.GetInt32(reader.GetOrdinal("id_persona"));
                        dbcmdAsist.CommandText = "select * from asistencia_evento where id_evento=" + ID + " and id_persona=" + ID_PERSONA + "";
                        readerAsist = dbcmdAsist.ExecuteReader();

                        if (!readerAsist.Read())
                        {
                            string persona = reader.GetString(reader.GetOrdinal("nombre"));
                            chlbPersona.Items.Add(persona);
                        }
                    }
                    dbcon.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
            }
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            int i=0;
            if (txtTipo.Text == "")
            {
                MessageBox.Show("INGRESA UN ID DE EVENTO Y PRESIONA ENTER...");
            }
            else if (cmbTipo.SelectedIndex >= 0 && cmbTipo.SelectedIndex <= 2)
            {
                try
                {
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();
                    IDataReader reader;

                    if (chlbPersona.CheckedItems.Count != 0)
                    {
                        string NOMBRE;
                        int ID_PERSONA;
                        for (i = 0; i < chlbPersona.CheckedItems.Count; i++)
                        {
                            CheckedListBox x=new CheckedListBox();
                            NOMBRE=chlbPersona.CheckedItems[i].ToString();

                            dbcmd.CommandText = "select * from persona where nombre='"+NOMBRE+"'";
                            reader = dbcmd.ExecuteReader();
                            if (reader.Read())
                            {
                                ID_PERSONA = reader.GetInt32(reader.GetOrdinal("id_persona"));

                                dbcmd.CommandText = "insert into asistencia_evento values(" + ID + "," + ID_PERSONA + ")";
                                reader = dbcmd.ExecuteReader();
                            }
                            else
                            {
                                MessageBox.Show("No fue posible leer nada... nombre= "+NOMBRE);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No seleccionaste ninguna persona de la lista? no quieres registrar nada? pues sólo regresate o salte =P");
                    }

                    dbcon.Close();

                    txtId.Text = "";
                    txtTipo.Text = "";
                    txtDescripcion.Text = "";
                    cmbTipo.Text = "";

                    chlbPersona.Items.Clear();

                    txtTipo.Enabled = false;
                    txtDescripcion.Enabled = false;
                    cmbTipo.Enabled = false;

                    txtId.Enabled = true;

                    if (i != 0)
                    {
                        MessageBox.Show("Asistencia capturada correctamente");
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show("error.....\n\n" + msg.ToString());
                }
            }
            else
            {
                MessageBox.Show("Selecciona un tipo de persona de la lista desplegable para luego seleccionar a quienes asistieron y poder capturar su asistencia");
            }
        }
    }
}
