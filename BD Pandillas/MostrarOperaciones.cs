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
    public partial class MostrarOperaciones : Form
    {
        DataTable tabla = new DataTable();

        public MostrarOperaciones()
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

        private void MostrarOperaciones_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tabla.Rows.Clear();
                tabla.Columns.Clear();
                IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                dbcon.Open();

                IDbCommand dbcmdOper = dbcon.CreateCommand();
                IDbCommand dbcmdPer = dbcon.CreateCommand();

                NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;"
                        + "Database=BD_Pandillas;" +
                    "User ID=mags;");

                switch (cmbTipo.SelectedIndex)
                {
                    case 1:
                    case 2:
                    case 3:
                        tabla.Columns.Add("ID_OPER");
                        tabla.Columns.Add("REGISTRADA POR");
                        tabla.Columns.Add("DESCRIPCION");
                        tabla.Columns.Add("STATUS");

                        dtgOperacion.DataSource = tabla.DefaultView;

                        dbcmdOper.CommandText = "select * from operacion where tipo='" + cmbTipo.Text + "'";
                        IDataReader readerOper = dbcmdOper.ExecuteReader();
                        IDataReader readerPer;
                        int ID_PERSONA;

                        for (int i = 0;readerOper.Read(); i++)
                        {
                            ID_PERSONA = readerOper.GetInt32(readerOper.GetOrdinal("id_persona"));
                            dbcmdPer.CommandText = "select * from persona where id_persona=" + ID_PERSONA + "";
                            readerPer = dbcmdPer.ExecuteReader();

                            readerPer.Read();

                            tabla.Rows.Add();

                            dtgOperacion.Rows[i].Cells[0].Value=Convert.ToString(readerOper.GetInt32(readerOper.GetOrdinal("id_oper")));
                            dtgOperacion.Rows[i].Cells[1].Value = readerPer.GetString(readerPer.GetOrdinal("nombre"));
                            dtgOperacion.Rows[i].Cells[2].Value=readerOper.GetString(readerOper.GetOrdinal("descripcion"));
                            dtgOperacion.Rows[i].Cells[3].Value = readerOper.GetString(readerOper.GetOrdinal("status"));
                        }

                        dtgOperacion.DataSource = tabla.DefaultView;
                        break;
                    case 4:
                        tabla.Columns.Add("ID_OPER");
                        tabla.Columns.Add("REGISTRADA POR");
                        tabla.Columns.Add("DESCRIPCION");
                        tabla.Columns.Add("TIPO");
                        tabla.Columns.Add("STATUS");

                        dtgOperacion.DataSource = tabla.DefaultView;

                        dbcmdOper.CommandText = "select * from operacion";
                        readerOper = dbcmdOper.ExecuteReader();

                        for (int i = 0;readerOper.Read(); i++)
                        {
                            ID_PERSONA = readerOper.GetInt32(readerOper.GetOrdinal("id_persona"));
                            dbcmdPer.CommandText = "select * from persona where id_persona=" + ID_PERSONA + "";
                            readerPer = dbcmdPer.ExecuteReader();

                            readerPer.Read();

                            tabla.Rows.Add();

                            dtgOperacion.Rows[i].Cells[0].Value=Convert.ToString(readerOper.GetInt32(readerOper.GetOrdinal("id_oper")));
                            dtgOperacion.Rows[i].Cells[1].Value = readerPer.GetString(readerPer.GetOrdinal("nombre"));
                            dtgOperacion.Rows[i].Cells[2].Value=readerOper.GetString(readerOper.GetOrdinal("descripcion"));
                            dtgOperacion.Rows[i].Cells[3].Value = readerOper.GetString(readerOper.GetOrdinal("tipo"));
                            dtgOperacion.Rows[i].Cells[4].Value = readerOper.GetString(readerOper.GetOrdinal("status"));
                        }

                        dtgOperacion.DataSource = tabla.DefaultView;
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
