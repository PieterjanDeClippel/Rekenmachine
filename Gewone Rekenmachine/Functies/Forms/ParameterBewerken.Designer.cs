namespace Gewone_Rekenmachine
{
    partial class ParameterBewerken
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
            this.txtParamNaam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbnTypeGetal = new System.Windows.Forms.RadioButton();
            this.rbnTypeEnum = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Enums = new System.Windows.Forms.ListBox();
            this.btnEnumWissen = new System.Windows.Forms.Button();
            this.btnEnumBewerken = new System.Windows.Forms.Button();
            this.btnNieuweEnum = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBeschrijving = new System.Windows.Forms.TextBox();
            this.chkOptioneel = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStandaardWaarde = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtParamNaam
            // 
            this.txtParamNaam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParamNaam.Location = new System.Drawing.Point(25, 25);
            this.txtParamNaam.Name = "txtParamNaam";
            this.txtParamNaam.Size = new System.Drawing.Size(299, 20);
            this.txtParamNaam.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naam:";
            // 
            // rbnTypeGetal
            // 
            this.rbnTypeGetal.AutoSize = true;
            this.rbnTypeGetal.Checked = true;
            this.rbnTypeGetal.Location = new System.Drawing.Point(3, 3);
            this.rbnTypeGetal.Name = "rbnTypeGetal";
            this.rbnTypeGetal.Size = new System.Drawing.Size(50, 17);
            this.rbnTypeGetal.TabIndex = 2;
            this.rbnTypeGetal.TabStop = true;
            this.rbnTypeGetal.Text = "Getal";
            this.rbnTypeGetal.UseVisualStyleBackColor = true;
            this.rbnTypeGetal.CheckedChanged += new System.EventHandler(this.rbnTypeGetal_CheckedChanged);
            // 
            // rbnTypeEnum
            // 
            this.rbnTypeEnum.AutoSize = true;
            this.rbnTypeEnum.Location = new System.Drawing.Point(59, 3);
            this.rbnTypeEnum.Name = "rbnTypeEnum";
            this.rbnTypeEnum.Size = new System.Drawing.Size(52, 17);
            this.rbnTypeEnum.TabIndex = 3;
            this.rbnTypeEnum.Text = "Enum";
            this.rbnTypeEnum.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type:";
            // 
            // Enums
            // 
            this.Enums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Enums.FormattingEnabled = true;
            this.Enums.IntegralHeight = false;
            this.Enums.Location = new System.Drawing.Point(6, 19);
            this.Enums.Name = "Enums";
            this.Enums.Size = new System.Drawing.Size(287, 61);
            this.Enums.TabIndex = 5;
            this.Enums.SelectedIndexChanged += new System.EventHandler(this.Enums_SelectedIndexChanged);
            // 
            // btnEnumWissen
            // 
            this.btnEnumWissen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnumWissen.Enabled = false;
            this.btnEnumWissen.Location = new System.Drawing.Point(168, 86);
            this.btnEnumWissen.Name = "btnEnumWissen";
            this.btnEnumWissen.Size = new System.Drawing.Size(75, 25);
            this.btnEnumWissen.TabIndex = 11;
            this.btnEnumWissen.Text = "Verwijder";
            this.btnEnumWissen.UseVisualStyleBackColor = true;
            // 
            // btnEnumBewerken
            // 
            this.btnEnumBewerken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnumBewerken.Enabled = false;
            this.btnEnumBewerken.Location = new System.Drawing.Point(87, 86);
            this.btnEnumBewerken.Name = "btnEnumBewerken";
            this.btnEnumBewerken.Size = new System.Drawing.Size(75, 25);
            this.btnEnumBewerken.TabIndex = 10;
            this.btnEnumBewerken.Text = "Bewerken";
            this.btnEnumBewerken.UseVisualStyleBackColor = true;
            this.btnEnumBewerken.Click += new System.EventHandler(this.btnEnumBewerken_Click);
            // 
            // btnNieuweEnum
            // 
            this.btnNieuweEnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNieuweEnum.Location = new System.Drawing.Point(6, 86);
            this.btnNieuweEnum.Name = "btnNieuweEnum";
            this.btnNieuweEnum.Size = new System.Drawing.Size(75, 25);
            this.btnNieuweEnum.TabIndex = 9;
            this.btnNieuweEnum.Text = "Nieuw";
            this.btnNieuweEnum.UseVisualStyleBackColor = true;
            this.btnNieuweEnum.Click += new System.EventHandler(this.btnNieuweEnum_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Enums);
            this.groupBox1.Controls.Add(this.btnEnumWissen);
            this.groupBox1.Controls.Add(this.btnNieuweEnum);
            this.groupBox1.Controls.Add(this.btnEnumBewerken);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(25, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 117);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Beschikbare enums";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.rbnTypeGetal);
            this.flowLayoutPanel1.Controls.Add(this.rbnTypeEnum);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(25, 64);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(299, 23);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Beschrijving:";
            // 
            // txtBeschrijving
            // 
            this.txtBeschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeschrijving.Location = new System.Drawing.Point(25, 229);
            this.txtBeschrijving.Name = "txtBeschrijving";
            this.txtBeschrijving.Size = new System.Drawing.Size(299, 20);
            this.txtBeschrijving.TabIndex = 14;
            // 
            // chkOptioneel
            // 
            this.chkOptioneel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOptioneel.AutoSize = true;
            this.chkOptioneel.Location = new System.Drawing.Point(15, 255);
            this.chkOptioneel.Name = "chkOptioneel";
            this.chkOptioneel.Size = new System.Drawing.Size(71, 17);
            this.chkOptioneel.TabIndex = 16;
            this.chkOptioneel.Text = "Optioneel";
            this.chkOptioneel.UseVisualStyleBackColor = true;
            this.chkOptioneel.CheckedChanged += new System.EventHandler(this.chkOptioneel_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(22, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Standaardwaarde:";
            // 
            // txtStandaardWaarde
            // 
            this.txtStandaardWaarde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStandaardWaarde.Enabled = false;
            this.txtStandaardWaarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStandaardWaarde.Location = new System.Drawing.Point(122, 278);
            this.txtStandaardWaarde.Name = "txtStandaardWaarde";
            this.txtStandaardWaarde.Size = new System.Drawing.Size(202, 21);
            this.txtStandaardWaarde.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(249, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(168, 305);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // ParameterBewerken
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(336, 342);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtStandaardWaarde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkOptioneel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBeschrijving);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParamNaam);
            this.Name = "ParameterBewerken";
            this.Text = "Parameter bewerken";
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtParamNaam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbnTypeGetal;
        private System.Windows.Forms.RadioButton rbnTypeEnum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Enums;
        private System.Windows.Forms.Button btnEnumWissen;
        private System.Windows.Forms.Button btnEnumBewerken;
        private System.Windows.Forms.Button btnNieuweEnum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBeschrijving;
        private System.Windows.Forms.CheckBox chkOptioneel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStandaardWaarde;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}