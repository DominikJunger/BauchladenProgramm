﻿using System;
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
                String[] pr = new String[3];
                pr[0] = t.Id.ToString();
                pr[1] = t.VorName;
                pr[2] = t.NachName;
                this.dataGridViewProdukt.Invoke((MethodInvoker)delegate()
                {
                    this.dataGridViewTeilnehmer.Rows.Add(pr);
                });
            }
        }

        public void kontostandAnzeigen(double kontostand)
        {
            this.Kontostand.Invoke((MethodInvoker)delegate()
            {
                this.Kontostand.Text = kontostand.ToString();
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

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridViewProdukt_KeyPress(sender, new KeyPressEventArgs('1'));
        }

        private void dataGridViewTeilnehmer_CellClick(object sender, DataGridViewCellEventArgs e)
        {     
            this.c.getKontostand(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString());
            this.Kontostand.Text = "";
            this.TN_Name.Text = dataGridViewTeilnehmer.CurrentRow.Cells[1].Value.ToString()
                + " "
                + dataGridViewTeilnehmer.CurrentRow.Cells[2].Value.ToString();
        }

        private void send_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridViewEinkauf.Rows)
            {
            this.c.setBuy(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString(),row.Cells[0].Value.ToString());
            }
        }

        private void TeilnehmerSuche_TextChanged(object sender, EventArgs e)
        {
            this.SucheNachTeilnehmer(this.TeilnehmerSuche.Text, dataGridViewTeilnehmer);
        }

        private void SucheNachTeilnehmer(string searchValue, DataGridView dv)
        {
            int rowIndex = 1;  //this one is depending on the position of cell or column
            //string first_row_data=dataGridView1.Rows[0].Cells[0].Value.ToString() ;

            dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResulet = true;
                foreach (DataGridViewRow row in dv.Rows)
                {
                    if (row.Cells[rowIndex].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        dv.Rows[rowIndex].Selected = true;
                        rowIndex++;
                        valueResulet = false;
                    }
                }
                if (valueResulet != false)
                {
                    MessageBox.Show("Es konnte kein Eintrag gefunden werden mit dem Wert: " + searchValue, "Kein Treffer");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
