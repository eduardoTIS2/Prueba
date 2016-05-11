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
    public partial class ModificarPersona : Form
    {
        int ID;
        public ModificarPersona()
        {
            InitializeComponent();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("DEBES INTRODUCIR EL ID DE LA PERSONA QUE QUIERES MODIFICAR");
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

                            try
                            {
                                dtpFechaNac.Value = reader.GetDateTime(reader.GetOrdinal("fecha_nac"));
                                dtpFechaNac.Checked = true;
                            }
                            catch (Exception)
                            {
                                dtpFechaNac.Value = DateTime.Today;
                                dtpFechaNac.Checked = false;
                            }

                            txtDireccion.Text = reader.GetString(reader.GetOrdinal("direccion"));
                            
                            try
                            {
                                txtEmail.Text = reader.GetString(reader.GetOrdinal("email"));
                            }
                            catch (Exception)
                            {
                                txtEmail.Text = "";
                            }

                            txtTel.Text = reader.GetString(reader.GetOrdinal("tel")).Trim();
                            txtCel.Text = reader.GetString(reader.GetOrdinal("cel")).Trim();
                            cmbTipo.Text = reader.GetString(reader.GetOrdinal("tipo"));
                            cmbCargo.Text = reader.GetString(reader.GetOrdinal("cargo"));
                            cmbStatus.Text = reader.GetString(reader.GetOrdinal("status"));

                            txtNombre.Enabled=true;
                            dtpFechaNac.Enabled=true;
                            txtDireccion.Enabled=true;
                            txtEmail.Enabled=true;
                            txtTel.Enabled=true;
                            txtCel.Enabled=true;
                            cmbTipo.Enabled=true;
                            //cmbCargo.Enabled=true;
                            cmbStatus.Enabled=true;

                            txtId.Clear();

                            dbcon.Close();

                            try
                            {
                                pbxPersona.Load("Imagenes\\" + ID + ".jpg");
                            }
                            catch
                            {
                                pbxPersona.Load("Imagenes\\default.jpg");
                            }

                            txtId.Enabled = false;

                            if (cmbTipo.SelectedIndex == 0&&cmbStatus.SelectedIndex==0)
                            {
                                cmbCargo.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("REGISTRO NO ENCONTRADO......");

                            txtNombre.Text = "";
                            dtpFechaNac.Value = DateTime.Today;
                            txtDireccion.Text = "";
                            txtEmail.Text = "";
                            txtTel.Text = "";
                            txtCel.Text = "";
                            cmbTipo.Text = "";
                            cmbCargo.Text = "";
                            cmbStatus.Text = "";

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
            Principal p = new Principal();
            p.Show();
            this.Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                txtNombre.Text=txtNombre.Text.Trim();
                txtTel.Text = txtTel.Text.Trim();
                txtCel.Text = txtCel.Text.Trim();
                txtEmail.Text = txtEmail.Text.Trim();
                txtDireccion.Text = txtDireccion.Text.Trim();

                if (txtNombre.Text != "")
                {
                    try
                    {
                        NpgsqlConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                        "Database=BD_Pandillas;" +
                        "User ID=mags;");
                        dbcon.Open();
                        string NOMBRE = txtNombre.Text;
                        string DIRECCION = txtDireccion.Text;
                        string EMAIL = txtEmail.Text;
                        string TEL = txtTel.Text;
                        string CEL = txtCel.Text;
                        string TIPO = cmbTipo.Text;
                        string CARGO = cmbCargo.Text;
                        string STATUS = cmbStatus.Text;
                        //MessageBox.Show("Entró al if de <txtNombre!=''>, txtEmail= "+EMAIL);
                        string queryUp;

                        if (dtpFechaNac.Checked == true)
                        {
                            DateTime FECHA_NAC = dtpFechaNac.Value;
                            int EDAD = DateTime.Today.AddTicks(-FECHA_NAC.Ticks).Year - 1;
                            if (txtEmail.Text != "")
                            {
                                queryUp = "update persona set nombre='" + NOMBRE + "',edad=" + EDAD + ",fecha_nac='" + FECHA_NAC.ToShortDateString() + "',email='" + EMAIL + "',direccion='" + DIRECCION + "',tel='" + TEL + "',cel='" + CEL + "',cargo='" + CARGO + "',status='" + STATUS + "',tipo='" + TIPO + "' where id_persona=" + ID + "";
                            }
                            else
                            {
                                queryUp = "update persona set nombre='" + NOMBRE + "',edad=" + EDAD + ",fecha_nac='" + FECHA_NAC.ToShortDateString() + "',email=null,direccion='" + DIRECCION + "',tel='" + TEL + "',cel='" + CEL + "',cargo='" + CARGO + "',status='" + STATUS + "',tipo='" + TIPO + "' where id_persona=" + ID + "";
                            }
                        }
                        else if (txtEmail.Text != "")
                        {
                            queryUp = "update persona set nombre='" + NOMBRE + "',email='" + EMAIL + "',direccion='" + DIRECCION + "',tel='" + TEL + "',cel='" + CEL + "',cargo='" + CARGO + "',status='" + STATUS + "',tipo='" + TIPO + "' where id_persona=" + ID + "";
                        }
                        else
                        {
                            queryUp = "update persona set nombre='" + NOMBRE + "',email=null,direccion='" + DIRECCION + "',tel='" + TEL + "',cel='" + CEL + "',cargo='" + CARGO + "',status='" + STATUS + "',tipo='" + TIPO + "' where id_persona=" + ID + "";
                        }

                        NpgsqlCommand cmdUp = new NpgsqlCommand(queryUp, dbcon);
                        cmdUp.ExecuteNonQuery();

                        dbcon.Close();

                        if (pbxPersona.ImageLocation != "Imagenes\\default.jpg")
                        {
                            try
                            {
                                pbxPersona.Image.Save("Imagenes\\" + ID + ".jpg");
                            }
                            catch
                            {
                            }
                        }

                        MessageBox.Show("Registro Modificado correctamente");

                        pbxPersona.Load("Imagenes\\default.jpg");
                        txtNombre.Text = "";
                        dtpFechaNac.Value = DateTime.Today;
                        dtpFechaNac.Checked = false;
                        txtDireccion.Text = "";
                        txtEmail.Text = "";
                        txtTel.Text = "";
                        txtCel.Text = "";
                        cmbTipo.Text = "";
                        cmbCargo.Text = "";
                        cmbStatus.Text = "";

                        txtNombre.Enabled = false;
                        dtpFechaNac.Enabled = false;
                        txtDireccion.Enabled = false;
                        txtEmail.Enabled = false;
                        txtTel.Enabled = false;
                        txtCel.Enabled = false;
                        cmbTipo.Enabled = false;
                        cmbCargo.Enabled = false;
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
                    MessageBox.Show("No puedes dejar a la persona sin nombre, regrésale su nombre o cámbiaselo pero toda persona tiene derecho a un nombre =P");
                }
            }
            else
            {
                MessageBox.Show("Ingresa el ID de la persona que quieres modificar y presiona enter para que puedas visualizar los datos de la persona y modificarlos ");
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == 1)
            {
                cmbCargo.SelectedIndex = 0;
                cmbCargo.Enabled = false;
            }
            else if(cmbStatus.SelectedIndex!=1)
            {
                cmbCargo.Enabled = true;
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedIndex == 1)
            {
                cmbCargo.SelectedIndex = 0;
                cmbCargo.Enabled = false;
            }
            else if(cmbTipo.SelectedIndex!=1)
            {
                cmbCargo.Enabled = true;
            }
        }

        private void ModificarPersona_Load(object sender, EventArgs e)
        {
            pbxPersona.Load("Imagenes\\default.jpg");
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openimg = new OpenFileDialog();
            openimg.InitialDirectory = "c:\\";
            openimg.Multiselect = false;
            openimg.Filter = "Archivo de Imagen (*.JPG)|*.JPG";

            if (openimg.ShowDialog() == DialogResult.OK)
            {
                string rutaImg = openimg.FileName;
                pbxPersona.Load(rutaImg);
            }
        }
    }
}
