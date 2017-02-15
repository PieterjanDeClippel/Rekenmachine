namespace Gewone_Rekenmachine
{
    partial class TussendoorBerekening
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNaam = new System.Windows.Forms.TextBox();
            this.txtBeschrijving = new System.Windows.Forms.TextBox();
            this.txtBerekening = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNegatief = new System.Windows.Forms.Button();
            this.btnWortel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(389, 165);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(470, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtNaam
            // 
            this.txtNaam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNaam.Location = new System.Drawing.Point(85, 12);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(298, 20);
            this.txtNaam.TabIndex = 24;
            // 
            // txtBeschrijving
            // 
            this.txtBeschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeschrijving.Location = new System.Drawing.Point(85, 38);
            this.txtBeschrijving.Name = "txtBeschrijving";
            this.txtBeschrijving.Size = new System.Drawing.Size(298, 20);
            this.txtBeschrijving.TabIndex = 25;
            // 
            // txtBerekening
            // 
            this.txtBerekening.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBerekening.Location = new System.Drawing.Point(85, 64);
            this.txtBerekening.Name = "txtBerekening";
            this.txtBerekening.Size = new System.Drawing.Size(236, 20);
            this.txtBerekening.TabIndex = 26;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.Location = new System.Drawing.Point(389, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(156, 131);
            this.listBox1.TabIndex = 27;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Naam:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Beschrijving:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Berekening:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Beschikbare parameters:";
            // 
            // btnNegatief
            // 
            this.btnNegatief.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNegatief.Location = new System.Drawing.Point(327, 61);
            this.btnNegatief.Name = "btnNegatief";
            this.btnNegatief.Size = new System.Drawing.Size(25, 25);
            this.btnNegatief.TabIndex = 37;
            this.btnNegatief.Text = "–";
            this.btnNegatief.UseVisualStyleBackColor = true;
            this.btnNegatief.Click += new System.EventHandler(this.btnNegatief_Click);
            // 
            // btnWortel
            // 
            this.btnWortel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWortel.Location = new System.Drawing.Point(358, 61);
            this.btnWortel.Name = "btnWortel";
            this.btnWortel.Size = new System.Drawing.Size(25, 25);
            this.btnWortel.TabIndex = 36;
            this.btnWortel.Text = "√";
            this.btnWortel.UseVisualStyleBackColor = true;
            this.btnWortel.Click += new System.EventHandler(this.btnWortel_Click);
            // 
            // TussendoorBerekening
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(557, 202);
            this.Controls.Add(this.btnNegatief);
            this.Controls.Add(this.btnWortel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtBerekening);
            this.Controls.Add(this.txtBeschrijving);
            this.Controls.Add(this.txtNaam);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "TussendoorBerekening";
            this.Text = "TussendoorBerekening";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNaam;
        private System.Windows.Forms.TextBox txtBeschrijving;
        private System.Windows.Forms.TextBox txtBerekening;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNegatief;
        private System.Windows.Forms.Button btnWortel;
    }
}