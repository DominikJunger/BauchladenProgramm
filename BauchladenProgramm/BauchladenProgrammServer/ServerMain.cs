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
using System.Net;

namespace BauchladenProgrammServer
{
    public partial class Mainwindow : Form
    {
        private SQL_Connector con;
        private List<Teilnehmer> teilnehmer;
      
        public Mainwindow()
        {
            InitializeComponent();
            // Startet den Serverprozess und wartet auf Anfragen
            new Server(new IPEndPoint(IPAddress.Any, 3000), this);

            PDFCreator pdfc = new PDFCreator();
            //pdfc.createSimpleExampleTable();

            openSQLConnection();
            init_Server();
        }     

        private void init_Server()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void Mainwindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (con !=null && !con.isClosed())
            {
                con.closeConnection();
            }
            Environment.Exit(0);
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
            this.dataGridViewTeilnehmer.Rows.Clear();
            String[] tnString = new String[3];
            foreach (Teilnehmer t in tn)
            {
                tnString[0] = t.Id;
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
                prString[0] = p.Id;
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

        public void logNachricht(string nachricht)
        {
            this.log.Invoke((MethodInvoker)delegate()
            {
                this.log.Items.Add(nachricht);
            });
        }

        private void dataGridViewTeilnehmer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Teilnehmer t=this.con.selectTeilnehmer(int.Parse(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString()));
            this.Kontostand.Text = t.Kontostand.ToString();
            this.TN_Name.Text = t.VorName + " " + t.NachName;
        }

        private void TnHinzufügen_Click(object sender, EventArgs e)
        {
            Form nTN = new NeuerTN(this.con);
            nTN.ShowDialog();
        }

        private void TnHinzufügen_Leave(object sender, EventArgs e)
        {
            addTeilnehmer(con.selectTeilnehmerAll());
        }

        private void TnLöschen_Click(object sender, EventArgs e)
        {
            con.deleteTn(int.Parse(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString()));
        }

        private void TnInaktiv_Click(object sender, EventArgs e)
        {
            con.setTnInaktiv(int.Parse(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString()));
        }
    }
}