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
    public partial class CapturarActividad : Form
    {
        string TipoEv;
        string[] ActEscuelita = { "Ambientación", "Oración Inicial", "Tema", "Oración Final" };
        string[] ActPandilla={"Pasillos","Charla","Motivación","Ambientación","Meditación","Pandilla","Baños","Patios","Salón de Charlas"};
        DataTable tabla = new DataTable();
        int ID_EVENT;
        int ID_PERS;

        public CapturarActividad()
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

        private void txtIdEvento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtIdEvento.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DEL EVENTO AL QUE AGREGARÁS ACTIVIDADES");
                    txtIdEvento.Focus();
                }
                else
                {
                    try
                    {
                        IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        ID_EVENT = Convert.ToInt32(txtIdEvento.Text);
                        IDbCommand dbcmd = dbcon.CreateCommand();

                        dbcmd.CommandText = "select descripcion,tipo from evento where id_evento=" + ID_EVENT + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtDescripcionEv.Text = reader.GetString(reader.GetOrdinal("descripcion"));
                            TipoEv = reader.GetString(reader.GetOrdinal("tipo"));

                            txtIdEvento.Enabled = false;
                            txtIdPersona.Enabled = true;

                            txtIdPersona.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No existe el evento con el id ingresado");
                            txtIdEvento.Focus();
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("error... \n\n" + exc.Message);
                    }
                }
            }
        }

        private void txtIdPersona_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtIdPersona.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DE LA PERSONA A LA CUAL AGREGARÁS ACTIVIDADES");
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
                        ID_PERS = Convert.ToInt32(txtIdPersona.Text);
                        IDbCommand dbcmd = dbcon.CreateCommand();
                        IDbCommand dbcmd2 = dbcon.CreateCommand();

                        dbcmd.CommandText = "select nombre from persona where id_persona=" + ID_PERS + "";
                        IDataReader reader = dbcmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtNombre.Text = reader.GetString(reader.GetOrdinal("nombre"));

                            txtIdPersona.Enabled = false;

                            dbcmd2.CommandText = "select actividad.tipo from actividad join evento on evento.id_evento=actividad.id_evento where evento.tipo='" + TipoEv + "' and id_persona="+ID_PERS+"";
                            IDataReader reader2 = dbcmd2.ExecuteReader();

                            switch (TipoEv)
                            {
                                case "Escuelita": cmbTipoActividad.Items.AddRange(ActEscuelita);
                                    cmbTipoActividad.Enabled = true;
                                    break;
                                case "Pandilla": cmbTipoActividad.Items.AddRange(ActPandilla);
                                    cmbTipoActividad.Enabled = true;
                                    break;
                                case "Especial": cmbTipoActividad.Items.Add("Actividad Especial");
                                    cmbTipoActividad.Text = "Actividad Especial";
                                    txtDescripcion.Enabled = true;
                                    dtpHoraIni.Enabled = true;
                                    btnAgregar.Enabled = true;
                                    break;
                            }

                            while (reader2.Read())
                            {
                                if (TipoEv != "Especial")
                                {
                                    string TipoAc = reader2.GetString(reader2.GetOrdinal("tipo"));
                                    cmbTipoActividad.Items.Remove(TipoAc);
                                }
                                else
                                {
                                    MessageBox.Show("Esta persona ya tiene asignada una actividad especial, no puede tener otra...");
                                    cmbTipoActividad.Text="";
                                    cmbTipoActividad.Items.Clear();
                                    txtDescripcion.Enabled = false;
                                    dtpHoraIni.Enabled = false;
                                    btnAgregar.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No existe la persona con el id ingresado");
                            txtIdPersona.Focus();
                        }
                        dbcon.Close();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("error... \n\n" + exc.ToString());
                    }
                }
            }
        }

        private void cmbTipoActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTipoActividad.Enabled = false;
            txtDescripcion.Enabled = true;
            dtpHoraIni.Enabled = true;
            btnAgregar.Enabled = true;
        }

        private void dtpHoraIni_ValueChanged(object sender, EventArgs e)
        {
            if (dtpHoraIni.Checked == true)
            {
                dtpHoraFin.Enabled = true;
            }
            else
            {
                dtpHoraFin.Checked = false;
                dtpHoraFin.Enabled = false;
            }
        }

        int i;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Descrip = txtDescripcion.Text.Trim();

            try
            {
                if (txtDescripcion.Text == "")
                {
                    MessageBox.Show("Debes poner una descripción a la actividad");
                }
                else if (dtpHoraIni.Checked == true) //hay hora inicial
                {
                    string horaIn = dtpHoraIni.Value.ToShortTimeString();
                    if (dtpHoraFin.Checked == true) // hay hora tanto inicial como final
                    {
                        if (cmbTipoActividad.Text != "Actividad Especial")
                        {
                            cmbTipoActividad.Enabled = true;
                            dtpHoraIni.Enabled = false;
                            txtDescripcion.Enabled = false;
                        }
                        else
                        {
                            dtpHoraIni.Enabled = false;
                            txtDescripcion.Enabled = false;
                            btnAgregar.Enabled = false;
                        }

                        string horaFin = dtpHoraFin.Value.ToShortTimeString();
                        tabla.Rows.Add();
                        dgvActividades.Rows[i].Cells[0].Value = cmbTipoActividad.Text;
                        dgvActividades.Rows[i].Cells[1].Value = txtDescripcion.Text;
                        dgvActividades.Rows[i].Cells[2].Value = horaIn;
                        dgvActividades.Rows[i].Cells[3].Value = horaFin;
                        dgvActividades.Refresh();

                        txtDescripcion.Clear();
                        cmbTipoActividad.Items.RemoveAt(cmbTipoActividad.SelectedIndex);
                        cmbTipoActividad.Text = "";
                        dtpHoraIni.Checked = false;
                        dtpHoraFin.Checked = false;

                        i++;
                    }
                    else // sólo hay hora inicial
                    {
                        if (cmbTipoActividad.Text != "Actividad Especial")
                        {
                            cmbTipoActividad.Enabled = true;
                            dtpHoraIni.Enabled = false;
                            txtDescripcion.Enabled = false;
                        }
                        else
                        {
                            dtpHoraIni.Enabled = false;
                            txtDescripcion.Enabled = false;
                            btnAgregar.Enabled = false;
                        }

                        tabla.Rows.Add();
                        dgvActividades.Rows[i].Cells[0].Value = cmbTipoActividad.Text;
                        dgvActividades.Rows[i].Cells[1].Value = txtDescripcion.Text;
                        dgvActividades.Rows[i].Cells[2].Value = horaIn;
                        dgvActividades.Refresh();

                        txtDescripcion.Clear();
                        cmbTipoActividad.Items.RemoveAt(cmbTipoActividad.SelectedIndex);
                        cmbTipoActividad.Text = "";
                        dtpHoraIni.Checked = false;

                        i++;
                    }
                }
                else //no hay hora inicial ni final, pero sí descripción
                {
                    if (cmbTipoActividad.Text != "Actividad Especial")
                    {
                        cmbTipoActividad.Enabled = true;
                        dtpHoraIni.Enabled = false;
                        txtDescripcion.Enabled = false;
                    }
                    else
                    {
                        dtpHoraIni.Enabled = false;
                        txtDescripcion.Enabled = false;
                        btnAgregar.Enabled = false;
                    }

                    tabla.Rows.Add();
                    dgvActividades.Rows[i].Cells[0].Value = cmbTipoActividad.Text;
                    dgvActividades.Rows[i].Cells[1].Value = txtDescripcion.Text;
                    dgvActividades.Refresh();

                    txtDescripcion.Clear();
                    cmbTipoActividad.Items.RemoveAt(cmbTipoActividad.SelectedIndex);
                    cmbTipoActividad.Text = "";

                    i++;
                }
                if (i > 0)
                {
                    btnCapturar.Enabled = true;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Error...\n\n"+exc.ToString());
            }
        }

        private void CapturarActividad_Load(object sender, EventArgs e)
        {
            tabla.Columns.Add("Actividad");
            tabla.Columns.Add("Descripción");
            tabla.Columns.Add("Hora_Inicio");
            tabla.Columns.Add("Hora_Fin");
            dgvActividades.DataSource = tabla.DefaultView;
            i = 0;
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            try
            {
                IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();

                string TIPO;
                string DESCR;
                DateTime hora_in;
                DateTime hora_fin;

                for (int j = 0; j < i; j++)
                {
                    TIPO = dgvActividades.Rows[j].Cells[0].Value.ToString();
                    DESCR = dgvActividades.Rows[j].Cells[1].Value.ToString();
                    try//Hay hora inicial
                    {
                        hora_in = Convert.ToDateTime(dgvActividades.Rows[j].Cells[2].Value); //si no tiene nada la celda, regresa una cadena vacía
                        string HORA_IN;
                        string HORA_FIN;
                        try//Hay hora inicial y final =)
                        {
                            hora_fin = Convert.ToDateTime(dgvActividades.Rows[j].Cells[3].Value);
                            HORA_IN = hora_in.ToString("HH:mm:ss");
                            HORA_FIN = hora_fin.ToString("HH:mm:ss");
                            dbcmd.CommandText = "insert into actividad values(" + ID_EVENT + "," + ID_PERS + ",'" + TIPO + "','" + HORA_IN + "','" + HORA_FIN + "','" + DESCR + "')";
                        }
                        catch//Sólo hay hora inicial
                        {
                            HORA_IN = hora_in.ToString("HH:mm:ss");
                            dbcmd.CommandText = "insert into actividad(id_evento,id_persona,tipo,hora_in,descripcion) values(" + ID_EVENT + "," + ID_PERS + ",'" + TIPO + "','" + HORA_IN + "','" + DESCR + "')";
                        }
                    }
                    catch//No hay hora inicial y mucho menos final.
                    {
                        dbcmd.CommandText = "insert into actividad(id_evento,id_persona,tipo,descripcion) values(" + ID_EVENT + "," + ID_PERS + ",'" + TIPO + "','" + DESCR + "')";
                    }

                    dbcmd.ExecuteNonQuery();
                }
                //limpieza
                tabla.Rows.Clear();
                dtpHoraIni.Checked = false;
                txtDescripcion.Clear();
                cmbTipoActividad.Text = "";
                cmbTipoActividad.Items.Clear();
                txtNombre.Clear();
                txtIdPersona.Clear();
                txtDescripcionEv.Clear();
                txtIdEvento.Clear();
                i = 0;

                //Restauración de habilitación/inhabilitación de campos, botones...

                txtIdEvento.Enabled = true;
                txtDescripcion.Enabled = false;
                dtpHoraIni.Enabled = false;
                cmbTipoActividad.Enabled = false;

                //Mensaje de confirmación
                MessageBox.Show("La(s) actividad(es) ha(n) sido registradas con éxito");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error...\n\n"+exc.ToString());
            }
        }
    }
}
