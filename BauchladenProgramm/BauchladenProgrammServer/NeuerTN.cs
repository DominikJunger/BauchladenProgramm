using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BauchladenProgrammServer.Klassen;
using BauchladenProgrammServer.Backend_Klassen;

namespace BauchladenProgrammServer
{
    public partial class NeuerTN : Form
    {
        private SQL_Connector con;

        public NeuerTN(SQL_Connector con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void tnHinzufügen_Click(object sender, EventArgs e)
        {
            this.con.addTeilnehmer(new Teilnehmer(this.textBox1.Text, this.textBox2.Text));
            this.Close();
        }
    }
}
