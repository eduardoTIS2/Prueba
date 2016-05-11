using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Npgsql;

namespace BD_Pandillas
{
    public partial class Principal : Form
    {
        Process proceso = new Process();
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            proceso.StartInfo = new ProcessStartInfo("Arranque.bat");
            proceso.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            proceso.Start();
            pbx_1.Image=new Bitmap("dioses.jpg");
        }

        private void capturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapturarPersona per = new CapturarPersona();
            per.Show();
            this.Hide();
        }

        private void capturarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CapturarOperacion op = new CapturarOperacion();
            op.Show();
            this.Hide();
        }

        private void capturarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CapturarEvento ev = new CapturarEvento();
            ev.Show();
            this.Hide();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarPersona mp = new MostrarPersona();
            mp.Show();
            this.Hide();
        }

        private void mostrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MostrarEventos me = new MostrarEventos();
            me.Show();
            this.Hide();
        }

        private void mostrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MostrarOperaciones mo = new MostrarOperaciones();
            mo.Show();
            this.Hide();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarPersona bp = new BuscarPersona();
            bp.Show();
            this.Hide();
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BuscarEvento be = new BuscarEvento();
            be.Show();
            this.Hide();
        }

        private void buscarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BuscarOperacion bo = new BuscarOperacion();
            bo.Show();
            this.Hide();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarPersona modp = new ModificarPersona();
            modp.Show();
            this.Hide();
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModificarEvento modev = new ModificarEvento();
            modev.Show();
            this.Hide();
        }

        private void modificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModificarOperacion modop = new ModificarOperacion();
            modop.Show();
            this.Hide();
        }

        private void tomarAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapturarAsistencia capas = new CapturarAsistencia();
            capas.Show();
            this.Hide();
        }

        private void consultarAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarAsistencia mosas = new MostrarAsistencia();
            mosas.Show();
            this.Hide();
        }

        private void asistenciaPorPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsistenciaPersona peras = new AsistenciaPersona();
            peras.Show();
            this.Hide();
        }

        private void capturarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CapturarMovimiento capmov = new CapturarMovimiento();
            capmov.Show();
            this.Hide();
        }

        private void mostrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MostrarMovimiento mosmov = new MostrarMovimiento();
            mosmov.Show();
            this.Hide();
        }

        private void consultarSaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IDbConnection dbcon = new NpgsqlConnection("server=localhost;database=BD_Pandillas;user id=mags");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();

                IDataReader reader;
                dbcmd.CommandText = "select saldo from capital";

                reader = dbcmd.ExecuteReader();

                if (reader.Read())
                {
                    double saldo = reader.GetDouble(reader.GetOrdinal("saldo"));
                    MessageBox.Show("El saldo actual son:   $ " + saldo);
                }
                else
                {
                    MessageBox.Show("No se ha capturado un saldo inicial");
                }
            }
            catch
            {
            }
        }

        private void capturarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CapturarActividad capact = new CapturarActividad();
            capact.Show();
            this.Hide();
        }

        private void buscarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BuscarMovimiento busmov = new BuscarMovimiento();
            busmov.Show();
            this.Hide();
        }

        private void mostrarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            BuscarActividad busact = new BuscarActividad();
            busact.Show();
            this.Hide();
        }

    }
}
