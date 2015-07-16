using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BauchladenProgramm
{
    public partial class ConnectionDialog : Form
    {
        private Thread mainwindow;
        private String ip;

        public ConnectionDialog()
        {
            InitializeComponent();
            this.ipAdresse.SelectedIndex = 0;
            this.mainwindow = new Thread(new ThreadStart(openMainwindow));
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                this.ip = this.ipAdresse.Text;
                this.mainwindow.Start();
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,"Verbidungsfehler");
            }
        }

        private void openMainwindow(){
            try
            {
                Form mainwindow = new Mainwindow(ip);
                mainwindow.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Verbidungsfehler");
            }
        }

        private void ConnectionDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ConnectionDialog_Load(object sender, EventArgs e)
        {

        }

    
    }
}
