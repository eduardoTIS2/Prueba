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
    public partial class BuscarEvento : Form
    {
        public BuscarEvento()
        {
            InitializeComponent();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int bandera = 0;
                int ID = Convert.ToInt32(txtId.Text);
                IDbConnection dbcon = new NpgsqlConnection("Server=localhost;"
                    + "Database=BD_Pandillas;" +
                "User ID=mags;");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = "select * from evento where id_evento=" + ID + "";
                IDataReader reader = dbcmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTipo.Text = reader.GetString(reader.GetOrdinal("tipo"));
                    dtpFechaIni.Value = reader.GetDateTime(reader.GetOrdinal("fecha_in"));
                    dtpHoraIni.Value = Convert.ToDateTime(reader.GetDateTime(reader.GetOrdinal("hora_in")).ToShortTimeString());
                    try
                    {
                        dtpFechaFin.Value = reader.GetDateTime(reader.GetOrdinal("fecha_fin"));
                    }
                    catch (Exception)
                    {
                        dtpFechaFin.Value = DateTime.Today;
                    }
                    try
                    {
                        dtpHoraFin.Value = Convert.ToDateTime(reader.GetDateTime(reader.GetOrdinal("hora_fin")).ToShortTimeString());
                    }
                    catch (Exception)
                    {
                        dtpHoraFin.Value = DateTime.Today;
                    }

                    txtDescripcion.Text = reader.GetString(reader.GetOrdinal("descripcion"));
                    txtLugar.Text = reader.GetString(reader.GetOrdinal("lugar"));

                    try
                    {
                        txtInscripcion.Text = Convert.ToString(reader.GetDouble(reader.GetOrdinal("monto_inscripcion")));
                    }
                    catch (Exception)
                    {
                        txtInscripcion.Text = "Se desconoce...";
                    }

                    bandera = 1;

                    txtId.Clear();
                }
                dbcon.Close();
                if (bandera == 0)
                {
                    MessageBox.Show("REGISTRO NO ENCONTRADO......");

                    txtTipo.Text = "";
                    dtpFechaIni.Value = DateTime.Today;
                    dtpHoraIni.Value = DateTime.Today;
                    dtpFechaFin.Value = DateTime.Today;
                    dtpHoraFin.Value = DateTime.Today;
                    txtDescripcion.Text = "";
                    txtLugar.Text = "";
                    txtInscripcion.Text = "";
                }

            }
            catch (Exception msg)
            {
                MessageBox.Show("error.....\n\n" + msg.ToString());
            }
        }
    }
}
