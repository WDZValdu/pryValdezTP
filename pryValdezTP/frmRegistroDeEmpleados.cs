using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryValdezTP
{
    public partial class frmRegistroDeEmpleados : Form
    {
        clsBasedeDatos objBD;
        public frmRegistroDeEmpleados()
        {
            InitializeComponent();
        }
        
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal frmPrincipal = new frmPrincipal();
            this.Hide();
            frmPrincipal.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objBD = new clsBasedeDatos();
            int cod = Convert.ToInt32(txtCodigo.Text);
            objBD.CargarUsuario(cod ,txtNombre.Text, txtApellido.Text, dtFecha.Value,
                txtCiudad.Text, txtDireccion.Text, txtTelefono.Text);

        }

        private void txtCodigo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }           
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
