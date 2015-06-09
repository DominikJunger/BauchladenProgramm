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
        //private Connector.Connector c;
        private string ip;

        public Mainwindow(string ip)
        {
            InitializeComponent();
            this.ip = ip;
        }

        private void Mainwindow_Load(object sender, EventArgs e)
        {
            try
            {
                //c = new Connector.Connector(ip, 3000, this);
                //c.connectToServer();
                //c.getProductList();

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
                String [] pr= new String[3];
                pr[0]=p.Id.ToString();
                pr[1]=p.Name;
                pr[2]=p.Preis.ToString();
                this.dataGridViewProdukt.Invoke((MethodInvoker)delegate()
                {
                    this.dataGridViewProdukt.Rows.Add(pr);
                });
            }
        }

        public void leere_dataGridView1()
        {
            this.dataGridViewProdukt.Invoke((MethodInvoker)delegate()
            {
                this.dataGridViewProdukt.Rows.Clear();
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
            //this.c.closeConnection();
            Application.Exit();
        }
    }
}
