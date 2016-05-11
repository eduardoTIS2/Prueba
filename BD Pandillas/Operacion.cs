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
    public partial class CapturarOperacion : Form
    {
        Int64 ID;
        public CapturarOperacion()
        {
            InitializeComponent();
        }

        private void CapturarOperacion_Load(object sender, EventArgs e)
        {
            try
            {
                IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = "select count(*) from operacion";
                ID = (Int64)dbcmd.ExecuteScalar() + 1;
                dbcon.Close();

                txtIdOper.Text = Convert.ToString(ID);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal f = new Principal();
            f.Show();
            this.Hide();
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || cmbTipo.SelectedIndex == 0 ||txtDescripcion.Text=="")
            {
                MessageBox.Show("DEBES HABER INGRESADO UN ID DE PERSONA VÁLIDO, UNA DESCRIPCIÓN Y UN TIPO DE OPERACIÓN...");
            }
            else
            {
                try
                {
                    string ID_PERSONA = txtId.Text;
                    string DESCRIPCION = txtDescripcion.Text;
                    string TIPO = cmbTipo.Text;
                    string STATUS = "Activo";
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();

                    dbcmd.CommandText = "insert into operacion values(" + ID + "," + ID_PERSONA + ",'" + DESCRIPCION + "','" + TIPO + "','" + STATUS + "')";

                    IDataReader reader = dbcmd.ExecuteReader();

                    dbcmd.CommandText = "select count(*) from operacion";
                    ID = (Int64)dbcmd.ExecuteScalar() + 1;

                    dbcon.Close();

                    txtIdOper.Text = Convert.ToString(ID);
                    txtId.Text = "";
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    cmbTipo.SelectedIndex = 0;

                    txtNombre.Enabled = false;
                    txtDescripcion.Enabled = false;
                    cmbTipo.Enabled = false;
                    txtId.Enabled = true;
                    txtId.Focus();

                    MessageBox.Show("Registro Guardado correctamente");
                }
                catch (Exception msg)
                {
                    MessageBox.Show("error.....\n\n" + msg.ToString());
                }
            }
        }
        private void txt_Id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DE LA PERSONA QUE CREA LA OPERACIÓN, ES DECIR, EL TUYO =P...");
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
                        int n = Convert.ToInt32(txtId.Text);
                        IDbCommand dbcmd = dbcon.CreateCommand();

                        dbcmd.CommandText = "select * from persona where id_persona=" + n + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtNombre.Text = reader.GetString(reader.GetOrdinal("nombre"));
                            dbcon.Close();
                            txtDescripcion.Enabled = true;
                            txtDescripcion.Focus();
                            cmbTipo.Enabled = true;
                            txtId.Enabled = false;
                        }
                        else
                        {
                            txtNombre.Text = "";
                            txtId.Text = "";
                            MessageBox.Show("Persona no encontrada, no te sabes tu id???");
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
