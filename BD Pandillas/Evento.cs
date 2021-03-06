﻿using System;
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
    public partial class CapturarEvento : Form
    {
        Int64 ID;
        public CapturarEvento()
        {
            InitializeComponent();
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

        private void Evento_Load(object sender, EventArgs e)
        {
            try
            {
                IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = "select count(*) from evento";
                ID = (Int64)dbcmd.ExecuteScalar() + 1;
                dbcon.Close();

                txtId.Text = Convert.ToString(ID);
                cmbTipo.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex==0 || txtLugar.Text == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("DEBES INGRESAR AL MENOS UN LUGAR, UNA DESCRIPCION, Y HABER SELECCIONADO UN TIPO DE EVENTO...");
            }
            else
            {
                try
                {
                    DateTime FECHA_IN = dtpFechaIni.Value;
                    DateTime HORA_IN = dtpHoraIni.Value;
                    String hora = HORA_IN.ToString("HH:mm:ss");
                    string DESCRIPCION = txtDescripcion.Text;
                    string LUGAR = txtLugar.Text;
                    string TIPO = cmbTipo.Text;
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();

                    if (dtpFechaFin.Checked == true && dtpHoraFin.Checked == true)
                    {
                        DateTime FECHA_FIN = dtpFechaFin.Value;
                        DateTime HORA_FIN = dtpHoraFin.Value;
                        //DateTime HORA_FIN = Convert.ToDateTime(dtpHoraFin.Value.ToShortTimeString()); Probar así, verificar el valor en la base de datos
                        if (txtInscripcion.Text != "")
                        {
                            double INSCRIPCION = Convert.ToDouble(txtInscripcion.Text);
                            dbcmd.CommandText = "insert into evento (id_evento,fecha_in,hora_in,fecha_fin,hora_fin,descripcion,lugar,tipo,inscripcion) values(" + ID + ",'" + FECHA_IN.ToShortDateString() + "','" + HORA_IN.ToString("HH:mm:ss") + "','" + FECHA_FIN.ToShortDateString() + "','" + HORA_FIN.ToString("HH:mm:ss") + "','" + DESCRIPCION + "','" + LUGAR + "','" + TIPO + "'," + INSCRIPCION + ")";
                        }
                        else
                        {
                            dbcmd.CommandText = "insert into evento (id_evento,fecha_in,hora_in,fecha_fin,hora_fin,descripcion,lugar,tipo) values(" + ID + ",'" + FECHA_IN.ToShortDateString() + "','" + HORA_IN.ToString("HH:mm:ss") + "','" + FECHA_FIN.ToShortDateString() + "','" + HORA_FIN.ToString("HH:mm:ss") + "','" + DESCRIPCION + "','" + LUGAR + "','" + TIPO + "')";
                        }
                    }
                    else if (dtpFechaFin.Checked == true)
                    {
                        DateTime FECHA_FIN = dtpFechaFin.Value;
                        if (txtInscripcion.Text != "")
                        {
                            double INSCRIPCION = Convert.ToDouble(txtInscripcion.Text);
                            dbcmd.CommandText = "insert into evento (id_evento,fecha_in,hora_in,fecha_fin,descripcion,lugar,tipo,monto_inscripcion) values(" + ID + ",'" + FECHA_IN.ToShortDateString() + "','" + HORA_IN.ToString("HH:mm:ss") + "','" + FECHA_FIN.ToShortDateString() + "','" + DESCRIPCION + "','" + LUGAR + "','" + TIPO + "'," + INSCRIPCION + ")";
                        }
                        else
                        {
                            dbcmd.CommandText = "insert into evento (id_evento,fecha_in,hora_in,fecha_fin,descripcion,lugar,tipo) values(" + ID + ",'" + FECHA_IN.ToShortDateString() + "','" + HORA_IN.ToString("HH:mm:ss") + "','" + FECHA_FIN.ToShortDateString() + "','" + DESCRIPCION + "','" + LUGAR + "','" + TIPO + "')";
                        }
                    }
                    else if (dtpHoraFin.Checked == true)
                    {
                        DateTime HORA_FIN = dtpHoraFin.Value;
                        if (txtInscripcion.Text != "")
                        {
                            double INSCRIPCION = Convert.ToDouble(txtInscripcion.Text);
                            dbcmd.CommandText = "insert into evento (id_evento,fecha_in,hora_in,hora_fin,descripcion,lugar,tipo,monto_inscripcion) values(" + ID + ",'" + FECHA_IN.ToShortDateString() + "','" + HORA_IN.ToString("HH:mm:ss") + "','" + HORA_FIN.ToString("HH:mm:ss") + "','" + DESCRIPCION + "','" + LUGAR + "','" + TIPO + "'," + INSCRIPCION + ")";
                        }
                        else
                        {
                            dbcmd.CommandText = "insert into evento (id_evento,fecha_in,hora_in,hora_fin,descripcion,lugar,tipo) values(" + ID + ",'" + FECHA_IN.ToShortDateString() + "','" + HORA_IN.ToString("HH:mm:ss") + "','" + HORA_FIN.ToString("HH:mm:ss") + "','" + DESCRIPCION + "','" + LUGAR + "','" + TIPO + "')";
                        }
                    }
                    else
                    {
                        if (txtInscripcion.Text != "")
                        {
                            int INSCRIPCION = Convert.ToInt16(txtInscripcion.Text);
                            dbcmd.CommandText = "insert into evento (id_evento,fecha_in,hora_in,descripcion,lugar,tipo,monto_inscripcion) values(" + ID + ",'" + FECHA_IN.ToShortDateString() + "','" + HORA_IN.ToString("HH:mm:ss") + "','" + DESCRIPCION + "','" + LUGAR + "','" + TIPO + "'," + INSCRIPCION + ")";
                        }
                        else
                        {
                            dbcmd.CommandText = "insert into evento (id_evento,fecha_in,hora_in,descripcion,lugar,tipo) values(" + ID + ",'" + FECHA_IN.ToShortDateString() + "','" + HORA_IN.ToString("HH:mm:ss") + "','" + DESCRIPCION + "','" + LUGAR + "','" + TIPO + "')";
                        }
                    }

                    IDataReader reader = dbcmd.ExecuteReader();

                    dbcmd.CommandText = "select count(*) from evento";
                    ID = (Int64)dbcmd.ExecuteScalar() + 1;

                    txtId.Text = Convert.ToString(ID);
                    cmbTipo.SelectedIndex = 0;
                    dtpFechaFin.Checked = false;
                    txtDescripcion.Text = "";
                    txtLugar.Text = "";

                    MessageBox.Show("Registro Guardado correctamente");
                    dbcon.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show("error.....\n\n" + msg.ToString());
                }
            }
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaFin.Checked == false)
            {
                dtpHoraFin.Checked = false;
            }
        }
    }
}
