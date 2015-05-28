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

namespace BauchladenProgramm
{
    public partial class Mainwindow : Form
    {
        private Connector.Connector c;
        private string ip;
        private List<Produkt> pr;
        private List<Teilnehmer> tn;

        public Mainwindow(string ip)
        {
            InitializeComponent();
            this.ip = ip;
            this.pr = new List<Produkt>();
            this.tn = new List<Teilnehmer>();
        }

        private void Mainwindow_Load(object sender, EventArgs e)
        {
            c = new Connector.Connector(ip, 3000,this);
            c.connectToServer();
            c.getProductList();
        }

        public void addPr(Produkt p)
        {
            if (p != null)
            {
                String [] pr= new String[3];
                pr[0]=p.Id.ToString();
                pr[1]=p.Name;
                pr[2]=p.Preis.ToString();
                this.dataGridView1.Invoke((MethodInvoker)delegate()
                {
                    this.dataGridView1.Rows.Add(pr);
                });
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount =
               dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append(dataGridView1.SelectedRows[i].Index.ToString());
                    sb.Append(Environment.NewLine);
                }

                sb.Append("Total: " + selectedRowCount.ToString());
                MessageBox.Show(sb.ToString(), "Selected Rows");
            }
        }
    }
}
