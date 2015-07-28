using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace BauchladenProgramm
{
    public partial class ConnectionDialog : Form
    {
        private Thread mainwindowT;
        private String ip;
        Form mainwindow;

        public ConnectionDialog()
        {
            InitializeComponent();
            this.ipAdresse.SelectedIndex = 0;
            this.mainwindowT = new Thread(new ThreadStart(openMainwindow));
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                this.ip = this.ipAdresse.Text;
                this.mainwindowT.Start();
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
                mainwindow = new Mainwindow(ip);
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
