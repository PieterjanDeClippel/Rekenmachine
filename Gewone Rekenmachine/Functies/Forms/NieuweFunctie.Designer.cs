namespace Gewone_Rekenmachine
{
    partial class NieuweFunctie
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
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rbnGui = new System.Windows.Forms.RadioButton();
            this.rbnCode = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnuleren.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuleren.Location = new System.Drawing.Point(233, 67);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(100, 25);
            this.btnAnnuleren.TabIndex = 0;
            this.btnAnnuleren.Text = "Annuleren";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(127, 67);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // rbnGui
            // 
            this.rbnGui.AutoSize = true;
            this.rbnGui.Checked = true;
            this.rbnGui.Location = new System.Drawing.Point(13, 13);
            this.rbnGui.Name = "rbnGui";
            this.rbnGui.Size = new System.Drawing.Size(137, 17);
            this.rbnGui.TabIndex = 2;
            this.rbnGui.TabStop = true;
            this.rbnGui.Text = "Ik wil een gui gebruiken";
            this.rbnGui.UseVisualStyleBackColor = true;
            // 
            // rbnCode
            // 
            this.rbnCode.AutoSize = true;
            this.rbnCode.Location = new System.Drawing.Point(13, 37);
            this.rbnCode.Name = "rbnCode";
            this.rbnCode.Size = new System.Drawing.Size(132, 17);
            this.rbnCode.TabIndex = 3;
            this.rbnCode.Text = "Maak een codefunctie";
            this.rbnCode.UseVisualStyleBackColor = true;
            // 
            // NieuweFunctie
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuleren;
            this.ClientSize = new System.Drawing.Size(345, 104);
            this.Controls.Add(this.rbnCode);
            this.Controls.Add(this.rbnGui);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAnnuleren);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NieuweFunctie";
            this.Text = "NieuweFunctie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rbnGui;
        private System.Windows.Forms.RadioButton rbnCode;
    }
}