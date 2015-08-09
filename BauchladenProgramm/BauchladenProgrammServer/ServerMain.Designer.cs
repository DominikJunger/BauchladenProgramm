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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CsvEinlesen = new System.Windows.Forms.Button();
            this.stückelung = new System.Windows.Forms.Button();
            this.alleAuszahlen = new System.Windows.Forms.Button();
            this.tagesabschluss = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.sqlState = new System.Windows.Forms.PictureBox();
            this.log = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nachname = new System.Windows.Forms.TextBox();
            this.vorname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.einzahlung = new System.Windows.Forms.TextBox();
            this.TnEinzahlen = new System.Windows.Forms.Button();
            this.TnAuszahlen = new System.Windows.Forms.Button();
            this.TnInaktiv = new System.Windows.Forms.Button();
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
            this.inaktiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBüchertisch = new System.Windows.Forms.CheckBox();
            this.PPreis = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PInaktiv = new System.Windows.Forms.Button();
            this.PLöschen = new System.Windows.Forms.Button();
            this.PHinzugügen = new System.Windows.Forms.Button();
            this.dataGridViewProdukt = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produkt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verfügbarkeit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BücherTisch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statistik = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqlState)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeilnehmer)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdukt)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 461);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.statistik);
            this.tabPage3.Controls.Add(this.CsvEinlesen);
            this.tabPage3.Controls.Add(this.stückelung);
            this.tabPage3.Controls.Add(this.alleAuszahlen);
            this.tabPage3.Controls.Add(this.tagesabschluss);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.sqlState);
            this.tabPage3.Controls.Add(this.log);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(791, 435);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Allgemein";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // CsvEinlesen
            // 
            this.CsvEinlesen.Location = new System.Drawing.Point(408, 6);
            this.CsvEinlesen.Name = "CsvEinlesen";
            this.CsvEinlesen.Size = new System.Drawing.Size(128, 88);
            this.CsvEinlesen.TabIndex = 7;
            this.CsvEinlesen.Text = "Teilnehmer aus einer CSV Datei einlesen";
            this.CsvEinlesen.UseVisualStyleBackColor = true;
            this.CsvEinlesen.Click += new System.EventHandler(this.CsvEinlesen_Click);
            // 
            // stückelung
            // 
            this.stückelung.Location = new System.Drawing.Point(274, 6);
            this.stückelung.Name = "stückelung";
            this.stückelung.Size = new System.Drawing.Size(128, 88);
            this.stückelung.TabIndex = 6;
            this.stückelung.Text = "Aktuelle Stückelung für die gesamte Auszahlung berechnen";
            this.stückelung.UseVisualStyleBackColor = true;
            this.stückelung.Click += new System.EventHandler(this.stückelung_Click);
            // 
            // alleAuszahlen
            // 
            this.alleAuszahlen.Location = new System.Drawing.Point(140, 6);
            this.alleAuszahlen.Name = "alleAuszahlen";
            this.alleAuszahlen.Size = new System.Drawing.Size(128, 88);
            this.alleAuszahlen.TabIndex = 5;
            this.alleAuszahlen.Text = "Alle Teilnehmer auszahlen und löschen";
            this.alleAuszahlen.UseVisualStyleBackColor = true;
            this.alleAuszahlen.Click += new System.EventHandler(this.alleAuszahlen_Click);
            // 
            // tagesabschluss
            // 
            this.tagesabschluss.Location = new System.Drawing.Point(6, 6);
            this.tagesabschluss.Name = "tagesabschluss";
            this.tagesabschluss.Size = new System.Drawing.Size(128, 88);
            this.tagesabschluss.TabIndex = 4;
            this.tagesabschluss.Text = "Tagesabschluss PDF erstellen";
            this.tagesabschluss.UseVisualStyleBackColor = true;
            this.tagesabschluss.Click += new System.EventHandler(this.tagesabschluss_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(612, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "SQl Server Verbindungsstatus:";
            // 
            // sqlState
            // 
            this.sqlState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlState.BackColor = System.Drawing.Color.Red;
            this.sqlState.Location = new System.Drawing.Point(665, 161);
            this.sqlState.Name = "sqlState";
            this.sqlState.Size = new System.Drawing.Size(44, 28);
            this.sqlState.TabIndex = 1;
            this.sqlState.TabStop = false;
            // 
            // log
            // 
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(3, 100);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(583, 329);
            this.log.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dataGridViewTeilnehmer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Teilnehmer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nachname);
            this.panel2.Controls.Add(this.vorname);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.einzahlung);
            this.panel2.Controls.Add(this.TnEinzahlen);
            this.panel2.Controls.Add(this.TnAuszahlen);
            this.panel2.Controls.Add(this.TnInaktiv);
            this.panel2.Controls.Add(this.TnHinzufügen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(586, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 429);
            this.panel2.TabIndex = 6;
            // 
            // nachname
            // 
            this.nachname.Location = new System.Drawing.Point(9, 57);
            this.nachname.Name = "nachname";
            this.nachname.Size = new System.Drawing.Size(188, 20);
            this.nachname.TabIndex = 16;
            this.nachname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vorname_KeyPress);
            // 
            // vorname
            // 
            this.vorname.Location = new System.Drawing.Point(9, 16);
            this.vorname.Name = "vorname";
            this.vorname.Size = new System.Drawing.Size(188, 20);
            this.vorname.TabIndex = 15;
            this.vorname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vorname_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Nachname:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Vorname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "€";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Betrag zum Einzahlen:";
            // 
            // einzahlung
            // 
            this.einzahlung.Location = new System.Drawing.Point(9, 206);
            this.einzahlung.Name = "einzahlung";
            this.einzahlung.Size = new System.Drawing.Size(129, 20);
            this.einzahlung.TabIndex = 10;
            this.einzahlung.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.einzahlung_KeyPress);
            // 
            // TnEinzahlen
            // 
            this.TnEinzahlen.Location = new System.Drawing.Point(9, 232);
            this.TnEinzahlen.Name = "TnEinzahlen";
            this.TnEinzahlen.Size = new System.Drawing.Size(188, 23);
            this.TnEinzahlen.TabIndex = 9;
            this.TnEinzahlen.Text = "Ausgewählter TN einzahlen";
            this.TnEinzahlen.UseVisualStyleBackColor = true;
            this.TnEinzahlen.Click += new System.EventHandler(this.TnEinzahlen_Click);
            // 
            // TnAuszahlen
            // 
            this.TnAuszahlen.Location = new System.Drawing.Point(9, 141);
            this.TnAuszahlen.Name = "TnAuszahlen";
            this.TnAuszahlen.Size = new System.Drawing.Size(188, 23);
            this.TnAuszahlen.TabIndex = 8;
            this.TnAuszahlen.Text = "Ausgewählter TN auszahlen";
            this.TnAuszahlen.UseVisualStyleBackColor = true;
            this.TnAuszahlen.Click += new System.EventHandler(this.TnAuszahlen_Click);
            // 
            // TnInaktiv
            // 
            this.TnInaktiv.BackColor = System.Drawing.Color.Red;
            this.TnInaktiv.Location = new System.Drawing.Point(9, 285);
            this.TnInaktiv.Name = "TnInaktiv";
            this.TnInaktiv.Size = new System.Drawing.Size(188, 43);
            this.TnInaktiv.TabIndex = 7;
            this.TnInaktiv.Text = "Ändern der Inaktivität des ausgewählten TN";
            this.TnInaktiv.UseVisualStyleBackColor = false;
            this.TnInaktiv.Click += new System.EventHandler(this.TnInaktiv_Click);
            // 
            // TnHinzufügen
            // 
            this.TnHinzufügen.Location = new System.Drawing.Point(9, 83);
            this.TnHinzufügen.Name = "TnHinzufügen";
            this.TnHinzufügen.Size = new System.Drawing.Size(188, 23);
            this.TnHinzufügen.TabIndex = 5;
            this.TnHinzufügen.Text = "Neuen Teilnehmer hinzugügen";
            this.TnHinzufügen.UseVisualStyleBackColor = true;
            this.TnHinzufügen.Click += new System.EventHandler(this.TnHinzufügen_Click);
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
            this.panel1.Size = new System.Drawing.Size(222, 429);
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
            this.dataGridViewTextBoxColumn6,
            this.inaktiv});
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
            this.dataGridViewTeilnehmer.Size = new System.Drawing.Size(361, 429);
            this.dataGridViewTeilnehmer.TabIndex = 3;
            this.dataGridViewTeilnehmer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTeilnehmer_CellClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 48.54543F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Id";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 112.2181F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Vorname";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 158.0181F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Nachname";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // inaktiv
            // 
            this.inaktiv.FillWeight = 81.21825F;
            this.inaktiv.HeaderText = "Inaktiv";
            this.inaktiv.MinimumWidth = 30;
            this.inaktiv.Name = "inaktiv";
            this.inaktiv.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.dataGridViewProdukt);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Produkte";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBüchertisch);
            this.panel4.Controls.Add(this.PPreis);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.PName);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.PInaktiv);
            this.panel4.Controls.Add(this.PLöschen);
            this.panel4.Controls.Add(this.PHinzugügen);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(500, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(288, 429);
            this.panel4.TabIndex = 2;
            // 
            // checkBüchertisch
            // 
            this.checkBüchertisch.AutoSize = true;
            this.checkBüchertisch.Location = new System.Drawing.Point(9, 104);
            this.checkBüchertisch.Name = "checkBüchertisch";
            this.checkBüchertisch.Size = new System.Drawing.Size(82, 17);
            this.checkBüchertisch.TabIndex = 15;
            this.checkBüchertisch.Text = "Büchertisch";
            this.checkBüchertisch.UseVisualStyleBackColor = true;
            // 
            // PPreis
            // 
            this.PPreis.Location = new System.Drawing.Point(9, 77);
            this.PPreis.Name = "PPreis";
            this.PPreis.Size = new System.Drawing.Size(273, 20);
            this.PPreis.TabIndex = 14;
            this.PPreis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.einzahlung_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Preis";
            // 
            // PName
            // 
            this.PName.Location = new System.Drawing.Point(9, 33);
            this.PName.Name = "PName";
            this.PName.Size = new System.Drawing.Size(273, 20);
            this.PName.TabIndex = 12;
            this.PName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vorname_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Produktname:";
            // 
            // PInaktiv
            // 
            this.PInaktiv.Location = new System.Drawing.Point(9, 197);
            this.PInaktiv.Name = "PInaktiv";
            this.PInaktiv.Size = new System.Drawing.Size(273, 23);
            this.PInaktiv.TabIndex = 10;
            this.PInaktiv.Text = "Ändern der Verfügbarkeit des ausgewählten Produkts";
            this.PInaktiv.UseVisualStyleBackColor = true;
            this.PInaktiv.Click += new System.EventHandler(this.PInaktiv_Click);
            // 
            // PLöschen
            // 
            this.PLöschen.Location = new System.Drawing.Point(9, 167);
            this.PLöschen.Name = "PLöschen";
            this.PLöschen.Size = new System.Drawing.Size(273, 23);
            this.PLöschen.TabIndex = 9;
            this.PLöschen.Text = "Ausgewähltes Produkt löschen";
            this.PLöschen.UseVisualStyleBackColor = true;
            this.PLöschen.Click += new System.EventHandler(this.PLöschen_Click);
            // 
            // PHinzugügen
            // 
            this.PHinzugügen.Location = new System.Drawing.Point(9, 136);
            this.PHinzugügen.Name = "PHinzugügen";
            this.PHinzugügen.Size = new System.Drawing.Size(273, 23);
            this.PHinzugügen.TabIndex = 8;
            this.PHinzugügen.Text = "Neues Produkt hinzugügen";
            this.PHinzugügen.UseVisualStyleBackColor = true;
            this.PHinzugügen.Click += new System.EventHandler(this.PHinzugügen_Click);
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
            this.Preis,
            this.verfügbarkeit,
            this.BücherTisch});
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
            this.dataGridViewProdukt.Size = new System.Drawing.Size(497, 429);
            this.dataGridViewProdukt.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.FillWeight = 60.9137F;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 30;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Produkt
            // 
            this.Produkt.FillWeight = 173.9097F;
            this.Produkt.HeaderText = "Produkt";
            this.Produkt.MinimumWidth = 50;
            this.Produkt.Name = "Produkt";
            this.Produkt.ReadOnly = true;
            // 
            // Preis
            // 
            this.Preis.FillWeight = 89.22504F;
            this.Preis.HeaderText = "Preis";
            this.Preis.MinimumWidth = 50;
            this.Preis.Name = "Preis";
            this.Preis.ReadOnly = true;
            // 
            // verfügbarkeit
            // 
            this.verfügbarkeit.FillWeight = 75.95144F;
            this.verfügbarkeit.HeaderText = "Verfügbarkeit";
            this.verfügbarkeit.MinimumWidth = 30;
            this.verfügbarkeit.Name = "verfügbarkeit";
            this.verfügbarkeit.ReadOnly = true;
            // 
            // BücherTisch
            // 
            this.BücherTisch.HeaderText = "BücherTisch";
            this.BücherTisch.MinimumWidth = 30;
            this.BücherTisch.Name = "BücherTisch";
            this.BücherTisch.ReadOnly = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"CSV-Dateien\"| *.csv";
            // 
            // statistik
            // 
            this.statistik.Location = new System.Drawing.Point(542, 6);
            this.statistik.Name = "statistik";
            this.statistik.Size = new System.Drawing.Size(128, 88);
            this.statistik.TabIndex = 8;
            this.statistik.Text = "Aktuelle Statistik von verkauften Produkten";
            this.statistik.UseVisualStyleBackColor = true;
            this.statistik.Click += new System.EventHandler(this.statistik_Click);
            // 
            // Mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 461);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(815, 450);
            this.Name = "Mainwindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bauchladen Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainwindow_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqlState)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeilnehmer)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdukt)).EndInit();
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
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TN_Name;
        private System.Windows.Forms.Label Kontostand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button TnHinzufügen;
        private System.Windows.Forms.Button TnInaktiv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox einzahlung;
        private System.Windows.Forms.Button TnEinzahlen;
        private System.Windows.Forms.Button TnAuszahlen;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button PInaktiv;
        private System.Windows.Forms.Button PLöschen;
        private System.Windows.Forms.Button PHinzugügen;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox nachname;
        private System.Windows.Forms.TextBox vorname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PPreis;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button stückelung;
        private System.Windows.Forms.Button alleAuszahlen;
        private System.Windows.Forms.Button tagesabschluss;
        private System.Windows.Forms.Button CsvEinlesen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn inaktiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produkt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preis;
        private System.Windows.Forms.DataGridViewTextBoxColumn verfügbarkeit;
        private System.Windows.Forms.DataGridViewTextBoxColumn BücherTisch;
        private System.Windows.Forms.CheckBox checkBüchertisch;
        private System.Windows.Forms.Button statistik;
    }
}

