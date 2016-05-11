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
    public partial class BuscarActividad : Form
    {
        public BuscarActividad()
        {
            InitializeComponent();
        }

        int ID_EVENT;
        int ID_PERS;
        string TipoEv;
        DataTable tabla = new DataTable();

        private void txtIdEvento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtIdEvento.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DEL EVENTO AL QUE AGREGARÁS ACTIVIDADES");
                    txtIdEvento.Focus();
                }
                else
                {
                    try
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        ID_EVENT = Convert.ToInt32(txtIdEvento.Text);
                        IDbCommand dbcmd = dbcon.CreateCommand();

                        dbcmd.CommandText = "select descripcion,tipo from evento where id_evento=" + ID_EVENT + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtDescripcionEv.Text = reader.GetString(reader.GetOrdinal("descripcion"));
                            TipoEv = reader.GetString(reader.GetOrdinal("tipo"));

                            txtIdEvento.Enabled = false;
                            txtIdPersona.Enabled = true;

                            txtIdPersona.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No existe el evento con el id ingresado");
                            txtIdEvento.Focus();
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("error... \n\n" + exc.Message);
                    }
                }
            }
        }

        private void txtIdPersona_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtIdPersona.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DE LA PERSONA A LA CUAL AGREGARÁS ACTIVIDADES");
                    txtIdPersona.Focus();
                }
                else
                {
                    try
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        ID_PERS = Convert.ToInt32(txtIdPersona.Text);
                        IDbCommand dbcmd = dbcon.CreateCommand();
                        IDbCommand dbcmd2 = dbcon.CreateCommand();

                        dbcmd.CommandText = "select nombre from persona where id_persona=" + ID_PERS + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtNombre.Text = reader.GetString(reader.GetOrdinal("nombre"));

                            txtIdPersona.Enabled = false;
                            btnBuscar.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("No existe la persona con el id ingresado");
                            txtIdPersona.Focus();
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("error... \n\n" + exc.ToString());
                    }
                }
            }
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;"
                        + "Database=BD_Pandillas;" +
                    "User ID=mags;");

                NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select a.tipo,a.descripcion,a.hora_in,a.hora_fin from actividad a "+
                    "join evento on evento.id_evento=a.id_evento where evento.tipo='" + TipoEv + "' and id_persona="+ID_PERS+"", conexion);

                datosConsulta.Fill(tabla);

                dgvActividades.DataSource = tabla.DefaultView;
                dgvActividades.Columns["hora_in"].DefaultCellStyle.Format = "HH:mm:ss";
                dgvActividades.Columns["hora_fin"].DefaultCellStyle.Format = "HH:mm:ss";

                btnBuscar.Enabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("error..." + exc.ToString());
            }
        }
    }
}
