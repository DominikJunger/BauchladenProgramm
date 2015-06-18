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

                this.dataGridViewProdukt.ContextMenuStrip = ProduktAlktionen;
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
            Int32 selectedRowCount =
               dataGridViewProdukt.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append(dataGridViewProdukt.SelectedRows[i].Index.ToString());
                    sb.Append(Environment.NewLine);
                }

                sb.Append("Total: " + selectedRowCount.ToString());
                MessageBox.Show(sb.ToString(), "Selected Rows");
            }
        }

        private void VerkaufButton_Click(object sender, EventArgs e)
        {

        }

        private void Mainwindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.c.closeConnection();
            Application.Exit();
        }

        private void dataGridViewProdukt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tmp = e.KeyChar;
            int zahl = Int32.Parse(tmp.ToString());

            Int32 selectedRowCount = dataGridViewProdukt.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount ==1)
            {
                this.produktVerwaltung.Add(new Produkt(dataGridViewProdukt.SelectedRows[0].Cells[0].Value.ToString(),
                    dataGridViewProdukt.SelectedRows[0].Cells[1].Value.ToString(),
                    dataGridViewProdukt.SelectedRows[0].Cells[2].Value.ToString(),
                    zahl));
                this.einkaufslisteZusammenfassen_darstellen();
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

            for (int i = 0; i < produktVerwaltung.Count;i++)
            {
                if (produktVerwaltung[i].Anzahl <= 0)
                {
                    this.produktVerwaltung.RemoveAt(i);
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
                }

            }
        }
    }
}
