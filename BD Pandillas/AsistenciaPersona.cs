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
    public partial class AsistenciaPersona : Form
    {
        int ID;
        public AsistenciaPersona()
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

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            switch (cmbTipo.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    try
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        IDbCommand dbcmd = dbcon.CreateCommand();
                        IDbCommand dbcmdAsist = dbcon.CreateCommand();

                        dbcmd.CommandText = "select * from evento where tipo='" + cmbTipo.Text + "'";
                        IDataReader reader = dbcmd.ExecuteReader();
                        IDataReader readerAsist;

                        chlbEvento.Items.Clear();
                        int ID_EVENTO;

                        for (i = 0; reader.Read(); i++)
                        {
                            ID_EVENTO = reader.GetInt32(reader.GetOrdinal("id_evento"));
                            dbcmdAsist.CommandText = "select * from asistencia_evento where id_evento=" + ID_EVENTO + " and id_persona=" + ID + "";
                            readerAsist = dbcmdAsist.ExecuteReader();

                            string evento = reader.GetString(reader.GetOrdinal("descripcion"));
                            chlbEvento.Items.Add(evento);

                            if (readerAsist.Read())
                            {
                                chlbEvento.SetItemChecked(i, true);
                            }
                        }
                        dbcon.Close();
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.ToString());
                    }
                    break;
                case 3:
                    try
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        IDbCommand dbcmd = dbcon.CreateCommand();
                        IDbCommand dbcmdAsist = dbcon.CreateCommand();

                        dbcmd.CommandText = "select * from evento";
                        IDataReader reader = dbcmd.ExecuteReader();
                        IDataReader readerAsist;

                        chlbEvento.Items.Clear();
                        int ID_EVENTO;

                        for (i = 0; reader.Read(); i++)
                        {
                            ID_EVENTO = reader.GetInt32(reader.GetOrdinal("id_evento"));
                            dbcmdAsist.CommandText = "select * from asistencia_evento where id_evento=" + ID_EVENTO + " and id_persona=" + ID + "";
                            readerAsist = dbcmdAsist.ExecuteReader();

                            string evento = reader.GetString(reader.GetOrdinal("descripcion"));
                            chlbEvento.Items.Add(evento);

                            if (readerAsist.Read())
                            {
                                chlbEvento.SetItemChecked(i, true);
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

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DE LA PERSONA QUE DESEAS CONSULTAR SU ASISTENCIA...");
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

                        dbcmd.CommandText = "select * from persona where id_persona=" + ID + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtTipo.Text = reader.GetString(reader.GetOrdinal("tipo"));
                            txtNombre.Text = reader.GetString(reader.GetOrdinal("nombre"));
                            dbcon.Close();

                            cmbTipo.Enabled = true;
                            cmbTipo.Focus();
                            txtId.Enabled = false;
                        }
                        else
                        {
                            txtTipo.Text = "";
                            txtNombre.Text = "";
                            txtId.Text = "";
                            MessageBox.Show("Persona no encontrado, asegúrate de que el ID de persona que ingresaste esté registrado");
                        }
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.ToString());
                    }
                }
            }
        }
    }
}
