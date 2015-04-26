using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BauchladenProgramm
{
    public partial class ConnectionDialog : Form
    {
        public ConnectionDialog()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                new Mainwindow(this.ipAdresse.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,"Verbidungsfehler");
            }
        }
    }
}
