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
using System.Net.Sockets;
using System.Threading;

namespace BauchladenProgramm
{
    public partial class Mainwindow : Form
    {
        private Connector.Connector c;
        private string ip;

        private List<Produkt> produktVerwaltung;
        

        public Mainwindow(string ip)
        {
            InitializeComponent();
            this.ip = ip;
            this.produktVerwaltung = new List<Produkt>();  
        }

        private void Mainwindow_Load(object sender, EventArgs e)
        {
            try
            {
                c = new Connector.Connector(ip, 3000, this);
                c.connectToServer();
                c.getProductList();
                c.getTeilnehmerList();
            }
            catch (SocketException sx)
            {
                this.Close();
                MessageBox.Show(sx.Message);

                Thread openConnectionD=new Thread(this.openConnectionDialog);
                openConnectionD.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Öffnet bei einem Verbindungsfehler das ConnectionDialog wieder
        private void openConnectionDialog(){
            Form cd = new ConnectionDialog();
            cd.ShowDialog();
        }

        public void addPr(Produkt p)
        {
            if (p != null)
            {
                String [] pr = new String[3];
                pr[0]=p.Id.ToString();
                pr[1]=p.Name;
                pr[2]=p.Preis.ToString("0.00");
                this.dataGridViewProdukt.Invoke((MethodInvoker)delegate()
                {
                    this.dataGridViewProdukt.Rows.Add(pr);
                });
            }
        }

        public void addTn(Teilnehmer t)
        {
            if (t != null)
            {
                String[] tn = new String[3];
                tn[0] = t.Id.ToString();
                tn[1] = t.VorName;
                tn[2] = t.NachName;
                this.dataGridViewProdukt.Invoke((MethodInvoker)delegate()
                {
                    this.dataGridViewTeilnehmer.Rows.Add(tn);
                    //TeilnehmerSucheComplete.AddRange(pr);
                    //this.TeilnehmerSuche.AutoCompleteCustomSource = TeilnehmerSucheComplete;
                });
                this.dataGridViewTeilnehmerEinzahlung.Invoke((MethodInvoker)delegate()
                {
                    this.dataGridViewTeilnehmerEinzahlung.Rows.Add(tn);
                });
                this.TeilnehmerSuche.Invoke((MethodInvoker)delegate()
                {
                    //this.TeilnehmerSuche.AutoCompleteCustomSource.AddRange(tn);
                });
            }
        }

        public void kontostandAnzeigen(int id,double kontostand)
        {
            this.Kontostand.Invoke((MethodInvoker)delegate()
            {
                this.KontostandEinzahlung.Invoke((MethodInvoker)delegate()
                {
                    for(int i=0;i<dataGridViewTeilnehmer.Rows.Count;i++)
                    {
                        if (dataGridViewTeilnehmer.Rows[i].Cells[0].Value.ToString().Equals(id.ToString()))
                        {
                            this.TN_Name.Text = dataGridViewTeilnehmer.Rows[i].Cells[1].Value.ToString()
                            +" "
                            + dataGridViewTeilnehmer.Rows[i].Cells[2].Value.ToString();
                            this.TN_NameEinzahlung.Text = this.TN_Name.Text;
                            this.Kontostand.Text = kontostand.ToString();
                            this.KontostandEinzahlung.Text = kontostand.ToString();
                        }
                    }
                    
                }); 
            });
        }

        public void leere_dataGridViewProdukt()
        {
            this.dataGridViewProdukt.Invoke((MethodInvoker)delegate()
            {
                this.dataGridViewProdukt.Rows.Clear();
            });
        }
        public void leere_dataGridViewTeilnehmer()
        {
            this.dataGridViewTeilnehmer.Invoke((MethodInvoker)delegate()
            {
                this.dataGridViewTeilnehmer.Rows.Clear();
            });
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewProdukt_KeyPress(sender, new KeyPressEventArgs('1'));
        }

        private void Mainwindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.c.closeConnection();
            Application.Exit();
        }

        private void dataGridViewProdukt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.TN_Name.Text != null && this.TN_Name.Text != "")
            {
                char tmp = e.KeyChar;
                int zahl = Int32.Parse(tmp.ToString());

                Int32 selectedRowCount = dataGridViewProdukt.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount == 1)
                {
                    this.dataGridViewTeilnehmer.Enabled = false;
                    this.produktVerwaltung.Add(new Produkt(dataGridViewProdukt.SelectedRows[0].Cells[0].Value.ToString(),
                        dataGridViewProdukt.SelectedRows[0].Cells[1].Value.ToString(),
                        dataGridViewProdukt.SelectedRows[0].Cells[2].Value.ToString(),
                        zahl));
                    this.einkaufslisteZusammenfassen_darstellen();
                }
            }
            else
            {
                MessageBox.Show("Bitte zuerst einen Teilnehmer auswählen");
            }
        }

        private void dataGridViewEinkauf_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tmp = e.KeyChar;
            int zahl = Int32.Parse(tmp.ToString());

            Int32 selectedRowCount = dataGridViewProdukt.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount == 1)
            {
                foreach (Produkt p in produktVerwaltung)
                {
                    if (p.Id == Int32.Parse(dataGridViewEinkauf.SelectedRows[0].Cells[0].Value.ToString()))
                    {
                        p.Anzahl -= zahl;
                    }
                }
                this.einkaufslisteZusammenfassen_darstellen();
            }
        }

        private void einkaufslisteZusammenfassen_darstellen()
        {
            for(int i=0;i<this.produktVerwaltung.Count;i++)
            {
                for(int j=i+1;j<this.produktVerwaltung.Count;j++)
                {
                    if(this.produktVerwaltung[i].Id == this.produktVerwaltung[j].Id)
                    {
                        this.produktVerwaltung[i].Anzahl += this.produktVerwaltung[j].Anzahl;
                        this.produktVerwaltung.RemoveAt(j);
                    }
                } 
            }

            this.dataGridViewEinkauf.Rows.Clear();

            double einkaufslistesumme=0;

            for (int i = 0; i < produktVerwaltung.Count; i++)
            {
                if (produktVerwaltung[i].Anzahl <= 0)
                {
                    this.produktVerwaltung.RemoveAt(i);
                    i--; // wenn das erste Produkt gelöscht wird ist Count kleiner als die Bedingung --> nächstes Produkt nicht dargestellt
                }
                else
                {
                    String[] pr = new String[4];
                    
                    pr[0] = produktVerwaltung[i].Id.ToString();
                    pr[1] = produktVerwaltung[i].Name;
                    pr[2] = produktVerwaltung[i].Preis.ToString();
                    pr[3] = produktVerwaltung[i].Anzahl.ToString();
                    this.dataGridViewProdukt.Invoke((MethodInvoker)delegate()
                    {
                        this.dataGridViewEinkauf.Rows.Add(pr);
                    });
                    einkaufslistesumme += produktVerwaltung[i].Preis * produktVerwaltung[i].Anzahl;
                }
            }
            this.einkaufslistesumme.Text = einkaufslistesumme.ToString();
        }

        private void dataGridViewTeilnehmer_CellClick(object sender, DataGridViewCellEventArgs e)
        {     
            this.c.getKontostand(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString());
            this.Kontostand.Text = "";
            this.TN_Name.Text = "";
        }

        private void dataGridViewTeilnehmerEinzahlung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.c.getKontostand(dataGridViewTeilnehmerEinzahlung.CurrentRow.Cells[0].Value.ToString());
            this.KontostandEinzahlung.Text = "";
            this.TN_NameEinzahlung.Text = "";
        }

        private void send_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridViewEinkauf.Rows)
            {
                this.c.setBuy(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString(), row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString());
            }
            this.c.getKontostand(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString());
            this.Kontostand.Text = "";
            this.TN_Name.Text = "";
            this.dataGridViewEinkauf.Rows.Clear();
            this.produktVerwaltung.Clear();
            this.dataGridViewTeilnehmer.Enabled = true;
        }

        private void SucheNachTeilnehmer(string searchValue, DataGridView dv)
        {
            dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                    foreach (DataGridViewRow row in dv.Rows)
                    {
                        for (int CellIndex = 0; CellIndex < row.Cells.Count; CellIndex++)
                        {
                            if (row.Cells[CellIndex].Value.ToString().Equals(searchValue))
                            {
                                dv.Rows[row.Index].Selected = true;
                            }
                        }
                    }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void TeilnehmerSuche_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.Equals('\r'))
            {
                if(sender == this.TeilnehmerSuche)
                {
                    this.SucheNachTeilnehmer(this.TeilnehmerSuche.Text, dataGridViewTeilnehmer);
                }
                else if (sender == this.TeilnehmerSucheEinzahlung)
                {
                    this.SucheNachTeilnehmer(this.TeilnehmerSucheEinzahlung.Text, dataGridViewTeilnehmerEinzahlung);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 2)
            {
                DialogResult result = MessageBox.Show("Soll der Änderungsbereich betreten werden","Änderungsbereich betreten",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.tabControl1.SelectedIndex = 2;
                }
                else
                {
                    this.tabControl1.SelectedIndex = 0;
                }
            }
        }

        private void löschen_Click(object sender, EventArgs e)
        {
            this.dataGridViewEinkauf.Rows.Clear();
            this.produktVerwaltung.Clear();
            this.dataGridViewTeilnehmer.Enabled=true;
        }
    }
}
