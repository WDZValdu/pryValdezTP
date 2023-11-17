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
    public partial class frmPrincipal : Form
    {
        clsBasedeDatos objBD;
        public frmPrincipal()
        {
            InitializeComponent();

            objBD = new clsBasedeDatos();

            objBD.ConectarBD();
            if(objBD.EstadoConexion == "Conectado")
            {
                ssConexion.Text = objBD.EstadoConexion;
                ssConexion.BackColor = Color.LightGreen;
            }
            else
            {
                ssConexion.Text = objBD.EstadoConexion;
                ssConexion.BackColor = Color.Red;
            }
            

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void registroDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroDeEmpleados frmRegistro = new frmRegistroDeEmpleados();
            this.Hide();
            frmRegistro.Show();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmEmpleados frmEmpleados = new frmEmpleados();
            this.Hide();
            frmEmpleados.Show();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualiza el contenido del Label con la hora actual.
            ssHora.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
