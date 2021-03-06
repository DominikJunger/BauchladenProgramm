﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private List<Produkt> produktVerwaltungB;
        

        public Mainwindow(string ip)
        {
            InitializeComponent();
            this.ip = ip;
            this.produktVerwaltung = new List<Produkt>();
            this.produktVerwaltungB = new List<Produkt>();  
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

        public void addPr(Produkt p, bool bücherT)
        {
            if (p != null)
            {
                String [] pr = new String[3];
                pr[0]=p.Id.ToString();
                pr[1]=p.Name;
                pr[2]=p.Preis.ToString("0.00");
                if (!bücherT)
                {
                    this.dataGridViewProdukt.Invoke((MethodInvoker)delegate()
                    {
                        this.dataGridViewProdukt.Rows.Add(pr);
                    });
                }
                else
                {
                    this.dataGridViewProduktB.Invoke((MethodInvoker)delegate()
                    {
                        this.dataGridViewProduktB.Rows.Add(pr);
                        foreach (DataGridViewRow row in this.dataGridViewProduktB.Rows)
                        {
                            if (row.Cells[1].Value.Equals("Gelb"))
                            {
                                row.Cells[1].Style.BackColor = Color.Yellow;
                            }
                            if (row.Cells[1].Value.Equals("Orange"))
                            {
                                row.Cells[1].Style.BackColor = Color.Orange;
                            }
                            if (row.Cells[1].Value.Equals("Rot"))
                            {
                                row.Cells[1].Style.BackColor = Color.Red;
                            }
                            if (row.Cells[1].Value.Equals("Pink"))
                            {
                                row.Cells[1].Style.BackColor = Color.Pink;
                            }
                            if (row.Cells[1].Value.Equals("Lila"))
                            {
                                row.Cells[1].Style.BackColor = Color.Purple;
                            }
                            if (row.Cells[1].Value.Equals("Dunkelblau"))
                            {
                                row.Cells[1].Style.BackColor = Color.DarkBlue;
                            }
                            if (row.Cells[1].Value.Equals("Hellblau"))
                            {
                                row.Cells[1].Style.BackColor = Color.LightBlue;
                            }
                            if (row.Cells[1].Value.Equals("Hellgrün"))
                            {
                                row.Cells[1].Style.BackColor = Color.LightGreen;
                            }
                            if (row.Cells[1].Value.Equals("Dunkelgrün"))
                            {
                                row.Cells[1].Style.BackColor = Color.DarkGreen;
                            }
                            if (row.Cells[1].Value.Equals("Braun"))
                            {
                                row.Cells[1].Style.BackColor = Color.Brown;
                            }
                        }
                    });
                }
            }
        }

        public void addTn(Teilnehmer t)
        {
            if (t != null)
            {
                String[] tn = new String[4];
                tn[0] = t.Id.ToString();
                tn[1] = t.VorName;
                tn[2] = t.NachName;
                tn[3] = t.Inaktiv.ToString();
                this.dataGridViewProdukt.Invoke((MethodInvoker)delegate()
                {
                    if (!t.Inaktiv)
                    {
                        this.dataGridViewTeilnehmer.Rows.Add(tn);
                    }
                    else
                    {
                        this.dataGridViewTeilnehmer.Rows.Add(tn);
                        DataGridViewRow row = dataGridViewTeilnehmer.Rows[dataGridViewTeilnehmer.Rows.Count-1];
                        row.Cells[0].Style.BackColor=Color.Red;
                        row.Cells[1].Style.BackColor = Color.Red;
                        row.Cells[2].Style.BackColor = Color.Red;
                    }
                });
                this.dataGridViewTeilnehmerEinzahlung.Invoke((MethodInvoker)delegate()
                {
                    if (!t.Inaktiv)
                    {
                        this.dataGridViewTeilnehmerEinzahlung.Rows.Add(tn);
                    }
                    else
                    {
                        this.dataGridViewTeilnehmerEinzahlung.Rows.Add(tn);
                        DataGridViewRow row = dataGridViewTeilnehmerEinzahlung.Rows[dataGridViewTeilnehmerEinzahlung.Rows.Count - 1];
                        row.Cells[0].Style.BackColor = Color.Red;
                        row.Cells[1].Style.BackColor = Color.Red;
                        row.Cells[2].Style.BackColor = Color.Red;
                    }
                });
                this.dataGridViewTeilnehmerB.Invoke((MethodInvoker)delegate()
                {
                    if (!t.Inaktiv)
                    {
                        this.dataGridViewTeilnehmerB.Rows.Add(tn);
                    }
                    else
                    {
                        this.dataGridViewTeilnehmerB.Rows.Add(tn);
                        DataGridViewRow row = dataGridViewTeilnehmerB.Rows[dataGridViewTeilnehmerB.Rows.Count - 1];
                        row.Cells[0].Style.BackColor = Color.Red;
                        row.Cells[1].Style.BackColor = Color.Red;
                        row.Cells[2].Style.BackColor = Color.Red;
                    }
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
                            this.TN_NameB.Text = this.TN_Name.Text;
                            this.Kontostand.Text = String.Format("{0:F2}", kontostand);
                            this.KontostandEinzahlung.Text = String.Format("{0:F2}", kontostand) +" €";
                            this.KontostandB.Text = String.Format("{0:F2}", kontostand);
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
            this.dataGridViewProduktB.Invoke((MethodInvoker)delegate()
            {
                this.dataGridViewProduktB.Rows.Clear();
            });
        }
        public void leere_dataGridViewTeilnehmer()
        {
            this.dataGridViewTeilnehmer.Invoke((MethodInvoker)delegate()
            {
                this.dataGridViewTeilnehmer.Rows.Clear();
            });
            this.dataGridViewTeilnehmerB.Invoke((MethodInvoker)delegate()
            {
                this.dataGridViewTeilnehmerB.Rows.Clear();
            });
            this.dataGridViewTeilnehmerEinzahlung.Invoke((MethodInvoker)delegate()
            {
                this.dataGridViewTeilnehmerEinzahlung.Rows.Clear();
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
            if (sender == this.dataGridViewProdukt)
            {
                if (this.TN_Name.Text != null && this.TN_Name.Text != "")
                {
                    char tmp = e.KeyChar;
                    int zahl = Int32.Parse(tmp.ToString());

                    Int32 selectedRowCount = dataGridViewProdukt.Rows.GetRowCount(DataGridViewElementStates.Selected);
                    if (selectedRowCount == 1)
                    {
                        this.dataGridViewTeilnehmer.Enabled = false;
                        foreach (TabPage tab in this.tabControl1.TabPages)
                        {
                            tab.Enabled = false;
                        }
                        (this.tabControl1.TabPages[0] as TabPage).Enabled = true;

                        this.produktVerwaltung.Add(new Produkt(dataGridViewProdukt.SelectedRows[0].Cells[0].Value.ToString(),
                            dataGridViewProdukt.SelectedRows[0].Cells[1].Value.ToString(),
                            dataGridViewProdukt.SelectedRows[0].Cells[2].Value.ToString(),
                            zahl));
                        this.einkaufslisteZusammenfassen_darstellen(false);
                    }
                }
                else
                {
                    MessageBox.Show("Bitte zuerst einen Teilnehmer auswählen");
                }
            }
            else if(sender == this.dataGridViewProduktB)
            {
                if (this.TN_NameB.Text != null && this.TN_NameB.Text != "")
                {
                    char tmp = e.KeyChar;
                    int zahl = Int32.Parse(tmp.ToString());

                    Int32 selectedRowCount = dataGridViewProduktB.Rows.GetRowCount(DataGridViewElementStates.Selected);
                    if (selectedRowCount == 1)
                    {
                        this.dataGridViewTeilnehmerB.Enabled = false;
                        foreach (TabPage tab in this.tabControl1.TabPages)
                        {
                            tab.Enabled = false;
                        }
                        (this.tabControl1.TabPages[1] as TabPage).Enabled = true;

                        this.produktVerwaltungB.Add(new Produkt(dataGridViewProduktB.SelectedRows[0].Cells[0].Value.ToString(),
                            dataGridViewProduktB.SelectedRows[0].Cells[1].Value.ToString(),
                            dataGridViewProduktB.SelectedRows[0].Cells[2].Value.ToString(),
                            zahl));
                        this.einkaufslisteZusammenfassen_darstellen(true);
                    }
                }
                else
                {
                    MessageBox.Show("Bitte zuerst einen Teilnehmer auswählen");
                }
            }
        }

        private void dataGridViewEinkauf_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tmp = e.KeyChar;
            int zahl = Int32.Parse(tmp.ToString());

            if (sender == this.dataGridViewEinkauf)
            {
                Int32 selectedRowCount = dataGridViewProdukt.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount == 1)
                {
                    foreach (Produkt p in produktVerwaltung)
                    {
                        if (p.Id == Int32.Parse(dataGridViewEinkauf.SelectedRows[0].Cells[0].Value.ToString()))
                        {
                            p.Anzahl = zahl;
                        }
                    }
                    this.einkaufslisteZusammenfassen_darstellen(false);
                }
            }
            else if (sender == this.dataGridViewEinkaufB)
            {
                Int32 selectedRowCount = dataGridViewProduktB.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount == 1)
                {
                    foreach (Produkt p in produktVerwaltungB)
                    {
                        if (p.Id == Int32.Parse(dataGridViewEinkaufB.SelectedRows[0].Cells[0].Value.ToString()))
                        {
                            p.Anzahl = zahl;
                        }
                    }
                    this.einkaufslisteZusammenfassen_darstellen(true);
                }
            }
        }

        private void einkaufslisteZusammenfassen_darstellen(bool büchertisch)
        {
            if (!büchertisch)
            {
                for (int i = 0; i < this.produktVerwaltung.Count; i++)
                {
                    for (int j = i + 1; j < this.produktVerwaltung.Count; j++)
                    {
                        if (this.produktVerwaltung[i].Id == this.produktVerwaltung[j].Id)
                        {
                            this.produktVerwaltung[i].Anzahl += this.produktVerwaltung[j].Anzahl;
                            this.produktVerwaltung.RemoveAt(j);
                        }
                    }
                }

                this.dataGridViewEinkauf.Rows.Clear();

                double einkaufslistesumme = 0;

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
                this.einkaufslistesumme.Text = String.Format("{0:F2}",einkaufslistesumme);
            }
            else
            {
                for (int i = 0; i < this.produktVerwaltungB.Count; i++)
                {
                    for (int j = i + 1; j < this.produktVerwaltungB.Count; j++)
                    {
                        if (this.produktVerwaltungB[i].Id == this.produktVerwaltungB[j].Id)
                        {
                            this.produktVerwaltungB[i].Anzahl += this.produktVerwaltungB[j].Anzahl;
                            this.produktVerwaltungB.RemoveAt(j);
                        }
                    }
                }

                this.dataGridViewEinkaufB.Rows.Clear();

                double einkaufslistesumme = 0;

                for (int i = 0; i < produktVerwaltungB.Count; i++)
                {
                    if (produktVerwaltungB[i].Anzahl <= 0)
                    {
                        this.produktVerwaltungB.RemoveAt(i);
                        i--; // wenn das erste Produkt gelöscht wird ist Count kleiner als die Bedingung --> nächstes Produkt nicht dargestellt
                    }
                    else
                    {
                        String[] pr = new String[4];

                        pr[0] = produktVerwaltungB[i].Id.ToString();
                        pr[1] = produktVerwaltungB[i].Name;
                        pr[2] = produktVerwaltungB[i].Preis.ToString();
                        pr[3] = produktVerwaltungB[i].Anzahl.ToString();
                        this.dataGridViewProduktB.Invoke((MethodInvoker)delegate()
                        {
                            this.dataGridViewEinkaufB.Rows.Add(pr);
                        });
                        einkaufslistesumme += produktVerwaltungB[i].Preis * produktVerwaltungB[i].Anzahl;
                    }
                }
                this.einkaufslistesummeB.Text = String.Format("{0:F2}", einkaufslistesumme);
            }
        }

        private void dataGridViewTeilnehmer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender == this.dataGridViewTeilnehmer)
            {
                if (dataGridViewTeilnehmer.CurrentRow.Cells[3].Value.ToString().Equals("False"))
                {
                    this.dataGridViewEinkauf.Enabled = true;
                    this.dataGridViewProdukt.Enabled = true;
                    this.send.Enabled = true;
                    this.löschen.Enabled = true;
                    this.c.getKontostand(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString());
                    this.Kontostand.Text = "";
                    this.TN_Name.Text = "";
                    this.dataGridViewTeilnehmerB.CurrentCell = this.dataGridViewTeilnehmerB.Rows[this.dataGridViewTeilnehmer.CurrentCell.RowIndex].Cells[1];
                    this.dataGridViewTeilnehmerEinzahlung.CurrentCell = this.dataGridViewTeilnehmerEinzahlung.Rows[this.dataGridViewTeilnehmer.CurrentCell.RowIndex].Cells[1];
                }
                else
                {
                    this.dataGridViewEinkauf.Enabled = false;
                    this.dataGridViewProdukt.Enabled = false;
                    this.send.Enabled = false;
                    this.löschen.Enabled = false;
                    this.Kontostand.Text = "";
                    this.TN_Name.Text = "";
                }
            }
            else if (sender == this.dataGridViewTeilnehmerB)
            {
                if (dataGridViewTeilnehmerB.CurrentRow.Cells[3].Value.ToString().Equals("False"))
                {
                    this.dataGridViewEinkaufB.Enabled = true;
                    this.dataGridViewProduktB.Enabled = true;
                    this.sendB.Enabled = true;
                    this.löschenB.Enabled = true;
                    this.c.getKontostand(dataGridViewTeilnehmerB.CurrentRow.Cells[0].Value.ToString());
                    this.KontostandB.Text = "";
                    this.TN_NameB.Text = "";
                    this.dataGridViewTeilnehmer.CurrentCell = this.dataGridViewTeilnehmer.Rows[this.dataGridViewTeilnehmerB.CurrentCell.RowIndex].Cells[1];
                    this.dataGridViewTeilnehmerEinzahlung.CurrentCell = this.dataGridViewTeilnehmerEinzahlung.Rows[this.dataGridViewTeilnehmerB.CurrentCell.RowIndex].Cells[1];
                }
                else
                {
                    this.dataGridViewEinkaufB.Enabled = false;
                    this.dataGridViewProduktB.Enabled = false;
                    this.sendB.Enabled = false;
                    this.löschenB.Enabled = false;
                    this.KontostandB.Text = "";
                    this.TN_NameB.Text = "";
                }
            }
            else if (sender == this.dataGridViewTeilnehmerEinzahlung)
            {
                if (dataGridViewTeilnehmerEinzahlung.CurrentRow.Cells[3].Value.ToString().Equals("False"))
                {
                    this.einzahlen.Enabled = true;
                    this.c.getKontostand(dataGridViewTeilnehmerEinzahlung.CurrentRow.Cells[0].Value.ToString());
                    this.KontostandEinzahlung.Text = "";
                    this.TN_NameEinzahlung.Text = "";
                    this.textBoxEinzahlung.Text = "";
                    this.dataGridViewTeilnehmer.CurrentCell = this.dataGridViewTeilnehmer.Rows[this.dataGridViewTeilnehmerEinzahlung.CurrentCell.RowIndex].Cells[1];
                    this.dataGridViewTeilnehmerB.CurrentCell = this.dataGridViewTeilnehmerB.Rows[this.dataGridViewTeilnehmerEinzahlung.CurrentCell.RowIndex].Cells[1];
                }
                else
                {
                    this.einzahlen.Enabled = false;
                }
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            if (sender == this.send)
            {
                if ((double.Parse(this.Kontostand.Text) - double.Parse(this.einkaufslistesumme.Text)) >= 0)
                {
                    foreach (DataGridViewRow row in dataGridViewEinkauf.Rows)
                    {
                        this.c.setBuy(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString(), row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString());
                    }
                    c.setBuyEnd(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString());
                    this.c.getKontostand(dataGridViewTeilnehmer.CurrentRow.Cells[0].Value.ToString());
                    this.Kontostand.Text = "";
                    this.TN_Name.Text = "";
                    this.einkaufslistesumme.Text = "0.00";
                    this.dataGridViewEinkauf.Rows.Clear();
                    this.produktVerwaltung.Clear();
                    this.dataGridViewTeilnehmer.Enabled = true;
                    foreach (TabPage tab in this.tabControl1.TabPages)
                    {
                        tab.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Teilnehmer hat nicht genügend Geld auf dem Konto");
                }
            } if (sender == this.sendB)
            {
                if ((double.Parse(this.KontostandB.Text) - double.Parse(this.einkaufslistesummeB.Text)) >= 0)
                {
                    foreach (DataGridViewRow row in dataGridViewEinkaufB.Rows)
                    {
                        this.c.setBuy(dataGridViewTeilnehmerB.CurrentRow.Cells[0].Value.ToString(), row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString());
                    }
                    c.setBuyEnd(dataGridViewTeilnehmerB.CurrentRow.Cells[0].Value.ToString());
                    this.c.getKontostand(dataGridViewTeilnehmerB.CurrentRow.Cells[0].Value.ToString());
                    this.KontostandB.Text = "";
                    this.TN_NameB.Text = "";
                    this.einkaufslistesummeB.Text = "0.00";
                    this.dataGridViewEinkaufB.Rows.Clear();
                    this.produktVerwaltungB.Clear();
                    this.dataGridViewTeilnehmerB.Enabled = true;
                    foreach (TabPage tab in this.tabControl1.TabPages)
                    {
                        tab.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Teilnehmer hat nicht genügend Geld auf dem Konto");
                }
            }
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
                             dv.CurrentCell = dv.Rows[row.Index].Cells[0];
                        }
                    }
                }
                this.dataGridViewTeilnehmer_CellClick(null,null);
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
                else if (sender == this.TeilnehmerSucheB)
                {
                    this.SucheNachTeilnehmer(this.TeilnehmerSucheB.Text, dataGridViewTeilnehmerB);
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
            if (sender == this.löschen)
            {
                this.dataGridViewEinkauf.Rows.Clear();
                this.produktVerwaltung.Clear();
                this.einkaufslistesumme.Text = "0.00";
                this.dataGridViewTeilnehmer.Enabled = true;
                foreach (TabPage tab in this.tabControl1.TabPages)
                {
                    tab.Enabled = true;
                }
            } if (sender == this.löschenB)
            {
                this.dataGridViewEinkaufB.Rows.Clear();
                this.produktVerwaltungB.Clear();
                this.einkaufslistesummeB.Text = "0.00";
                this.dataGridViewTeilnehmerB.Enabled = true;
                foreach (TabPage tab in this.tabControl1.TabPages)
                {
                    tab.Enabled = true;
                }
            }
        }

        private void einzahlen_Click(object sender, EventArgs e)
        {
            if (this.textBoxEinzahlung != null && this.textBoxEinzahlung.Text != "" && double.Parse(this.textBoxEinzahlung.Text) > 0)
            {
                this.c.setEinzahlung(dataGridViewTeilnehmerEinzahlung.CurrentRow.Cells[0].Value.ToString(), decimal.Parse(this.textBoxEinzahlung.Text));
                this.c.getKontostand(dataGridViewTeilnehmerEinzahlung.CurrentRow.Cells[0].Value.ToString());
                this.textBoxEinzahlung.Text = "";
            }
            else
            {
                MessageBox.Show("Der Betrag zum Einzahlen muss größer als 0 sein");
            }
        }

        private void textBoxEinzahlung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !e.KeyChar.Equals(','))
                e.Handled = true; 
        }
    }
}
