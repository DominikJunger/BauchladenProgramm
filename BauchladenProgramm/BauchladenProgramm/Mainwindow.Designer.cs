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
            this.dataGridViewProdukt = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produkt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProduktAlktionen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Produktauswahlliste = new System.Windows.Forms.GroupBox();
            this.Einkaufsliste = new System.Windows.Forms.GroupBox();
            this.dataGridViewEinkauf = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeilnehmerAuswahl = new System.Windows.Forms.GroupBox();
            this.splitContainerTeilnehmer = new System.Windows.Forms.SplitContainer();
            this.TeilnehmerSuche = new System.Windows.Forms.TextBox();
            this.dataGridViewTeilnehmer = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerVerkaufP = new System.Windows.Forms.SplitContainer();
            this.splitContainerVerkauf = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Verkauf = new System.Windows.Forms.TabPage();
            this.Buechertisch = new System.Windows.Forms.TabPage();
            this.Einzahlung = new System.Windows.Forms.TabPage();
            this.splitContainerEinkaufsliste = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdukt)).BeginInit();
            this.ProduktAlktionen.SuspendLayout();
            this.Produktauswahlliste.SuspendLayout();
            this.Einkaufsliste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEinkauf)).BeginInit();
            this.TeilnehmerAuswahl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTeilnehmer)).BeginInit();
            this.splitContainerTeilnehmer.Panel1.SuspendLayout();
            this.splitContainerTeilnehmer.Panel2.SuspendLayout();
            this.splitContainerTeilnehmer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeilnehmer)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEinkaufsliste)).BeginInit();
            this.splitContainerEinkaufsliste.Panel1.SuspendLayout();
            this.splitContainerEinkaufsliste.Panel2.SuspendLayout();
            this.splitContainerEinkaufsliste.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProdukt
            // 
            this.dataGridViewProdukt.AllowUserToAddRows = false;
            this.dataGridViewProdukt.AllowUserToDeleteRows = false;
            this.dataGridViewProdukt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProdukt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewProdukt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProdukt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Produkt,
            this.Preis});
            this.dataGridViewProdukt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProdukt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewProdukt.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewProdukt.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.dataGridViewProdukt.MultiSelect = false;
            this.dataGridViewProdukt.Name = "dataGridViewProdukt";
            this.dataGridViewProdukt.ReadOnly = true;
            this.dataGridViewProdukt.RowHeadersVisible = false;
            this.dataGridViewProdukt.RowTemplate.ReadOnly = true;
            this.dataGridViewProdukt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProdukt.Size = new System.Drawing.Size(199, 406);
            this.dataGridViewProdukt.TabIndex = 0;
            this.dataGridViewProdukt.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
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
            this.ToolStripMenuItem});
            this.ProduktAlktionen.Name = "ProduktAlktionen";
            this.ProduktAlktionen.Size = new System.Drawing.Size(220, 26);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.ToolStripMenuItem.Text = "Zu Einkaufsliste hinzufügen";
            // 
            // Produktauswahlliste
            // 
            this.Produktauswahlliste.AutoSize = true;
            this.Produktauswahlliste.Controls.Add(this.dataGridViewProdukt);
            this.Produktauswahlliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Produktauswahlliste.Location = new System.Drawing.Point(0, 0);
            this.Produktauswahlliste.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Produktauswahlliste.Name = "Produktauswahlliste";
            this.Produktauswahlliste.Size = new System.Drawing.Size(205, 425);
            this.Produktauswahlliste.TabIndex = 2;
            this.Produktauswahlliste.TabStop = false;
            this.Produktauswahlliste.Text = "Produktauswahlliste";
            // 
            // Einkaufsliste
            // 
            this.Einkaufsliste.Controls.Add(this.splitContainerEinkaufsliste);
            this.Einkaufsliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Einkaufsliste.Location = new System.Drawing.Point(0, 0);
            this.Einkaufsliste.Name = "Einkaufsliste";
            this.Einkaufsliste.Size = new System.Drawing.Size(222, 425);
            this.Einkaufsliste.TabIndex = 3;
            this.Einkaufsliste.TabStop = false;
            this.Einkaufsliste.Text = "Einkaufsliste";
            // 
            // dataGridViewEinkauf
            // 
            this.dataGridViewEinkauf.AllowUserToAddRows = false;
            this.dataGridViewEinkauf.AllowUserToDeleteRows = false;
            this.dataGridViewEinkauf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEinkauf.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewEinkauf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEinkauf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewEinkauf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEinkauf.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewEinkauf.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEinkauf.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.dataGridViewEinkauf.MultiSelect = false;
            this.dataGridViewEinkauf.Name = "dataGridViewEinkauf";
            this.dataGridViewEinkauf.ReadOnly = true;
            this.dataGridViewEinkauf.RowHeadersVisible = false;
            this.dataGridViewEinkauf.RowTemplate.ReadOnly = true;
            this.dataGridViewEinkauf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEinkauf.Size = new System.Drawing.Size(216, 377);
            this.dataGridViewEinkauf.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Produkt";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Preis";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TeilnehmerAuswahl
            // 
            this.TeilnehmerAuswahl.Controls.Add(this.splitContainerTeilnehmer);
            this.TeilnehmerAuswahl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeilnehmerAuswahl.Location = new System.Drawing.Point(0, 0);
            this.TeilnehmerAuswahl.Name = "TeilnehmerAuswahl";
            this.TeilnehmerAuswahl.Size = new System.Drawing.Size(200, 425);
            this.TeilnehmerAuswahl.TabIndex = 4;
            this.TeilnehmerAuswahl.TabStop = false;
            this.TeilnehmerAuswahl.Text = "Teilnehmerauswahl";
            // 
            // splitContainerTeilnehmer
            // 
            this.splitContainerTeilnehmer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTeilnehmer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerTeilnehmer.IsSplitterFixed = true;
            this.splitContainerTeilnehmer.Location = new System.Drawing.Point(3, 16);
            this.splitContainerTeilnehmer.Name = "splitContainerTeilnehmer";
            this.splitContainerTeilnehmer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTeilnehmer.Panel1
            // 
            this.splitContainerTeilnehmer.Panel1.Controls.Add(this.TeilnehmerSuche);
            this.splitContainerTeilnehmer.Panel1MinSize = 5;
            // 
            // splitContainerTeilnehmer.Panel2
            // 
            this.splitContainerTeilnehmer.Panel2.Controls.Add(this.dataGridViewTeilnehmer);
            this.splitContainerTeilnehmer.Size = new System.Drawing.Size(194, 406);
            this.splitContainerTeilnehmer.SplitterDistance = 20;
            this.splitContainerTeilnehmer.TabIndex = 0;
            // 
            // TeilnehmerSuche
            // 
            this.TeilnehmerSuche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeilnehmerSuche.Location = new System.Drawing.Point(0, 0);
            this.TeilnehmerSuche.Name = "TeilnehmerSuche";
            this.TeilnehmerSuche.Size = new System.Drawing.Size(194, 20);
            this.TeilnehmerSuche.TabIndex = 0;
            // 
            // dataGridViewTeilnehmer
            // 
            this.dataGridViewTeilnehmer.AllowUserToAddRows = false;
            this.dataGridViewTeilnehmer.AllowUserToDeleteRows = false;
            this.dataGridViewTeilnehmer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTeilnehmer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewTeilnehmer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeilnehmer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridViewTeilnehmer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTeilnehmer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewTeilnehmer.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTeilnehmer.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.dataGridViewTeilnehmer.MultiSelect = false;
            this.dataGridViewTeilnehmer.Name = "dataGridViewTeilnehmer";
            this.dataGridViewTeilnehmer.ReadOnly = true;
            this.dataGridViewTeilnehmer.RowHeadersVisible = false;
            this.dataGridViewTeilnehmer.RowTemplate.ReadOnly = true;
            this.dataGridViewTeilnehmer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTeilnehmer.Size = new System.Drawing.Size(194, 382);
            this.dataGridViewTeilnehmer.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Id";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 101.5228F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Vorname";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 95;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 98.47716F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Nachname";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 95;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.splitContainerVerkaufP.Panel1MinSize = 200;
            // 
            // splitContainerVerkaufP.Panel2
            // 
            this.splitContainerVerkaufP.Panel2.Controls.Add(this.Produktauswahlliste);
            this.splitContainerVerkaufP.Panel2MinSize = 200;
            this.splitContainerVerkaufP.Size = new System.Drawing.Size(431, 425);
            this.splitContainerVerkaufP.SplitterDistance = 222;
            this.splitContainerVerkaufP.TabIndex = 5;
            // 
            // splitContainerVerkauf
            // 
            this.splitContainerVerkauf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVerkauf.Location = new System.Drawing.Point(3, 10);
            this.splitContainerVerkauf.Name = "splitContainerVerkauf";
            // 
            // splitContainerVerkauf.Panel1
            // 
            this.splitContainerVerkauf.Panel1.Controls.Add(this.TeilnehmerAuswahl);
            this.splitContainerVerkauf.Panel1MinSize = 200;
            // 
            // splitContainerVerkauf.Panel2
            // 
            this.splitContainerVerkauf.Panel2.Controls.Add(this.splitContainerVerkaufP);
            this.splitContainerVerkauf.Panel2MinSize = 400;
            this.splitContainerVerkauf.Size = new System.Drawing.Size(635, 425);
            this.splitContainerVerkauf.SplitterDistance = 200;
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
            this.tabControl1.Size = new System.Drawing.Size(649, 464);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // Verkauf
            // 
            this.Verkauf.Controls.Add(this.splitContainerVerkauf);
            this.Verkauf.Location = new System.Drawing.Point(4, 22);
            this.Verkauf.Name = "Verkauf";
            this.Verkauf.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Verkauf.Size = new System.Drawing.Size(641, 438);
            this.Verkauf.TabIndex = 0;
            this.Verkauf.Text = "Verkauf";
            this.Verkauf.UseVisualStyleBackColor = true;
            // 
            // Buechertisch
            // 
            this.Buechertisch.Location = new System.Drawing.Point(4, 22);
            this.Buechertisch.Name = "Buechertisch";
            this.Buechertisch.Padding = new System.Windows.Forms.Padding(3);
            this.Buechertisch.Size = new System.Drawing.Size(641, 438);
            this.Buechertisch.TabIndex = 1;
            this.Buechertisch.Text = "Büchertisch";
            this.Buechertisch.UseVisualStyleBackColor = true;
            // 
            // Einzahlung
            // 
            this.Einzahlung.Location = new System.Drawing.Point(4, 22);
            this.Einzahlung.Name = "Einzahlung";
            this.Einzahlung.Padding = new System.Windows.Forms.Padding(3);
            this.Einzahlung.Size = new System.Drawing.Size(641, 438);
            this.Einzahlung.TabIndex = 2;
            this.Einzahlung.Text = "Einzahlung";
            this.Einzahlung.UseVisualStyleBackColor = true;
            // 
            // splitContainerEinkaufsliste
            // 
            this.splitContainerEinkaufsliste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEinkaufsliste.Location = new System.Drawing.Point(3, 16);
            this.splitContainerEinkaufsliste.Name = "splitContainerEinkaufsliste";
            this.splitContainerEinkaufsliste.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEinkaufsliste.Panel1
            // 
            this.splitContainerEinkaufsliste.Panel1.Controls.Add(this.dataGridViewEinkauf);
            // 
            // splitContainerEinkaufsliste.Panel2
            // 
            this.splitContainerEinkaufsliste.Panel2.Controls.Add(this.button1);
            this.splitContainerEinkaufsliste.Panel2MinSize = 30;
            this.splitContainerEinkaufsliste.Size = new System.Drawing.Size(216, 406);
            this.splitContainerEinkaufsliste.SplitterDistance = 377;
            this.splitContainerEinkaufsliste.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 464);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "Mainwindow";
            this.ShowIcon = false;
            this.Text = "Bauchladen EJW BadUrach";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mainwindow_FormClosed);
            this.Load += new System.EventHandler(this.Mainwindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdukt)).EndInit();
            this.ProduktAlktionen.ResumeLayout(false);
            this.Produktauswahlliste.ResumeLayout(false);
            this.Einkaufsliste.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEinkauf)).EndInit();
            this.TeilnehmerAuswahl.ResumeLayout(false);
            this.splitContainerTeilnehmer.Panel1.ResumeLayout(false);
            this.splitContainerTeilnehmer.Panel1.PerformLayout();
            this.splitContainerTeilnehmer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTeilnehmer)).EndInit();
            this.splitContainerTeilnehmer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeilnehmer)).EndInit();
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
            this.splitContainerEinkaufsliste.Panel1.ResumeLayout(false);
            this.splitContainerEinkaufsliste.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerEinkaufsliste)).EndInit();
            this.splitContainerEinkaufsliste.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProdukt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produkt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preis;
        private System.Windows.Forms.ContextMenuStrip ProduktAlktionen;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.GroupBox Produktauswahlliste;
        private System.Windows.Forms.GroupBox TeilnehmerAuswahl;
        private System.Windows.Forms.GroupBox Einkaufsliste;
        private System.Windows.Forms.SplitContainer splitContainerVerkaufP;
        private System.Windows.Forms.SplitContainer splitContainerVerkauf;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Verkauf;
        private System.Windows.Forms.TabPage Buechertisch;
        private System.Windows.Forms.TabPage Einzahlung;
        private System.Windows.Forms.DataGridView dataGridViewEinkauf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.SplitContainer splitContainerTeilnehmer;
        private System.Windows.Forms.DataGridView dataGridViewTeilnehmer;
        private System.Windows.Forms.TextBox TeilnehmerSuche;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.SplitContainer splitContainerEinkaufsliste;
        private System.Windows.Forms.Button button1;

    }
}

