namespace BauchladenProgramm
{
    partial class ConnectionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionDialog));
            this.connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ipAdresse = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(15, 60);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 1;
            this.connect.Text = "Verbinden";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP-Adresse des Servers eintragen";
            // 
            // ipAdresse
            // 
            this.ipAdresse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ipAdresse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.ipAdresse.FormattingEnabled = true;
            this.ipAdresse.Items.AddRange(new object[] {
            "192.168.178.32",
            "192.168.2.43"});
            this.ipAdresse.Location = new System.Drawing.Point(15, 33);
            this.ipAdresse.Name = "ipAdresse";
            this.ipAdresse.Size = new System.Drawing.Size(204, 21);
            this.ipAdresse.Sorted = true;
            this.ipAdresse.TabIndex = 3;
            // 
            // ConnectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 94);
            this.Controls.Add(this.ipAdresse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionDialog";
            this.Text = "Connection Dialog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectionDialog_FormClosed);
            this.Load += new System.EventHandler(this.ConnectionDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ipAdresse;
    }
}