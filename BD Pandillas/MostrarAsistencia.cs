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
    public partial class MostrarAsistencia : Form
    {
        int ID;
        public MostrarAsistencia()
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
                    MessageBox.Show("DEBES INTRODUCIR EL ID DEL EVENTO QUE DESEAS CONSULTAR SU ASISTENCIA...");
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
            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                    try
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        IDbCommand dbcmd = dbcon.CreateCommand();
                        IDbCommand dbcmdAsist = dbcon.CreateCommand();

                        dbcmd.CommandText = "select * from persona where tipo='" + cmbTipo.Text + "'";
                        IDataReader reader = dbcmd.ExecuteReader();
                        IDataReader readerAsist;

                        chlbPersona.Items.Clear();
                        int ID_PERSONA;

                        for (i = 0; reader.Read(); i++)
                        {
                            ID_PERSONA = reader.GetInt32(reader.GetOrdinal("id_persona"));
                            dbcmdAsist.CommandText = "select * from asistencia_evento where id_evento=" + ID + " and id_persona=" + ID_PERSONA + "";
                            readerAsist = dbcmdAsist.ExecuteReader();

                            string persona = reader.GetString(reader.GetOrdinal("nombre"));
                            chlbPersona.Items.Add(persona);

                            if (readerAsist.Read())
                            {
                                chlbPersona.SetItemChecked(i, true);
                            }
                        }
                        dbcon.Close();
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.ToString());
                    }
                    break;
                case 1:
                    try
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        IDbCommand dbcmd = dbcon.CreateCommand();
                        IDbCommand dbcmdAsist = dbcon.CreateCommand();

                        dbcmd.CommandText = "select * from persona where tipo='" + cmbTipo.Text + "'";
                        IDataReader reader = dbcmd.ExecuteReader();
                        IDataReader readerAsist;

                        chlbPersona.Items.Clear();
                        int ID_PERSONA;

                        for (i = 0; reader.Read(); i++)
                        {
                            ID_PERSONA = reader.GetInt32(reader.GetOrdinal("id_persona"));
                            dbcmdAsist.CommandText = "select * from asistencia_evento where id_evento=" + ID + " and id_persona=" + ID_PERSONA + "";
                            readerAsist = dbcmdAsist.ExecuteReader();

                            string persona = reader.GetString(reader.GetOrdinal("nombre"));
                            chlbPersona.Items.Add(persona);

                            if (readerAsist.Read())
                            {
                                chlbPersona.SetItemChecked(i, true);
                            }
                        }
                        dbcon.Close();
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.ToString());
                    }
                    break;
                case 2:
                    try
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        IDbCommand dbcmd = dbcon.CreateCommand();
                        IDbCommand dbcmdAsist = dbcon.CreateCommand();

                        dbcmd.CommandText = "select * from persona";
                        IDataReader reader = dbcmd.ExecuteReader();
                        IDataReader readerAsist;

                        chlbPersona.Items.Clear();
                        int ID_PERSONA;

                        for (i = 0; reader.Read(); i++)
                        {
                            ID_PERSONA = reader.GetInt32(reader.GetOrdinal("id_persona"));
                            dbcmdAsist.CommandText = "select * from asistencia_evento where id_evento=" + ID + " and id_persona=" + ID_PERSONA + "";
                            readerAsist = dbcmdAsist.ExecuteReader();

                            string persona = reader.GetString(reader.GetOrdinal("nombre"));
                            chlbPersona.Items.Add(persona);

                            if (readerAsist.Read())
                            {
                                chlbPersona.SetItemChecked(i, true);
                            }
                        }
                        dbcon.Close();
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.ToString());
                    }
                    break;
            }
        }
    }
}
