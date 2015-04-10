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
        private List<Teilnehmer> teilnehmer;
      
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
            openSQLConnection();
        }

        private void Mainwindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!con.isClosed())
                con.closeConnection();
        }
        private async void openSQLConnection()
        {
            con = new SQL_Connector();
            ConnectionState conState = await con.openConnection();

            if (conState == ConnectionState.Open)
                pictureBox1.BackColor = Color.Green;
            
        }

        private void ReadCSV(string filename, char separator)
        {           
            teilnehmer = new CSV_Reader().ReadCSV(filename, separator);

            foreach (Teilnehmer t in teilnehmer)
            {
                string tmpTeilnehmer;
                tmpTeilnehmer = t.Vorname + ", " + t.Nachname + ", " + t.Geburtsdatum.ToString() + ", " + t.Wohnort;
              // Hier dann einer Tabelle hinzufügen oder andere Anzeigevariante
            }                  
        }
    }
}