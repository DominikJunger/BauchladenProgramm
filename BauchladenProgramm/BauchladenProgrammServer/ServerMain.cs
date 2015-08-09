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
using System.Text.RegularExpressions;

namespace BauchladenProgrammServer
{
    public partial class Mainwindow : Form
    {
        private SQL_Connector con;
        private Server ser;
        private Log logFile;
      
        public Mainwindow()
        {
            InitializeComponent();
            // Startet den Serverprozess und wartet auf Anfragen
            ser=new Server(new IPEndPoint(IPAddress.Any, 3000), this);
            logFile = new Log(@"D:\Jula\Abrechnungen\Log\" + "Logfile" + DateTime.Now.ToShortDateString() + ".txt");

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
            logFile.close();
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
            String[] tnString = new String[4];
            foreach (Teilnehmer t in tn)
            {
                tnString[0] = t.Id.ToString();
                tnString[1] = t.VorName;
                tnString[2] = t.NachName;
                if (t.Inatkiv)
                {
                    tnString[3] = "Ja";
                }
                else
                {
                    tnString[3] = "Nein";
                }
                this.dataGridViewTeilnehmer.Invoke((MethodInvoker)delegate()
                {
                    dataGridViewTeilnehmer.Rows.Add(tnString);
                });
                
            }
        }
       
        private void addProdukte(List<Produkt> pr)
        {
            this.dataGridViewProdukt.Rows.Clear();
            String[] prString = new String[5];

            foreach (Produkt p in pr)
            {
                prString[0] = p.Id;
                prString[1] = p.Name;
                prString[2] = p.Preis.ToString("0.00");
                if(p.Verfügbar)
                {
                    prString[3] = "Verfügbar";
                }
                else
                {
                     prString[3] = "Nicht";
                }
                if (p.BücherT)
                {
                    prString[4] = "Ja";
                }
                else
                {
                    prString[4] = "Nein";
                }
               
                this.dataGridViewTeilnehmer.Invoke((MethodInvoker)delegate()
                {
                    dataGridViewProdukt.Rows.Add(prString);
                });

            }
            foreach(DataGridViewRow row in this.dataGridViewProdukt.Rows)
            {
                if (row.Cells[1].Value.Equals("Gelb"))
                {
                    row.Cells[0].Style.BackColor = Color.Yellow;
                    row.Cells[1].Style.BackColor = Color.Yellow;
                    row.Cells[2].Style.BackColor = Color.Yellow;
                    row.Cells[3].Style.BackColor = Color.Yellow;
                    row.Cells[4].Style.BackColor = Color.Yellow;
                }
                if (row.Cells[1].Value.Equals("Orange"))
                {
                    row.Cells[0].Style.BackColor = Color.Orange;
                    row.Cells[1].Style.BackColor = Color.Orange;
                    row.Cells[2].Style.BackColor = Color.Orange;
                    row.Cells[3].Style.BackColor = Color.Orange;
                    row.Cells[4].Style.BackColor = Color.Orange;
                }
                if (row.Cells[1].Value.Equals("Rot"))
                {
                    row.Cells[0].Style.BackColor = Color.Red;
                    row.Cells[1].Style.BackColor = Color.Red;
                    row.Cells[2].Style.BackColor = Color.Red;
                    row.Cells[3].Style.BackColor = Color.Red;
                    row.Cells[4].Style.BackColor = Color.Red;
                }
                if (row.Cells[1].Value.Equals("Pink"))
                {
                    row.Cells[0].Style.BackColor = Color.Pink;
                    row.Cells[1].Style.BackColor = Color.Pink;
                    row.Cells[2].Style.BackColor = Color.Pink;
                    row.Cells[3].Style.BackColor = Color.Pink;
                    row.Cells[4].Style.BackColor = Color.Pink;
                }
                if (row.Cells[1].Value.Equals("Lila"))
                {
                    row.Cells[0].Style.BackColor = Color.Purple;
                    row.Cells[1].Style.BackColor = Color.Purple;
                    row.Cells[2].Style.BackColor = Color.Purple;
                    row.Cells[3].Style.BackColor = Color.Purple;
                    row.Cells[4].Style.BackColor = Color.Purple;
                }
                if (row.Cells[1].Value.Equals("Dunkelblau"))
                {
                    row.Cells[0].Style.BackColor = Color.DarkBlue;
                    row.Cells[1].Style.BackColor = Color.DarkBlue;
                    row.Cells[2].Style.BackColor = Color.DarkBlue;
                    row.Cells[3].Style.BackColor = Color.DarkBlue;
                    row.Cells[4].Style.BackColor = Color.DarkBlue;
                }
                if (row.Cells[1].Value.Equals("Hellblau"))
                {
                    row.Cells[0].Style.BackColor = Color.LightBlue;
                    row.Cells[1].Style.BackColor = Color.LightBlue;
                    row.Cells[2].Style.BackColor = Color.LightBlue;
                    row.Cells[3].Style.BackColor = Color.LightBlue;
                    row.Cells[4].Style.BackColor = Color.LightBlue;
                }
                if (row.Cells[1].Value.Equals("Hellgrün"))
                {
                    row.Cells[0].Style.BackColor = Color.LightGreen;
                    row.Cells[1].Style.BackColor = Color.LightGreen;
                    row.Cells[2].Style.BackColor = Color.LightGreen;
                    row.Cells[3].Style.BackColor = Color.LightGreen;
                    row.Cells[4].Style.BackColor = Color.LightGreen;
                }
                if (row.Cells[1].Value.Equals("Dunkelgrün"))
                {
                    row.Cells[0].Style.BackColor = Color.DarkGreen;
                    row.Cells[1].Style.BackColor = Color.DarkGreen;
                    row.Cells[2].Style.BackColor = Color.DarkGreen;
                    row.Cells[3].Style.BackColor = Color.DarkGreen;
                    row.Cells[4].Style.BackColor = Color.DarkGreen;
                }
                if (row.Cells[1].Value.Equals("Braun"))
                {
                    row.Cells[0].Style.BackColor = Color.Brown;
                    row.Cells[1].Style.BackColor = Color.Brown;
                    row.Cells[2].Style.BackColor = Color.Brown;
                    row.Cells[3].Style.BackColor = Color.Brown;
                    row.Cells[4].Style.BackColor = Color.Brown;
                }

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

                addTeilnehmer(con.selectTeilnehmerAll(false));
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
            logFile.write(nachricht);
        }

        private void dataGridViewTeilnehmer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Teilnehmer t=this.con.selectTeilnehmer(int.Parse(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString()));
            this.Kontostand.Text = t.Kontostand.ToString();
            this.TN_Name.Text = t.VorName + " " + t.NachName;
        }

        private void TnHinzufügen_Click(object sender, EventArgs e)
        {
            this.con.addTeilnehmer(new Teilnehmer(this.vorname.Text, this.nachname.Text));
            this.vorname.Text = "";
            this.nachname.Text = "";
            Thread.Sleep(500);
            List<Teilnehmer> tn = con.selectTeilnehmerAll(false);
            addTeilnehmer(tn);
            if (ser.isConnected())
            {
                this.ser.TnAnAlle(tn);
            }
        }

        private void TnInaktiv_Click(object sender, EventArgs e)
        {
            con.setTnInaktiv(int.Parse(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString()));
            Thread.Sleep(500);
            List<Teilnehmer> tn = con.selectTeilnehmerAll(false);
            addTeilnehmer(tn);
            if (ser.isConnected())
            {
                this.ser.TnAnAlle(tn);
            }
        }

        private void TnEinzahlen_Click(object sender, EventArgs e)
        {
            if (this.einzahlung != null && this.einzahlung.Text != "" && double.Parse(this.einzahlung.Text) > 0)
            {
                con.setEinzahlung(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString(), this.einzahlung.Text);
                this.einzahlung.Text = "";
                Thread.Sleep(500);
                this.dataGridViewTeilnehmer_CellClick(null,null);
            }
            else
            {
                MessageBox.Show("Fehler bei der Einzahlung! Betrag muss größer 0 sein");
            }
        }

        private void PHinzugügen_Click(object sender, EventArgs e)
        {
            if (this.PName.Text != "" && this.PPreis.Text != "")
            {
                con.addProdukt(new Produkt(this.PName.Text, Decimal.Parse(this.PPreis.Text), this.checkBüchertisch.Checked));
                this.PName.Text = "";
                this.PPreis.Text = "";
                this.checkBüchertisch.Checked = false;
                Thread.Sleep(500);
                List<Produkt> pr = con.selectProduktAll();
                this.addProdukte(pr);
                if (ser.isConnected())
                {
                    this.ser.PrAnAlle(pr);
                }
            }
            else
            {
                MessageBox.Show("Bitte Name und Preis des Produkts ausfüllen");
            }
        }

        private void PLöschen_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Wollen Sie wirklich das ausgewählte Produkt löschen? Dies hat zur Folge das die Abrechnung bei den TN nicht mehr korrekt ist. \n Deshalb nur wenn alle abgerechnet sind ausführen","Sicherheitsabfrage",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                con.deletePr(int.Parse(dataGridViewProdukt.CurrentRow.Cells[0].Value.ToString()));
                Thread.Sleep(500);
                List<Produkt> pr = con.selectProduktAll();
                this.addProdukte(pr);
                if (ser.isConnected())
                {
                    this.ser.PrAnAlle(pr);
                }
            }
        }

        private void PInaktiv_Click(object sender, EventArgs e)
        {
            con.setVerfügbarkeit(int.Parse(dataGridViewProdukt.CurrentRow.Cells[0].Value.ToString()));
            Thread.Sleep(500);
            List<Produkt> pr = con.selectProduktAll();
            this.addProdukte(pr);
            if (ser.isConnected())
            {
                this.ser.PrAnAlle(pr);
            }
        }

        private void TnAuszahlen_Click(object sender, EventArgs e)
        {
            // PDF für Auszahlung erstellen
            PDFCreator pdfc = new PDFCreator(@"D:\Jula\Abrechnungen\Auszahlung\" + dataGridViewTeilnehmer.CurrentRow.Cells[1].Value.ToString() +"_"+ dataGridViewTeilnehmer.CurrentRow.Cells[2].Value.ToString() + ".pdf");
            pdfc.createAuszahlung(con.PDF(int.Parse(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString())));
            con.deleteTn(int.Parse(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString()));
            System.Diagnostics.Process.Start(@"D:\Jula\Abrechnungen\Auszahlung\" + dataGridViewTeilnehmer.CurrentRow.Cells[1].Value.ToString() + "_" + dataGridViewTeilnehmer.CurrentRow.Cells[2].Value.ToString() + ".pdf");
            Thread.Sleep(200);
            List<Teilnehmer> tn = con.selectTeilnehmerAll(false);
            addTeilnehmer(tn);
            if (ser.isConnected())
            {
                this.ser.TnAnAlle(tn);
            }
            
        }

        private void einzahlung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !e.KeyChar.Equals(','))
                e.Handled = true;
        }

        private void vorname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), "[a-zäöüA-ZÄÖÜß]") && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tagesabschluss_Click(object sender, EventArgs e)
        {
            try
            {
                List<PDFAuszahlung> pdfA=new List<PDFAuszahlung>();
                System.IO.Directory.CreateDirectory(@"D:\Jula\Abrechnungen\Tagesabschluss\Teilnehmer\" + DateTime.Today.ToShortDateString());
                foreach (Teilnehmer t in con.selectTeilnehmerAll(false))
                {
                    PDFCreator pdfc = new PDFCreator(@"D:\Jula\Abrechnungen\Tagesabschluss\Teilnehmer\" + DateTime.Today.ToShortDateString() + "\\" + t.VorName + "_" + t.NachName + "_" + t.Id + "_" + DateTime.Today.ToShortDateString() + ".pdf");
                    PDFAuszahlung tmp = con.PDF(t.Id);
                    pdfA.Add(tmp);
                    pdfc.createTagesabschluss(tmp);
                }
                PDFCreator pdf = new PDFCreator(@"D:\Jula\Abrechnungen\Tagesabschluss\Teilnehmer\"+"GesamterTagesabschluss_" + DateTime.Today.ToShortDateString() + ".pdf");
                pdf.createTagesabschlussAlle(pdfA);

                MessageBox.Show("Pdf´s wurden erfolgreich erstellt");
                this.logNachricht("Tagesabschluss erfolgreich erstellt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Tagesabschluss: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void alleAuszahlen_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Teilnehmer t in con.selectTeilnehmerAll(false))
                {
                    // PDF für Auszahlung erstellen
                    PDFCreator pdfc = new PDFCreator(@"D:\Jula\Abrechnungen\Auszahlung\" + t.VorName + "_" + t.NachName + "_" + t.Id + "_" + DateTime.Today.ToShortDateString() + ".pdf");
                    pdfc.createAuszahlung(con.PDF(t.Id));
                    con.deleteTn(t.Id);
                }
                Thread.Sleep(300);
                List<Teilnehmer> tn = con.selectTeilnehmerAll(false);
                addTeilnehmer(tn);
                if (ser.isConnected())
                {
                    this.ser.TnAnAlle(tn);
                }
                MessageBox.Show("Pdf´s wurden erfolgreich erstellt");
                this.logNachricht("Auszahlung aller Teilnehmer erfolgreich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Auszahlen: " + ex.Message,"Fehler",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void CsvEinlesen_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CSV_Reader r = new CSV_Reader();
                foreach(Teilnehmer t in r.ReadCSV(this.openFileDialog1.FileName))
                {
                    con.addTeilnehmer(t);
                }
                this.addTeilnehmer(con.selectTeilnehmerAll(false));
            }
        }

        private void stückelung_Click(object sender, EventArgs e)
        {
            try
            {
                PDFCreator pdfc = new PDFCreator(@"D:\Jula\Abrechnungen\" +"Aktuelle_Stückelung_"+ DateTime.Today.ToShortDateString() + ".pdf");
                pdfc.createStückelung(con.selectTeilnehmerAll(true));
                System.Diagnostics.Process.Start(@"D:\Jula\Abrechnungen\" + "Aktuelle_Stückelung_" + DateTime.Today.ToShortDateString() + ".pdf");
                MessageBox.Show("Pdf für die Stückelung wurde erfolgreich erstellt");
                this.logNachricht("Stückelung erfolgreich erstellt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler bei der Stückelung: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void statistik_Click(object sender, EventArgs e)
        {
            try
            {
                PDFCreator pdfc = new PDFCreator(@"D:\Jula\Abrechnungen\" + "StatistikProdukte_" + DateTime.Today.ToShortDateString() + ".pdf");
                pdfc.createStatistik(con.getStatistik());
                System.Diagnostics.Process.Start((@"D:\Jula\Abrechnungen\" + "StatistikProdukte_" + DateTime.Today.ToShortDateString() + ".pdf"));
                MessageBox.Show("Statistik von verkauften Produkten wurde erfolgreich erstellt");
                this.logNachricht("Statistik von verkauften Produkten wurde erfolgreich erstellt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler bei der Statistik von verkauften Produkten: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}