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
    public partial class ModificarEvento : Form
    {
        Int64 ID;
        public ModificarEvento()
        {
            InitializeComponent();
        }
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DEL EVENTO QUE QUIERES MODIFICAR");
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

                        dbcmd.CommandText = "select * from evento where id_evento=" + ID + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            cmbTipo.Text = reader.GetString(reader.GetOrdinal("tipo"));
                            dtpFechaIni.Value = reader.GetDateTime(reader.GetOrdinal("fecha_in"));
                            dtpHoraIni.Value = Convert.ToDateTime(reader.GetDateTime(reader.GetOrdinal("Hora_in")).ToShortTimeString());

                            try
                            {
                                dtpFechaFin.Value = reader.GetDateTime(reader.GetOrdinal("fecha_fin"));
                                dtpFechaFin.Checked = true;
                            }
                            catch (Exception)
                            {
                                dtpFechaFin.Value = DateTime.Today;
                                dtpFechaFin.Checked = false;
                            }
                            try
                            {
                                dtpHoraFin.Value = Convert.ToDateTime(reader.GetDateTime(reader.GetOrdinal("hora_fin")).ToShortTimeString());
                                dtpHoraFin.Checked = true;
                            }
                            catch (Exception)
                            {
                                dtpHoraFin.Value = DateTime.Today;
                                dtpHoraFin.Checked = false;
                            }

                            txtDescripcion.Text = reader.GetString(reader.GetOrdinal("descripcion"));
                            txtLugar.Text = reader.GetString(reader.GetOrdinal("lugar"));

                            try
                            {
                                txtRetiro.Text = Convert.ToString(reader.GetInt32(reader.GetOrdinal("numero_ret")));
                            }
                            catch (Exception)
                            {
                                txtRetiro.Text = "";
                            }
                            try
                            {
                                txtInscripcion.Text = Convert.ToString(reader.GetDouble(reader.GetOrdinal("monto_inscripcion")));
                            }
                            catch (Exception)
                            {
                                txtInscripcion.Text = "";
                            }

                            cmbTipo.Enabled = true;
                            dtpFechaIni.Enabled = true;
                            dtpHoraIni.Enabled = true;
                            dtpFechaFin.Enabled = true;
                            dtpHoraFin.Enabled = true;
                            txtLugar.Enabled = true;
                            txtDescripcion.Enabled = true;

                            txtId.Clear();

                            dbcon.Close();

                            txtId.Enabled = false;

                            if (cmbTipo.SelectedIndex == 1)
                            {
                                txtRetiro.Enabled = true;
                                txtInscripcion.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("REGISTRO NO ENCONTRADO......");

                            cmbTipo.Text = "";
                            dtpFechaIni.Value = DateTime.Today;
                            dtpHoraIni.Value = DateTime.Today;
                            dtpFechaFin.Value = DateTime.Today;
                            dtpHoraFin.Value = DateTime.Today;
                            txtDescripcion.Text = "";
                            txtLugar.Text = "";
                            txtRetiro.Text = "";
                            txtInscripcion.Text = "";

                            dbcon.Close();
                        }
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.ToString());
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

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                txtDescripcion.Text = txtDescripcion.Text.Trim();
                txtLugar.Text = txtLugar.Text.Trim();
                txtRetiro.Text = txtRetiro.Text.Trim();
                txtInscripcion.Text = txtInscripcion.Text.Trim();

                

                if (txtDescripcion.Text != ""&&txtLugar.Text!="")
                {
                    if (txtRetiro.Text != "" || cmbTipo.SelectedIndex != 1)
                    {
                        try
                        {
                            NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                            "Database=BD_Pandillas;" +
                            "User ID=mags;");
                            dbcon.Open();

                            string TIPO = cmbTipo.Text;
                            DateTime FECHA_IN = dtpFechaIni.Value;
                            DateTime HORA_IN = dtpHoraIni.Value;
                            string DESCRIPCION = txtDescripcion.Text;
                            string LUGAR = txtLugar.Text;

                            string queryUp;

                            if (txtRetiro.Text != "")
                            {
                                int RETIRO = Convert.ToInt16(txtRetiro.Text);
                                if (txtInscripcion.Text != "")
                                {
                                    double INSCRIPCION = Convert.ToDouble(txtInscripcion.Text);
                                    if (dtpFechaFin.Checked == true)
                                    {
                                        DateTime FECHA_FIN = dtpFechaFin.Value;
                                        if (dtpHoraFin.Checked == true)
                                        {
                                            DateTime HORA_FIN = dtpFechaFin.Value;
                                            HORA_FIN.ToShortDateString();
                                            queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',fecha_fin='" + FECHA_FIN.ToShortDateString() + "',hora_fin='" + HORA_FIN.ToString("HH:mm:ss") + "',descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=" + RETIRO + ",tipo='" + TIPO + "',monto_inscripcion=" + INSCRIPCION + " where id_evento=" + ID + "";
                                        }
                                        else
                                        {
                                            queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',fecha_fin='" + FECHA_FIN.ToShortDateString() + "',hora_fin=null,descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=" + RETIRO + ",tipo='" + TIPO + "',monto_inscripcion=" + INSCRIPCION + " where id_evento=" + ID + "";
                                        }
                                    }
                                    else if (dtpHoraFin.Checked == true)
                                    {
                                        DateTime HORA_FIN = dtpFechaFin.Value;
                                        HORA_FIN.ToShortDateString();
                                        queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',hora_fin='" + HORA_FIN.ToString("HH:mm:ss") + "',descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=" + RETIRO + ",tipo='" + TIPO + "',monto_inscripcion=" + INSCRIPCION + " where id_evento=" + ID + "";
                                    }
                                    else
                                    {
                                        queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',fecha_fin=null,hora_fin=null,descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=" + RETIRO + ",tipo='" + TIPO + "',monto_inscripcion=" + INSCRIPCION + " where id_evento=" + ID + "";
                                    }
                                }
                                else
                                {
                                    if (dtpFechaFin.Checked == true)
                                    {
                                        DateTime FECHA_FIN = dtpFechaFin.Value;
                                        if (dtpHoraFin.Checked == true)
                                        {
                                            DateTime HORA_FIN = dtpFechaFin.Value;
                                            HORA_FIN.ToShortDateString();
                                            queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',fecha_fin='" + FECHA_FIN.ToShortDateString() + "',hora_fin='" + HORA_FIN.ToString("HH:mm:ss") + "',descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=" + RETIRO + ",tipo='" + TIPO + "',monto_inscripcion=null where id_evento=" + ID + "";
                                        }
                                        else
                                        {
                                            queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',fecha_fin='" + FECHA_FIN.ToShortDateString() + "',hora_fin=null,descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=" + RETIRO + ",tipo='" + TIPO + "',monto_inscripcion=null where id_evento=" + ID + "";
                                        }
                                    }
                                    else if (dtpHoraFin.Checked == true)
                                    {
                                        DateTime HORA_FIN = dtpFechaFin.Value;
                                        HORA_FIN.ToShortDateString();
                                        queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',hora_fin='" + HORA_FIN.ToString("HH:mm:ss") + "',descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=" + RETIRO + ",tipo='" + TIPO + "' where id_evento=" + ID + "";
                                    }
                                    else
                                    {
                                        queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',fecha_fin=null,hora_fin=null,descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=" + RETIRO + ",tipo='" + TIPO + "',monto_inscripcion=null where id_evento=" + ID + "";
                                    }
                                }
                            }
                            else
                            {
                                if (dtpFechaFin.Checked == true)
                                {
                                    DateTime FECHA_FIN = dtpFechaFin.Value;
                                    if (dtpHoraFin.Checked == true)
                                    {
                                        DateTime HORA_FIN = dtpFechaFin.Value;
                                        HORA_FIN.ToShortDateString();
                                        queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',fecha_fin='" + FECHA_FIN.ToShortDateString() + "',hora_fin='" + HORA_FIN.ToString("HH:mm:ss") + "',descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=null,tipo='" + TIPO + "',monto_inscripcion=null where id_evento=" + ID + "";
                                    }
                                    else
                                    {
                                        queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',fecha_fin='" + FECHA_FIN.ToShortDateString() + "',hora_fin=null,descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=null,tipo='" + TIPO + "',monto_inscripcion=null where id_evento=" + ID + "";
                                    }
                                }
                                else if (dtpHoraFin.Checked == true)
                                {
                                    DateTime HORA_FIN = dtpFechaFin.Value;
                                    HORA_FIN.ToShortDateString();
                                    queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',hora_fin='" + HORA_FIN.ToString("HH:mm:ss") + "',descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',tipo='" + TIPO + "' where id_evento=" + ID + "";
                                }
                                else
                                {
                                    queryUp = "update evento set fecha_in='" + FECHA_IN.ToShortDateString() + "',hora_in='" + HORA_IN.ToString("HH:mm:ss") + "',fecha_fin=null,hora_fin=null,descripcion='" + DESCRIPCION + "',lugar='" + LUGAR + "',numero_ret=null,tipo='" + TIPO + "',monto_inscripcion=null where id_evento=" + ID + "";
                                }
                            }

                            NpgsqlCommand cmdUp = new NpgsqlCommand(queryUp, dbcon);
                            cmdUp.ExecuteNonQuery();

                            dbcon.Close();

                            MessageBox.Show("Registro Modificado correctamente");

                            cmbTipo.Text = "";
                            dtpFechaIni.Value = DateTime.Today;
                            dtpHoraIni.Value = DateTime.Today;
                            dtpFechaFin.Value = DateTime.Today;
                            dtpHoraFin.Value = DateTime.Today;
                            txtDescripcion.Text = "";
                            txtLugar.Text = "";
                            txtRetiro.Text = "";
                            txtInscripcion.Text = "";

                            cmbTipo.Enabled = false;
                            dtpFechaIni.Enabled = false;
                            dtpHoraIni.Enabled = false;
                            dtpFechaFin.Enabled = false;
                            dtpHoraFin.Enabled = false;
                            txtDescripcion.Enabled = false;
                            txtLugar.Enabled = false;
                            txtRetiro.Enabled = false;
                            txtInscripcion.Enabled = false;

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
                        MessageBox.Show("Error: No puedes dejar un evento de tipo pandilla, sin número de Retiro =P");
                    }
                }
                else
                {
                    MessageBox.Show("Error: No puedes dejar el evento sin lugar o descripcion");
                }
            }
            else
            {
                MessageBox.Show("Ingresa el ID del evento que quieres modificar y presiona enter para que puedas visualizar los datos del evento y modificarlos ");
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == 1)
            {
                txtRetiro.Enabled = true;
                txtInscripcion.Enabled = true;
            }
            else
            {
                txtRetiro.Enabled = false;
                txtInscripcion.Enabled = false;
                txtRetiro.Text = "";
                txtInscripcion.Text = "";
            }
        }
    }
}
