using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BauchladenProgramm.Backend_Klassen;
using BauchladenProgrammServer.Klassen;

namespace BauchladenProgrammServer
{
    public partial class Mainwindow : Form
    {
        private SQL_Connector con;
      
        public Mainwindow()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.UseSystemPasswordChar = false;
            }
            else
            {
                textBox4.UseSystemPasswordChar = true;
            }
        }

        private void Mainwindow_Load(object sender, EventArgs e)
        {
            con = new SQL_Connector();
            con.openConnection();
        }

        private void Mainwindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.closeConnection();
        }
    }
}