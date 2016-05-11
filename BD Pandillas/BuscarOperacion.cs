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
    public partial class BuscarOperacion : Form
    {
        public BuscarOperacion()
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
                dbcmd.CommandText = "select * from operacion where id_oper=" + ID + "";
                IDataReader reader = dbcmd.ExecuteReader();
                if (reader.Read())
                {
                    txtIdPersona.Text = Convert.ToString(reader.GetInt32(reader.GetOrdinal("id_persona")));
                    txtDescripcion.Text = reader.GetString(reader.GetOrdinal("descripcion"));
                    txtTipo.Text = reader.GetString(reader.GetOrdinal("tipo"));
                    txtStatus.Text = reader.GetString(reader.GetOrdinal("status"));

                    bandera = 1;

                    txtId.Clear();
                }
                dbcon.Close();
                if (bandera == 0)
                {
                    MessageBox.Show("REGISTRO NO ENCONTRADO......");

                    txtIdPersona.Text = "";
                    txtDescripcion.Text = "";
                    txtTipo.Text = "";
                    txtStatus.Text = "";
                }

            }
            catch (Exception msg)
            {
                MessageBox.Show("error.....\n\n" + msg.ToString());
            }
        }
    }
}
