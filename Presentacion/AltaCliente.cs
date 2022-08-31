using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemaVeterinaria_1._5
{
    public partial class AltaCliente : ProblemaVeterinaria_1._5.Presentacion.Base
    {
        AccesoDatos oBD;
        
        public AltaCliente()
        {
            InitializeComponent();
            oBD = new AccesoDatos();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }       

        private void button2_Click(object sender, EventArgs e)
        { 
            if (validarDatos())
            {

                Cliente c = new Cliente();          
                c.Nombre = txtNombre.Text;
                if (rbMasculino.Checked)
                {
                    c.Sexo = 1;
                }
                else
                {
                    c.Sexo = 2;
                }

                      
                //string insert = "insert into clientes(nombre,sexo,codigo" +
                //    "values (@nombre,@sexo,@codigo))";

                int filas = oBD.insertarBDSP("SP_INSERTAR_CLIENTE");
                if (filas > 0)
                {
                    MessageBox.Show("Se inserto el cliente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGrabar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error al insertar el cliente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool validarDatos()
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Ingresar Nombre.");
                txtNombre.Focus();
                return false;
            }           
            if (!rbFemenino.Checked && !rbMasculino.Checked)
            {
                MessageBox.Show("Debe seleccionar un Sexo.");
                rbMasculino.Focus();
                return false;
            }          
            return true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();                            
        }
    }
}
