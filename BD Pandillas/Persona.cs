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
    public partial class CapturarPersona : Form
    {
        Int64 ID;
        public CapturarPersona()
        {
            InitializeComponent();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == 2)
            {
                cmbCargo.Enabled = true;
            }
            else
            {
                cmbCargo.SelectedIndex = 0;
                cmbCargo.Enabled = false;
            }
        }

        private void Persona_Load(object sender, EventArgs e)
        {
            try
            {
                IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                dbcon.Open();
                IDbCommand dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = "select count(*) from persona";
                ID = (Int64)dbcmd.ExecuteScalar() + 1;
                dbcon.Close();

                txtId.Text = Convert.ToString(ID);
                cmbTipo.SelectedIndex = 0;
                cmbCargo.SelectedIndex = 0;

                string rutaImg = "Imagenes\\default.jpg";
                pbxPersona.Load(rutaImg);
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
            txtNombre.Text = txtNombre.Text.Trim();
            txtTel.Text = txtTel.Text.Trim();
            txtCel.Text = txtCel.Text.Trim();
            txtEmail.Text = txtEmail.Text.Trim();
            txtDireccion.Text = txtDireccion.Text.Trim();

            if (txtNombre.Text == "" || cmbTipo.SelectedIndex==0)
            {
                MessageBox.Show("DEBES INGRESAR AL MENOS UN NOMBRE Y SELECCIONAR UN TIPO DE PERSONA...");
            }
            else
            {
                try
                {
                    string NOMBRE = txtNombre.Text;
                    string DIRECCION = txtDireccion.Text;
                    string EMAIL = txtEmail.Text;
                    string TEL = txtTel.Text;
                    string CEL = txtCel.Text;
                    string TIPO = cmbTipo.Text;
                    string CARGO = cmbCargo.Text;
                    string STATUS = "Activo";
                    IDbConnection dbcon = new NpgsqlConnection("Server=localhost;" +
                    "Database=BD_Pandillas;" +
                    "User ID=mags;");
                    dbcon.Open();
                    IDbCommand dbcmd = dbcon.CreateCommand();
                    if (dtpFechaNac.Checked == true)
                    {
                        DateTime FECHA_NAC = dtpFechaNac.Value;
                        int EDAD = DateTime.Today.AddTicks(-FECHA_NAC.Ticks).Year - 1;
                        if (txtEmail.Text != "")
                        {
                            dbcmd.CommandText = "insert into persona values(" + ID + ",'" + NOMBRE + "'," + EDAD + ",'" + FECHA_NAC.ToShortDateString() + "','" + EMAIL + "','" + DIRECCION + "','" + TEL + "','" + CEL + "','" + CARGO + "','" + STATUS + "','" + TIPO + "')";
                        }
                        else
                        {
                            dbcmd.CommandText = "insert into persona (id_persona,nombre,edad,fecha_nac,direccion,tel,cel,cargo,status,tipo) values(" + ID + ",'" + NOMBRE + "'," + EDAD + ",'" + FECHA_NAC.ToShortDateString() + "','" + DIRECCION + "','" + TEL + "','" + CEL + "','" + CARGO + "','" + STATUS + "','" + TIPO + "')";
                        }
                    }
                    else if (txtEmail.Text != "")
                    {
                        dbcmd.CommandText = "insert into persona (id_persona,nombre,email,direccion,tel,cel,cargo,status,tipo) values(" + ID + ",'" + NOMBRE + "','" + EMAIL + "','" + DIRECCION + "','" + TEL + "','" + CEL + "','" + CARGO + "','" + STATUS + "','" + TIPO + "')";
                    }
                    else
                    {
                        dbcmd.CommandText = "insert into persona (id_persona,nombre,direccion,tel,cel,cargo,status,tipo) values(" + ID + ",'" + NOMBRE + "','" + DIRECCION + "','" + TEL + "','" + CEL + "','" + CARGO + "','" + STATUS + "','" + TIPO + "')";
                    }

                    IDataReader reader = dbcmd.ExecuteReader();

                    try
                    {
                        if (pbxPersona.ImageLocation != "Imagenes\\default.jpg")
                        {
                            pbxPersona.Image.Save("Imagenes\\" + ID + ".jpg");
                        }
                    }
                    catch
                    {
                    }

                    dbcmd.CommandText = "select count(*) from persona";
                    ID = (Int64)dbcmd.ExecuteScalar() + 1;

                    dbcon.Close();

                    txtId.Text = Convert.ToString(ID);
                    txtNombre.Text="";
                    dtpFechaNac.Checked = false;
                    txtDireccion.Text="";
                    txtEmail.Text="";
                    txtTel.Text="";
                    txtCel.Text="";
                    cmbTipo.SelectedIndex=0;
                    cmbCargo.SelectedIndex=0;
                    pbxPersona.Load("Imagenes\\default.jpg");

                    MessageBox.Show("Registro Guardado correctamente");
                }
                catch (Exception msg)
                {
                    MessageBox.Show("error.....\n\n" + msg.ToString());
                }
            }
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
