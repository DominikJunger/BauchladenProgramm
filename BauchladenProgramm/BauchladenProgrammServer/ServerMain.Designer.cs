namespace BauchladenProgrammServer
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TnLöschen = new System.Windows.Forms.Button();
            this.TnHinzufügen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.TN_Name = new System.Windows.Forms.Label();
            this.Kontostand = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTeilnehmer = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewProdukt = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produkt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sqlState = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.log = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TnInaktiv = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeilnehmer)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdukt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlState)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 407);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dataGridViewTeilnehmer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Teilnehmer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TnInaktiv);
            this.panel2.Controls.Add(this.TnLöschen);
            this.panel2.Controls.Add(this.TnHinzufügen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(586, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 375);
            this.panel2.TabIndex = 6;
            // 
            // TnLöschen
            // 
            this.TnLöschen.Location = new System.Drawing.Point(9, 41);
            this.TnLöschen.Name = "TnLöschen";
            this.TnLöschen.Size = new System.Drawing.Size(188, 23);
            this.TnLöschen.TabIndex = 6;
            this.TnLöschen.Text = "Ausgewählten Teilnehmer löschen";
            this.TnLöschen.UseVisualStyleBackColor = true;
            this.TnLöschen.Click += new System.EventHandler(this.TnLöschen_Click);
            this.TnLöschen.Leave += new System.EventHandler(this.TnHinzufügen_Leave);
            // 
            // TnHinzufügen
            // 
            this.TnHinzufügen.Location = new System.Drawing.Point(9, 10);
            this.TnHinzufügen.Name = "TnHinzufügen";
            this.TnHinzufügen.Size = new System.Drawing.Size(188, 23);
            this.TnHinzufügen.TabIndex = 5;
            this.TnHinzufügen.Text = "Neuen Teilnehmer hinzugügen";
            this.TnHinzufügen.UseVisualStyleBackColor = true;
            this.TnHinzufügen.Click += new System.EventHandler(this.TnHinzufügen_Click);
            this.TnHinzufügen.Leave += new System.EventHandler(this.TnHinzufügen_Leave);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.GreenYellow;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.TN_Name);
            this.panel1.Controls.Add(this.Kontostand);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(364, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 375);
            this.panel1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "€";
            // 
            // TN_Name
            // 
            this.TN_Name.AutoSize = true;
            this.TN_Name.Location = new System.Drawing.Point(38, 15);
            this.TN_Name.Name = "TN_Name";
            this.TN_Name.Size = new System.Drawing.Size(0, 13);
            this.TN_Name.TabIndex = 4;
            // 
            // Kontostand
            // 
            this.Kontostand.AutoSize = true;
            this.Kontostand.Location = new System.Drawing.Point(115, 40);
            this.Kontostand.Name = "Kontostand";
            this.Kontostand.Size = new System.Drawing.Size(0, 13);
            this.Kontostand.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kontostand des TN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TN:";
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
            this.dataGridViewTeilnehmer.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewTeilnehmer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewTeilnehmer.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTeilnehmer.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.dataGridViewTeilnehmer.MultiSelect = false;
            this.dataGridViewTeilnehmer.Name = "dataGridViewTeilnehmer";
            this.dataGridViewTeilnehmer.ReadOnly = true;
            this.dataGridViewTeilnehmer.RowHeadersVisible = false;
            this.dataGridViewTeilnehmer.RowTemplate.ReadOnly = true;
            this.dataGridViewTeilnehmer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTeilnehmer.Size = new System.Drawing.Size(361, 375);
            this.dataGridViewTeilnehmer.TabIndex = 3;
            this.dataGridViewTeilnehmer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTeilnehmer_CellClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 63.00841F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Id";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 98.41289F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Vorname";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 138.5786F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Nachname";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewProdukt);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Produkte";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.dataGridViewProdukt.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewProdukt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewProdukt.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewProdukt.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.dataGridViewProdukt.MultiSelect = false;
            this.dataGridViewProdukt.Name = "dataGridViewProdukt";
            this.dataGridViewProdukt.ReadOnly = true;
            this.dataGridViewProdukt.RowHeadersVisible = false;
            this.dataGridViewProdukt.RowTemplate.ReadOnly = true;
            this.dataGridViewProdukt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProdukt.Size = new System.Drawing.Size(275, 375);
            this.dataGridViewProdukt.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.FillWeight = 62.88269F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Produkt
            // 
            this.Produkt.FillWeight = 98.5386F;
            this.Produkt.HeaderText = "Produkt";
            this.Produkt.Name = "Produkt";
            this.Produkt.ReadOnly = true;
            // 
            // Preis
            // 
            this.Preis.FillWeight = 138.5786F;
            this.Preis.HeaderText = "Preis";
            this.Preis.Name = "Preis";
            this.Preis.ReadOnly = true;
            // 
            // sqlState
            // 
            this.sqlState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlState.BackColor = System.Drawing.Color.Red;
            this.sqlState.Location = new System.Drawing.Point(753, 19);
            this.sqlState.Name = "sqlState";
            this.sqlState.Size = new System.Drawing.Size(44, 28);
            this.sqlState.TabIndex = 1;
            this.sqlState.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(596, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "SQl Server Verbindungsstatus:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // log
            // 
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(7, 12);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(583, 43);
            this.log.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.sqlState);
            this.panel3.Controls.Add(this.log);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 397);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(799, 64);
            this.panel3.TabIndex = 7;
            // 
            // TnInaktiv
            // 
            this.TnInaktiv.Location = new System.Drawing.Point(9, 71);
            this.TnInaktiv.Name = "TnInaktiv";
            this.TnInaktiv.Size = new System.Drawing.Size(188, 23);
            this.TnInaktiv.TabIndex = 7;
            this.TnInaktiv.Text = "Setzt den auswewählent TN inaktiv";
            this.TnInaktiv.UseVisualStyleBackColor = true;
            this.TnInaktiv.Click += new System.EventHandler(this.TnInaktiv_Click);
            this.TnInaktiv.Leave += new System.EventHandler(this.TnHinzufügen_Leave);
            // 
            // Mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 461);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(815, 450);
            this.Name = "Mainwindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bauchladen Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainwindow_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeilnehmer)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdukt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlState)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox sqlState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewTeilnehmer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dataGridViewProdukt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produkt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preis;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TN_Name;
        private System.Windows.Forms.Label Kontostand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button TnLöschen;
        private System.Windows.Forms.Button TnHinzufügen;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button TnInaktiv;
    }
}

