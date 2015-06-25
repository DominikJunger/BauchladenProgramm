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
using BauchladenProgrammServer.Klassen;
using BauchladenProgrammServer.Backend_Klassen;

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

        private  void Mainwindow_Load(object sender, EventArgs e)
        {
            

            
        }

        private void Mainwindow_Shown(object sender, EventArgs e)
        {
            openSQLConnection();
            init_Server();
        } 

        private void init_Server()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void Mainwindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!con.isClosed())
                con.closeConnection();
        }
        private async void openSQLConnection()
        {
            ConnectionState conState;

            con = SQL_Connector.getInstance();           
            conState = await con.openConnection();

            if(conState == ConnectionState.Open)
                sqlState.BackColor=Color.Green;
        
        }

        private void addTeilnehmer(List<Teilnehmer> tn)
        {
            
            String[] tnString = new String[3];

            foreach (Teilnehmer t in tn)
            {
                tnString[0] = t.Id.ToString("00");
                tnString[1] = t.VorName;
                tnString[2] = t.NachName;
                this.dataGridViewTeilnehmer.Invoke((MethodInvoker)delegate()
                {
                    dataGridViewTeilnehmer.Rows.Add(tnString);
                });
                
            }
        }
       
        private void addProdukte(List<Produkt> pr)
        {
            String[] prString = new String[3];

            foreach (Produkt p in pr)
            {
                prString[0] = p.Id.ToString("00");
                prString[1] = p.Name;
                prString[2] = p.Preis.ToString("0.00");
                this.dataGridViewTeilnehmer.Invoke((MethodInvoker)delegate()
                {
                    dataGridViewProdukt.Rows.Add(prString);
                });

            }
        }

        private void ReadCSV(string filename)
        {           
            teilnehmer = new CSV_Reader().ReadCSV(filename);

            foreach (Teilnehmer t in teilnehmer)
            {
                string tmpTeilnehmer;
                //tmpTeilnehmer = t.Vorname + ", " + t.Nachname + ", " + t.Geburtsdatum.ToString() + ", " + t.Wohnort;
              // Hier dann einer Tabelle hinzufügen oder andere Anzeigevariante
            }                  
        }       

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
            if (!backgroundWorker1.CancellationPending)
            {             
                while (sqlState.BackColor == Color.Red)
                {                   
                    Thread.Sleep(2000);
                }
                addTeilnehmer(con.selectTeilnehmerAll());
                addProdukte(con.selectProduktAll());
                backgroundWorker1.CancelAsync();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teilnehmer t = con.selectTeilnehmerByID(Convert.ToInt32(textBox1.Text));
            if(t != null)
                textBox1.Text = t.Kontostand.ToString("0.00");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("HAHA");
        }               
    }
}