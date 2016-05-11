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
    public partial class BuscarPersona : Form
    {
        public BuscarPersona()
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
                dbcmd.CommandText = "select * from persona where id_persona=" + ID + "";
                IDataReader reader = dbcmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNombre.Text = reader.GetString(reader.GetOrdinal("nombre"));
                    try
                    {
                        dtpFechaNac.Value = Convert.ToDateTime(reader.GetDateTime(reader.GetOrdinal("fecha_nac")));
                    }
                    catch (Exception)
                    {
                        dtpFechaNac.Value = DateTime.Today;
                    }
                    try
                    {
                        txtEdad.Text = Convert.ToString(reader.GetInt32(reader.GetOrdinal("edad")));
                    }
                    catch (Exception)
                    {
                        txtEdad.Text = "Es un misterio...";
                    }

                    txtDireccion.Text = reader.GetString(reader.GetOrdinal("direccion"));

                    try
                    {
                        txtEmail.Text = reader.GetString(reader.GetOrdinal("email"));
                    }
                    catch (Exception)
                    {
                        txtEmail.Text = "quien_sabe@yo.no.com";
                    }
                    txtTel.Text = reader.GetString(reader.GetOrdinal("tel"));
                    txtCel.Text = reader.GetString(reader.GetOrdinal("cel"));
                    txtTipo.Text = reader.GetString(reader.GetOrdinal("tipo"));
                    txtCargo.Text = reader.GetString(reader.GetOrdinal("cargo"));
                    txtStatus.Text = reader.GetString(reader.GetOrdinal("status"));

                    bandera = 1;

                    try
                    {
                        pbxPersona.Load("Imagenes\\" + ID + ".jpg");
                    }
                    catch (Exception)
                    {
                        pbxPersona.Load("Imagenes\\default.jpg");
                    }

                    txtId.Clear();
                }
                dbcon.Close();
                if (bandera == 0)
                {
                    MessageBox.Show("REGISTRO NO ENCONTRADO......");

                    pbxPersona.Load("Imagenes\\default.jpg");
                    txtNombre.Text = "";
                    dtpFechaNac.Value = DateTime.Today;
                    txtEdad.Text = "";
                    txtDireccion.Text = "";
                    txtEmail.Text = "";
                    txtTel.Text = "";
                    txtCel.Text = "";
                    txtTipo.Text = "";
                    txtCargo.Text = "";
                    txtStatus.Text = "";
                }

            }
            catch (Exception msg)
            {
                MessageBox.Show("error.....\n\n" + msg.ToString());
            }
        }

        private void BuscarPersona_Load(object sender, EventArgs e)
        {
            pbxPersona.Load("Imagenes\\default.jpg");
        }
    }
}
