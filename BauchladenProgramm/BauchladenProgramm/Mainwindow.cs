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
    public partial class Mainwindow : Form
    {
        Connector.Connector c;
        string ipAdresse;

        public Mainwindow(string ipAdresse)
        {
            InitializeComponent();
            this.ipAdresse = ipAdresse;
        }

        private void Mainwindow_Load(object sender, EventArgs e)
        {
            c = new Connector.Connector(ipAdresse, 3000);
            c.connectToServer();
            c.getProductList();
        }
    }
}
