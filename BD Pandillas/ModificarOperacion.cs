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
    public partial class ModificarOperacion : Form
    {
        int ID;
        public ModificarOperacion()
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
                        ID = Convert.ToInt32(txtId.Text);
                        IDbCommand dbcmd = dbcon.CreateCommand();

                        dbcmd.CommandText = "select * from persona where id_persona=" + ID + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtNombre.Text = reader.GetString(reader.GetOrdinal("nombre"));
                            dbcon.Close();

                            txtIdOper.Enabled = true;
                            txtIdOper.Focus();
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

        private void txtIdOper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtIdOper.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DE LA OPERACIÓN QUE QUIERES MODIFICAR =P...");
                    txtIdOper.Focus();
                }
                else
                {
                    try
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        int n = Convert.ToInt32(txtIdOper.Text);
                        IDbCommand dbcmd = dbcon.CreateCommand();

                        dbcmd.CommandText = "select * from operacion where id_oper=" + n + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtDescripcion.Text = reader.GetString(reader.GetOrdinal("descripcion"));
                            cmbTipo.Text = reader.GetString(reader.GetOrdinal("tipo"));
                            cmbStatus.Text = reader.GetString(reader.GetOrdinal("status"));
                            dbcon.Close();

                            txtDescripcion.Enabled = true;
                            cmbTipo.Enabled = true;
                            cmbStatus.Enabled = true;

                            txtIdOper.Enabled = false;
                        }
                        else
                        {
                            txtIdOper.Text = "";
                            txtDescripcion.Text = "";
                            cmbTipo.Text = "";
                            cmbStatus.Text = "";

                            MessageBox.Show("Error: Ésa operación no está registrada");
                        }
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.ToString());
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                if (txtIdOper.Text != "")
                {
                    if (txtDescripcion.Text != "")
                    {
                        try
                        {
                            NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                            "Database=BD_Pandillas;" +
                            "User ID=mags;");
                            dbcon.Open();

                            ID = Convert.ToInt32(txtId.Text);
                            int ID_OPER = Convert.ToInt32(txtIdOper.Text);
                            string DESCRIPCION = txtDescripcion.Text;
                            string TIPO = cmbTipo.Text;
                            string STATUS = cmbStatus.Text;
                            string queryUp;

                            queryUp = "update operacion set id_persona=" + ID + ",descripcion='" + DESCRIPCION + "',tipo='" + TIPO + "',status='" + STATUS + "' where id_oper=" + ID_OPER + "";

                            NpgsqlCommand cmdUp = new NpgsqlCommand(queryUp, dbcon);
                            cmdUp.ExecuteNonQuery();

                            dbcon.Close();

                            MessageBox.Show("Registro Modificado correctamente");

                            txtId.Text = "";
                            txtNombre.Text = "";
                            txtIdOper.Text = "";
                            txtDescripcion.Text = "";
                            cmbTipo.Text = "";
                            cmbStatus.Text = "";

                            txtIdOper.Enabled = false;
                            txtDescripcion.Enabled = false;
                            cmbTipo.Enabled = false;
                            cmbStatus.Enabled = false;

                            txtId.Enabled = true;
                            ID = 0;
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No puedes dejar a la operacion sin descripción, regrésale la que tenía o cámbiasela pero toda operación tiene derecho a una descripción =P");
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa el ID de la operación que quieres modificar y presiona enter para que puedas visualizar los datos de la operación y poder modificarlos ");
                }
            }
            else
            {
                MessageBox.Show("Ingresa el ID de la persona realizará la modificación (el tuyo) y presiona <enter> ");
            }
        }
    }
}
