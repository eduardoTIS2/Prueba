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
    public partial class MostrarMovimiento : Form
    {
        DataTable tabla = new DataTable();

        public MostrarMovimiento()
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
            try
            {
                tabla.Rows.Clear();
                tabla.Columns.Clear();
                NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;"
                        + "Database=BD_Pandillas;" +
                    "User ID=mags;");
                NpgsqlDataAdapter datosConsulta;
                switch (cmbTipo.SelectedIndex)
                {
                    case 1: 
                    case 2:
                    case 3: IDbConnection dbcon = new NpgsqlConnection("Server=localhost;"
                                + "Database=BD_Pandillas;" +
                            "User ID=mags;");
                        dbcon.Open();
                        IDbCommand dbcmd = dbcon.CreateCommand();
                        dbcmd.CommandText = "select id_reporte,id_evento from reporte_financiero join operacion on operacion.id_oper=reporte_financiero.id_oper where operacion.tipo='" + cmbTipo.SelectedItem.ToString() + "'";
                        IDataReader reader = dbcmd.ExecuteReader();
                        int ID;
                        int ID_EVENTO;
                        while (reader.Read())
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("id_reporte"));
                            ID_EVENTO = 0;
                            try
                            {
                                ID_EVENTO = reader.GetInt32(reader.GetOrdinal("id_evento"));
                            }
                            catch
                            {
                            }
                            //MessageBox.Show("El id del reporte es: "+ID);
                            datosConsulta = new NpgsqlDataAdapter("select id_reporte,case when id_evento is null then 'Ninguno' else (select descripcion from evento where id_evento="+ID_EVENTO+") end as evento,"
                            +"operacion.descripcion as operacion,persona.nombre as registrado_por,monto,fecha from reporte_financiero,operacion,persona"
                            +" where id_reporte="+ID+" and operacion.id_oper=reporte_financiero.id_oper and persona.id_persona=reporte_financiero.id_persona",conexion);
                            datosConsulta.Fill(tabla);
                            dtgReporte.DataSource = tabla.DefaultView;
                        }
                        dbcon.Close();
                        break;
                    case 4: dbcon = new NpgsqlConnection("Server=localhost;"
                                + "Database=BD_Pandillas;" +
                            "User ID=mags;");
                        dbcon.Open();
                        dbcmd = dbcon.CreateCommand();
                        dbcmd.CommandText = "select id_reporte,id_evento from reporte_financiero";
                        reader = dbcmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("id_reporte"));
                            ID_EVENTO = 0;
                            try
                            {
                                ID_EVENTO = reader.GetInt32(reader.GetOrdinal("id_evento"));
                            }
                            catch
                            {
                            }
                            //MessageBox.Show("El id del reporte es: "+ID);
                            datosConsulta = new NpgsqlDataAdapter("select id_reporte,case when id_evento is null then 'Ninguno' else (select descripcion from evento where id_evento=" + ID_EVENTO + ") end as evento,"
                            + "operacion.descripcion as operacion,operacion.tipo as tipo_operacion,persona.nombre as registrado_por,monto,fecha from reporte_financiero,operacion,persona"
                            + " where id_reporte=" + ID + " and operacion.id_oper=reporte_financiero.id_oper and persona.id_persona=reporte_financiero.id_persona", conexion);
                            datosConsulta.Fill(tabla);
                            dtgReporte.DataSource = tabla.DefaultView;
                        }
                        dbcon.Close();
                        break;
                }
                /*datosConsulta = new NpgsqlDataAdapter("select * from evento", conexion);

                datosConsulta.Fill(tabla);

                //Las columnas de horas no se muestran en un formato adecuado, ver como solucionarlo

                dtgReporte.DataSource = tabla.DefaultView;*/
            }
            catch (Exception exc)
            {
                MessageBox.Show("error..." + exc.ToString());
            }
        }

        private void MostrarMovimiento_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
        }
    }
}
