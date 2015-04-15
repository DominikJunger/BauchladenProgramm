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
           
          
        }

        private void Mainwindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!con.isClosed())
                con.closeConnection();
        }
        private async void openSQLConnection()
        {
            ConnectionState conState;

            con = new SQL_Connector();
            conState = await con.openConnection();

            if(conState == ConnectionState.Open)
                sqlState.BackColor=Color.Green;
        }

        private void ReadCSV(string filename)
        {           
            teilnehmer = new CSV_Reader().ReadCSV(filename);

            foreach (Teilnehmer t in teilnehmer)
            {
                string tmpTeilnehmer;
                tmpTeilnehmer = t.Vorname + ", " + t.Nachname + ", " + t.Geburtsdatum.ToString() + ", " + t.Wohnort;
              // Hier dann einer Tabelle hinzufügen oder andere Anzeigevariante
            }                  
        }      

        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool x = true;
            while (true)
            {
                if (!backgroundWorker1.CancellationPending)
                {
                    Thread.Sleep(2000);

                    x = await con.CheckDbConnection();

                    if (!x)
                    {
                        sqlState.BackColor = Color.Red;
                        backgroundWorker1.CancelAsync();
                        break;
                    }                    
                }
            }           
        }
    }
}