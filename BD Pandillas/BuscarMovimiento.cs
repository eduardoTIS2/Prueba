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
    public partial class BuscarMovimiento : Form
    {
        public BuscarMovimiento()
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string id=txtId.Text.Trim();
            if (id == "")
            {
                MessageBox.Show("Debes introducir en el único campo disponible, el id del reporte a consultar");
            }
            else
            {
                try
                {
                    int ID = Convert.ToInt32(id);
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;"
                        + "Database=BD_Pandillas;" +
                    "User ID=mags;");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();

                    dbcmd.CommandText = "select r.id_persona,p.nombre,case when id_evento is null then 'Ninguno' else "+
                        "(select descripcion from evento where id_evento=(select id_evento from reporte_financiero where id_reporte="+ID+")) "+
                        "end as evento,case when id_evento is null then 'Ninguno' else " +
                        "(select tipo from evento where id_evento=(select id_evento from reporte_financiero where id_reporte=" + ID + ")) " +
                        "end as tipo_ev,o.tipo as tipo_op,o.descripcion as operacion,monto,fecha " +
                        "from reporte_financiero r,persona p,operacion o where id_reporte="+ID+" and r.id_persona=p.id_persona "+
                        "and r.id_oper=o.id_oper";

                    IDataReader reader = dbcmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtIdPersona.Text = Convert.ToString(reader.GetInt32(reader.GetOrdinal("id_persona")));
                        txtNombre.Text = reader.GetString(reader.GetOrdinal("nombre"));
                        txtMonto.Text = Convert.ToString(reader.GetDouble(reader.GetOrdinal("monto")));
                        txtFecha.Text = reader.GetDateTime(reader.GetOrdinal("fecha")).ToShortDateString();
                        txtTipoEvento.Text = reader.GetString(reader.GetOrdinal("tipo_ev"));
                        txtEvento.Text = reader.GetString(reader.GetOrdinal("evento"));
                        txtTipoOper.Text = reader.GetString(reader.GetOrdinal("tipo_op"));
                        txtOper.Text = reader.GetString(reader.GetOrdinal("operacion"));
                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show("Error...\n\n" + exc.ToString());
                }
            }
        }
    }
}
