namespace BauchladenProgramm
{
    partial class Mainwindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produkt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProduktAlktionen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sddsafToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Produktauswahlliste = new System.Windows.Forms.GroupBox();
            this.Einkaufsliste = new System.Windows.Forms.GroupBox();
            this.TeilnehmerAuswahl = new System.Windows.Forms.GroupBox();
            this.splitContainerVerkaufP = new System.Windows.Forms.SplitContainer();
            this.splitContainerVerkauf = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Verkauf = new System.Windows.Forms.TabPage();
            this.Buechertisch = new System.Windows.Forms.TabPage();
            this.Einzahlung = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ProduktAlktionen.SuspendLayout();
            this.Produktauswahlliste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVerkaufP)).BeginInit();
            this.splitContainerVerkaufP.Panel1.SuspendLayout();
            this.splitContainerVerkaufP.Panel2.SuspendLayout();
            this.splitContainerVerkaufP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVerkauf)).BeginInit();
            this.splitContainerVerkauf.Panel1.SuspendLayout();
            this.splitContainerVerkauf.Panel2.SuspendLayout();
            this.splitContainerVerkauf.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Verkauf.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Produkt,
            this.Preis});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(210, 413);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Produkt
            // 
            this.Produkt.HeaderText = "Produkt";
            this.Produkt.Name = "Produkt";
            this.Produkt.ReadOnly = true;
            this.Produkt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Preis
            // 
            this.Preis.HeaderText = "Preis";
            this.Preis.Name = "Preis";
            this.Preis.ReadOnly = true;
            this.Preis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProduktAlktionen
            // 
            this.ProduktAlktionen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sddsafToolStripMenuItem});
            this.ProduktAlktionen.Name = "ProduktAlktionen";
            this.ProduktAlktionen.Size = new System.Drawing.Size(220, 26);
            // 
            // sddsafToolStripMenuItem
            // 
            this.sddsafToolStripMenuItem.Name = "sddsafToolStripMenuItem";
            this.sddsafToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.sddsafToolStripMenuItem.Text = "Zu Einkaufsliste hinzufügen";
            // 
            // Produktauswahlliste
            // 
            this.Produktauswahlliste.AutoSize = true;
            this.Produktauswahlliste.Controls.Add(this.dataGridView1);
            this.Produktauswahlliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Produktauswahlliste.Location = new System.Drawing.Point(0, 0);
            this.Produktauswahlliste.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Produktauswahlliste.Name = "Produktauswahlliste";
            this.Produktauswahlliste.Size = new System.Drawing.Size(216, 432);
            this.Produktauswahlliste.TabIndex = 2;
            this.Produktauswahlliste.TabStop = false;
            this.Produktauswahlliste.Text = "Produktauswahlliste";
            // 
            // Einkaufsliste
            // 
            this.Einkaufsliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Einkaufsliste.Location = new System.Drawing.Point(0, 0);
            this.Einkaufsliste.Name = "Einkaufsliste";
            this.Einkaufsliste.Size = new System.Drawing.Size(168, 432);
            this.Einkaufsliste.TabIndex = 3;
            this.Einkaufsliste.TabStop = false;
            this.Einkaufsliste.Text = "Einkaufsliste";
            // 
            // TeilnehmerAuswahl
            // 
            this.TeilnehmerAuswahl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeilnehmerAuswahl.Location = new System.Drawing.Point(0, 0);
            this.TeilnehmerAuswahl.Name = "TeilnehmerAuswahl";
            this.TeilnehmerAuswahl.Size = new System.Drawing.Size(173, 432);
            this.TeilnehmerAuswahl.TabIndex = 4;
            this.TeilnehmerAuswahl.TabStop = false;
            this.TeilnehmerAuswahl.Text = "Teilnehmerauswahl";
            // 
            // splitContainerVerkaufP
            // 
            this.splitContainerVerkaufP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVerkaufP.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVerkaufP.Name = "splitContainerVerkaufP";
            // 
            // splitContainerVerkaufP.Panel1
            // 
            this.splitContainerVerkaufP.Panel1.Controls.Add(this.Einkaufsliste);
            // 
            // splitContainerVerkaufP.Panel2
            // 
            this.splitContainerVerkaufP.Panel2.Controls.Add(this.Produktauswahlliste);
            this.splitContainerVerkaufP.Size = new System.Drawing.Size(388, 432);
            this.splitContainerVerkaufP.SplitterDistance = 168;
            this.splitContainerVerkaufP.TabIndex = 5;
            // 
            // splitContainerVerkauf
            // 
            this.splitContainerVerkauf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVerkauf.Location = new System.Drawing.Point(3, 3);
            this.splitContainerVerkauf.Name = "splitContainerVerkauf";
            // 
            // splitContainerVerkauf.Panel1
            // 
            this.splitContainerVerkauf.Panel1.Controls.Add(this.TeilnehmerAuswahl);
            // 
            // splitContainerVerkauf.Panel2
            // 
            this.splitContainerVerkauf.Panel2.Controls.Add(this.splitContainerVerkaufP);
            this.splitContainerVerkauf.Size = new System.Drawing.Size(565, 432);
            this.splitContainerVerkauf.SplitterDistance = 173;
            this.splitContainerVerkauf.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Verkauf);
            this.tabControl1.Controls.Add(this.Buechertisch);
            this.tabControl1.Controls.Add(this.Einzahlung);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 464);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // Verkauf
            // 
            this.Verkauf.Controls.Add(this.splitContainerVerkauf);
            this.Verkauf.Location = new System.Drawing.Point(4, 22);
            this.Verkauf.Name = "Verkauf";
            this.Verkauf.Padding = new System.Windows.Forms.Padding(3);
            this.Verkauf.Size = new System.Drawing.Size(571, 438);
            this.Verkauf.TabIndex = 0;
            this.Verkauf.Text = "Verkauf";
            this.Verkauf.UseVisualStyleBackColor = true;
            // 
            // Buechertisch
            // 
            this.Buechertisch.Location = new System.Drawing.Point(4, 22);
            this.Buechertisch.Name = "Buechertisch";
            this.Buechertisch.Padding = new System.Windows.Forms.Padding(3);
            this.Buechertisch.Size = new System.Drawing.Size(571, 438);
            this.Buechertisch.TabIndex = 1;
            this.Buechertisch.Text = "Büchertisch";
            this.Buechertisch.UseVisualStyleBackColor = true;
            // 
            // Einzahlung
            // 
            this.Einzahlung.Location = new System.Drawing.Point(4, 22);
            this.Einzahlung.Name = "Einzahlung";
            this.Einzahlung.Padding = new System.Windows.Forms.Padding(3);
            this.Einzahlung.Size = new System.Drawing.Size(571, 438);
            this.Einzahlung.TabIndex = 2;
            this.Einzahlung.Text = "Einzahlung";
            this.Einzahlung.UseVisualStyleBackColor = true;
            // 
            // Mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 464);
            this.Controls.Add(this.tabControl1);
            this.Name = "Mainwindow";
            this.ShowIcon = false;
            this.Text = "Bauchladen EJW BadUrach";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mainwindow_FormClosed);
            this.Load += new System.EventHandler(this.Mainwindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ProduktAlktionen.ResumeLayout(false);
            this.Produktauswahlliste.ResumeLayout(false);
            this.splitContainerVerkaufP.Panel1.ResumeLayout(false);
            this.splitContainerVerkaufP.Panel2.ResumeLayout(false);
            this.splitContainerVerkaufP.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVerkaufP)).EndInit();
            this.splitContainerVerkaufP.ResumeLayout(false);
            this.splitContainerVerkauf.Panel1.ResumeLayout(false);
            this.splitContainerVerkauf.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVerkauf)).EndInit();
            this.splitContainerVerkauf.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Verkauf.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produkt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preis;
        private System.Windows.Forms.ContextMenuStrip ProduktAlktionen;
        private System.Windows.Forms.ToolStripMenuItem sddsafToolStripMenuItem;
        private System.Windows.Forms.GroupBox Produktauswahlliste;
        private System.Windows.Forms.GroupBox TeilnehmerAuswahl;
        private System.Windows.Forms.GroupBox Einkaufsliste;
        private System.Windows.Forms.SplitContainer splitContainerVerkaufP;
        private System.Windows.Forms.SplitContainer splitContainerVerkauf;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Verkauf;
        private System.Windows.Forms.TabPage Buechertisch;
        private System.Windows.Forms.TabPage Einzahlung;

    }
}

