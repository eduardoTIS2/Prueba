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
    public partial class MostrarEventos : Form
    {
        DataTable tabla = new DataTable();

        public MostrarEventos()
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

        private void MostrarEventos_Load(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;"
                        + "Database=BD_Pandillas;" +
                    "User ID=mags;");

                NpgsqlDataAdapter datosConsulta = new NpgsqlDataAdapter("select * from evento", conexion);

                datosConsulta.Fill(tabla);

                //Las columnas de horas no se muestran en un formato adecuado, ver como solucionarlo

                dtgEvento.DataSource = tabla.DefaultView;
                dtgEvento.Columns["hora_in"].DefaultCellStyle.Format = "HH:mm:ss";
                dtgEvento.Columns["hora_fin"].DefaultCellStyle.Format = "HH:mm:ss";

                /*mcalEvento.BoldedDates = new DateTime[]
                {
                    DateTime.Today.AddDays(5),
                    DateTime.Today.AddDays(8)
                };*/
            }
            catch (Exception exc)
            {
                MessageBox.Show("error..."+exc.ToString());
            }
        }
    }
}
