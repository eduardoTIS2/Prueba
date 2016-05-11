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
    public partial class CapturarMovimiento : Form
    {
        Int64 ID;
        public CapturarMovimiento()
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

        private void CapturarMovimiento_Load(object sender, EventArgs e)
        {
            try
            {
                IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = "select count(*) from reporte_financiero";
                ID = (Int64)dbcmd.ExecuteScalar() + 1;
                dbcon.Close();

                txtId.Text = Convert.ToString(ID);
                cmbTipoEvento.SelectedIndex = 0;
                cmbTipoOper.SelectedIndex = 0;

                DateTime fechaActual = new DateTime();
                fechaActual=DateTime.Today;

                dtpFecha.Value = fechaActual;

                txtIdPersona.Focus();
            }
            catch (Exception exc)
            {
                MessageBox.Show("error.....\n\n" + exc.ToString());
            }
        }

        private void txtIdPersona_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtIdPersona.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DE LA PERSONA QUE CREA EL REPORTE, ES DECIR, EL TUYO =P...");
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

                        int n = Convert.ToInt32(txtIdPersona.Text);
                        IDbCommand dbcmd = dbcon.CreateCommand();

                        dbcmd.CommandText = "select * from persona where id_persona=" + n + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtNombre.Text = reader.GetString(reader.GetOrdinal("nombre"));
                            dbcon.Close();

                            cmbTipoOper.Enabled = true;
                            txtIdPersona.Enabled = false;
                        }
                        else
                        {
                            txtNombre.Text = "";
                            txtIdPersona.Text = "";
                            MessageBox.Show("Persona no encontrada, no te sabes tu id???");
                        }
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show("error...\n\n"+msg.ToString());
                    }
                }
            }
        }

        private void cmbTipoEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoEvento.SelectedIndex != 0)
            {
                try
                {
                    lbEvento.Items.Clear();
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                            "Database=BD_Pandillas;" +
                            "User ID=mags;");
                    dbcon.Open();

                    IDbCommand dbcmdOper = dbcon.CreateCommand();

                    dbcmdOper.CommandText = "select descripcion from evento where tipo='" + cmbTipoEvento.Text + "'";
                    IDataReader readerOper = dbcmdOper.ExecuteReader();

                    for (int i = 0; readerOper.Read(); i++)
                    {
                        lbEvento.Items.Add(readerOper.GetString(readerOper.GetOrdinal("descripcion")));
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("error.....\n\n" + exc.ToString());
                }
            }
            else
            {
                lbEvento.Items.Clear();
            }
        }

        private void cmbTipoOper_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoOper.SelectedIndex != 0)
            {
                try
                {
                    lbOper.Items.Clear();
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                            "Database=BD_Pandillas;" +
                            "User ID=mags;");
                    dbcon.Open();

                    IDbCommand dbcmdOper = dbcon.CreateCommand();

                    dbcmdOper.CommandText = "select descripcion from operacion where tipo='" + cmbTipoOper.Text + "'";
                    IDataReader readerOper = dbcmdOper.ExecuteReader();

                    for (int i = 0; readerOper.Read(); i++)
                    {
                        lbOper.Items.Add(readerOper.GetString(readerOper.GetOrdinal("descripcion")));
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("error.....\n\n" + exc.ToString());
                }
            }
            else
            {
                lbOper.Items.Clear();
            }
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            int cap = 0;
            if (txtNombre.Text == "" || txtMonto.Text == "" || cmbTipoOper.SelectedIndex == 0)
            {
                if (txtNombre.Text == "")
                {
                    MessageBox.Show("INGRESA UN ID DE QUIEN REALIZA EL REPORTE Y PRESIONA ENTER PARA VISUALIZAR SU NOMBRE...");
                }
                else if (txtMonto.Text == "" || cmbTipoOper.SelectedIndex == 0)
                {
                    if (txtMonto.Text == "" && cmbTipoOper.SelectedIndex != 0)
                    {
                        MessageBox.Show("INGRESA EL MONTO DE LA OPERACIÓN...");
                    }
                    else if (txtMonto.Text != "" && cmbTipoOper.SelectedIndex == 0)
                    {
                        MessageBox.Show("SELECCIONA EL TIPO DE OPERACIÓN, SI NO EXISTE EL QUE QUIERES, CRÉALO PRIMERO ;)...");
                    }
                    else
                    {
                        MessageBox.Show("INGRESA EL MONTO Y SELECCIONA UN TIPO DE OPERACIÓN...");
                    }
                }
            }
            else
            {
                try
                {
                    int ID_PERSONA=Convert.ToInt32(txtIdPersona.Text);
                    double MONTO = Convert.ToDouble(txtMonto.Text);
                    String FECHA=dtpFecha.Value.ToShortDateString();

                    //Manejar los items seleccionados con try catchs individuales ;)

                    string Operacion;
                    string Evento;

                    try//Try de Operación
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();

                        IDbCommand dbcmd = dbcon.CreateCommand();
                        IDataReader reader;

                        Operacion = lbOper.SelectedItem.ToString();

                        try//Try de Evento en el que sé que ya se seleccionó una operación
                        {
                            Evento = lbEvento.SelectedItem.ToString();
                            dbcmd.CommandText = "select id_oper,id_evento from operacion,evento where operacion.descripcion='"+Operacion+"' and evento.descripcion='"+Evento+"'";
                            reader = dbcmd.ExecuteReader();

                            int ID_OPER;
                            int ID_EVENTO;

                            reader.Read();

                            ID_OPER = reader.GetInt32(reader.GetOrdinal("id_oper"));
                            ID_EVENTO = reader.GetInt32(reader.GetOrdinal("id_evento"));

                            dbcmd.CommandText = "insert into reporte_financiero values("+ID+","+ID_EVENTO+","+ID_OPER+","+ID_PERSONA+","+MONTO+",'"+FECHA+"')";
                            dbcmd.ExecuteReader();

                            try
                            {
                                double saldo;
                                dbcmd.CommandText = "select saldo from capital";
                                reader=dbcmd.ExecuteReader();

                                if (reader.Read())
                                {
                                    saldo = Convert.ToDouble(reader.GetDouble(reader.GetOrdinal("saldo")));

                                    switch (cmbTipoOper.SelectedIndex)
                                    {
                                        //Depósito
                                        case 1: dbcmd.CommandText = "update capital set id_reporte=" + ID + ",saldo="+saldo+"+" + MONTO + "";
                                            dbcmd.ExecuteReader();
                                            break;
                                        //Retiro
                                        case 2: dbcmd.CommandText = "update capital set id_reporte=" + ID + ",saldo=" + saldo + "-" + MONTO + "";
                                            dbcmd.ExecuteReader();
                                            break;
                                        //Préstamo
                                        case 3:
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (cmbTipoOper.SelectedIndex)
                                    {
                                        //Depósito
                                        case 1: dbcmd.CommandText = "insert into capital values(" + ID + "," + MONTO + ")";
                                            dbcmd.ExecuteReader();
                                            break;
                                        //Retiro
                                        case 2: MessageBox.Show("Error: No hay un saldo inicial, por lo cual no puedes realizar una operación de tipo 'retiro'");
                                            break;
                                        //Préstamo
                                        case 3:
                                            break;
                                    }
                                }

                                dbcon.Close();

                                cap = 1;
                            }
                            catch (Exception exc)
                            {
                                dbcmd.CommandText = "delete from reporte_financiero where id_reporte=" + ID + "";
                                dbcmd.ExecuteReader();

                                MessageBox.Show("error...\n\nQuizá intentaste retirar más de lo que tienes como saldo...\n\n" + exc.Message);
                            }
                        }
                        catch//No hay evento pero sí operación
                        {
                            dbcmd.CommandText = "select id_oper from operacion where descripcion='" + Operacion + "'";
                            reader = dbcmd.ExecuteReader();

                            int ID_OPER;

                            reader.Read();

                            ID_OPER = reader.GetInt32(reader.GetOrdinal("id_oper"));

                            dbcmd.CommandText = "insert into reporte_financiero (id_reporte,id_oper,id_persona,monto,fecha) values(" + ID + "," + ID_OPER + "," + ID_PERSONA + "," + MONTO + ",'" + FECHA + "')";
                            dbcmd.ExecuteReader();

                            try
                            {
                                double saldo;
                                dbcmd.CommandText = "select saldo from capital";
                                reader = dbcmd.ExecuteReader();

                                if (reader.Read())
                                {
                                    saldo = Convert.ToDouble(reader.GetDouble(reader.GetOrdinal("saldo")));

                                    switch (cmbTipoOper.SelectedIndex)
                                    {
                                        //Depósito
                                        case 1: dbcmd.CommandText = "update capital set id_reporte=" + ID + ",saldo=" + saldo + "+" + MONTO + "";
                                            dbcmd.ExecuteReader();
                                            break;
                                        //Retiro
                                        case 2: dbcmd.CommandText = "update capital set id_reporte=" + ID + ",saldo=" + saldo + "-" + MONTO + "";
                                            dbcmd.ExecuteReader();
                                            break;
                                        //Préstamo
                                        case 3:
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (cmbTipoOper.SelectedIndex)
                                    {
                                        //Depósito
                                        case 1: dbcmd.CommandText = "insert into capital values(" + ID + "," + MONTO + ")";
                                            dbcmd.ExecuteReader();
                                            break;
                                        //Retiro
                                        case 2: MessageBox.Show("Error: No hay un saldo inicial, por lo cual no puedes realizar una operación de tipo 'retiro'");
                                            break;
                                        //Préstamo
                                        case 3:
                                            break;
                                    }
                                }
                                
                                dbcon.Close();

                                cap = 1;
                            }
                            catch (Exception exc)
                            {
                                dbcmd.CommandText = "delete from reporte_financiero where id_reporte=" + ID + "";
                                dbcmd.ExecuteReader();

                                MessageBox.Show("error...\n\nQuizá intentaste retirar más de lo que tienes como saldo...\n\n" + exc.Message);
                            }
                        }
                    }
                    catch//No hay operación, por lo tanto no capturo nada
                    {
                        try//Veo si hay evento para saber el mensaje a mostrar
                        {
                            lbEvento.SelectedItem.ToString();

                            //Si estoy aquí es porque hay un evento seleccionado
                            MessageBox.Show("No puedes capturar un reporte si no has seleccionado una operación, aunque hayas seleccionado ya un evento");
                        }
                        catch//Veo si no hay evento """"""""""""""
                        {
                            MessageBox.Show("Puedes no seleccionar un evento, pero debes haber seleccionado una operación =P");
                        }
                    }

                    if (cap == 1)
                    {
                        txtIdPersona.Text = "";
                        txtNombre.Text = "";
                        txtMonto.Text = "";

                        cmbTipoEvento.SelectedIndex = 0;
                        cmbTipoOper.SelectedIndex = 0;

                        cmbTipoOper.Enabled = false;

                        txtIdPersona.Enabled = true;

                        try
                        {
                            IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                                "Database=BD_Pandillas;" +
                                "User ID=mags;");
                            dbcon.Open();
                            IDbCommand dbcmd = dbcon.CreateCommand();
                            dbcmd.CommandText = "select count(*) from reporte_financiero";
                            ID = (Int64)dbcmd.ExecuteScalar() + 1;
                            dbcon.Close();

                            txtId.Text = Convert.ToString(ID);

                            DateTime fechaActual = new DateTime();
                            fechaActual = DateTime.Today;

                            dtpFecha.Value = fechaActual;

                            txtIdPersona.Focus();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("error.....\n\n" + exc.ToString());
                        }

                        MessageBox.Show("Movimiento capturado correctamente");
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show("error.....\n\n" + msg.ToString());
                }
            }
        }
    }
}
