using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemaVeterinaria_1._5.Presentacion
{
    public partial class AltaMascota : ProblemaVeterinaria_1._5.Presentacion.Base
    {
        AccesoDatos oBD;
        public AltaMascota()
        {
            InitializeComponent();
            oBD = new AccesoDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void CargarCombo()
        {
            DataTable tabla = new DataTable();
            cbTipoMascota.DataSource = tabla;
            cbTipoMascota.ValueMember = "id_tipo";
            cbTipoMascota.DisplayMember = "nombre";
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (validarDatos())
        //    {
        //        //nombre, edad, tipo, Atencion
        //        Mascota m = new Mascota();
        //        m.Nombre = txtNombreMascota.Text;
        //        if (rbMasculino.Checked)
        //        {
        //            c.Sexo = 1;
        //        }
        //        else
        //        {
        //            c.Sexo = 2;
        //        }


        //        //string insert = "insert into clientes(nombre,sexo,codigo" +
        //        //    "values (@nombre,@sexo,@codigo))";

        //        int filas = oBD.insertarBDSP("SP_INSERTAR_CLIENTE");
        //        if (filas > 0)
        //        {
        //            MessageBox.Show("Se inserto el cliente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            btnGrabar.Enabled = false;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error al insertar el cliente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

            private bool validarDatos()
            {
                if (txtNombreMascota.Text == string.Empty)
                {
                    MessageBox.Show("Ingresar Nombre:");
                    txtNombreMascota.Focus();
                    return false;
                }
                if (txtEdadMascota.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese la edad:");
                    txtEdadMascota.Focus();
                    return false;
                }
                //if (cbTipoMascota.SelectedValue)
                //{
                //    MessageBox.Show("Debe seleccionar un Sexo.");
                //    rbMasculino.Focus();
                //    return false;
                //}
                return true;
            }
        }
    }

