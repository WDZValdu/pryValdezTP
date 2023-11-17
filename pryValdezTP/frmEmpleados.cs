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
    public partial class frmEmpleados : Form
    {
        clsBasedeDatos objBD;
        public frmEmpleados()
        {
            InitializeComponent();
            lstBuscar.SelectedIndex = 0;
            objBD = new clsBasedeDatos();
            objBD.TraerDatos(grilla);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (lstBuscar.SelectedIndex == 0)
            { 
               objBD.BuscarPorApellido(txtBuscar.Text, grilla); 

            }
            else
            {
                objBD.BuscarPorCiudad(txtBuscar.Text,grilla);
            }           
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            objBD.TraerDatos(grilla);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal frmPrincipal = new frmPrincipal();
            this.Hide();
            frmPrincipal.Show();
        }
    }
}
