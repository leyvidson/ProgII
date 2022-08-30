using ProblemaVeterinaria_1._5.Presentacion;
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
    public partial class Veterinaria : ProblemaVeterinaria_1._5.Presentacion.Base
    {
        /*desarrollar un
        programa que permita las atenciones de una mascota indicando para cada una la
        descripción de los tratamientos y/o vacunas aplicadas.*/
        AccesoDatos oBD;
        List<Cliente> lCLientes;
        
        public Veterinaria()
        {
            InitializeComponent();
            oBD = new AccesoDatos();
            lCLientes = new List<Cliente>();
            CargarLista();
            Habilitar(false);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        public void CargarLista()
        {
            lCLientes.Clear();
            lstClientes.Items.Clear();
            DataTable tabla = oBD.ConsultarBD("SP_CONSULTAR_CLIENTE");
            foreach (DataRow fila in tabla.Rows)
            {
                Cliente c = new Cliente();
                c.Codigo = int.Parse(fila[0].ToString());
                c.Nombre = fila[1].ToString();
                c.Sexo = int.Parse(fila[2].ToString());
                //c.Mascota = new Mascota();
                lstClientes.Items.Add(c.ToString());
                lCLientes.Add(c);
            }
        }
        //public void CargarCombo()
        //{
        //    DataTable tabla = oBD.ConsultarBD("SELECT * FROM MASCOTAS");
        //    cboMascota.DataSource = tabla;
        //    cboMascota.DisplayMember = "nombre";
        //    cboMascota.ValueMember = "codigo";
        //    cboMascota.DropDownStyle = ComboBoxStyle.DropDownList;
        //}
        public void Habilitar(bool x)
        {
            txtNombre.Enabled = x;
            lstClientes.Enabled = !x;
            btnNuevo.Enabled = !x;
            btnGuardar.Enabled = x;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que quiere abandonar la App"
                , "SALIENDO", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question
                ,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaCliente a1 = new AltaCliente();
            a1.Show();
            
        }

        private void lstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCampos(lstClientes.SelectedIndex);
        }

        
        
        private void cargarCampos(int i)
        {
            txtNombre.Text = lCLientes[i].Nombre;
            txtCodigo.Text = lCLientes[i].Codigo.ToString();
            if (lCLientes[i].Sexo == 1)
            {
                rbMasculino.Checked = true;
            }
            else
            {
                rbFemenino.Checked = true;
            }
            

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AltaCliente a = new AltaCliente();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaMascota a = new AltaMascota();
            a.Show();
        }
    }
}
