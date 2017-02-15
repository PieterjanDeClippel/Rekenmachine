namespace Gewone_Rekenmachine
{
    partial class EnumBewerken
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNaam = new System.Windows.Forms.TextBox();
            this.btnEnumMemberWissen = new System.Windows.Forms.Button();
            this.btnNieuwEnumMember = new System.Windows.Forms.Button();
            this.btnEnumMemberBewerken = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Naam:";
            // 
            // txtNaam
            // 
            this.txtNaam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNaam.Location = new System.Drawing.Point(25, 25);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(332, 20);
            this.txtNaam.TabIndex = 2;
            // 
            // btnEnumMemberWissen
            // 
            this.btnEnumMemberWissen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnumMemberWissen.Enabled = false;
            this.btnEnumMemberWissen.Location = new System.Drawing.Point(187, 197);
            this.btnEnumMemberWissen.Name = "btnEnumMemberWissen";
            this.btnEnumMemberWissen.Size = new System.Drawing.Size(75, 25);
            this.btnEnumMemberWissen.TabIndex = 11;
            this.btnEnumMemberWissen.Text = "Verwijder";
            this.btnEnumMemberWissen.UseVisualStyleBackColor = true;
            this.btnEnumMemberWissen.Click += new System.EventHandler(this.btnEnumMemberWissen_Click);
            // 
            // btnNieuwEnumMember
            // 
            this.btnNieuwEnumMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNieuwEnumMember.Location = new System.Drawing.Point(25, 197);
            this.btnNieuwEnumMember.Name = "btnNieuwEnumMember";
            this.btnNieuwEnumMember.Size = new System.Drawing.Size(75, 25);
            this.btnNieuwEnumMember.TabIndex = 9;
            this.btnNieuwEnumMember.Text = "Nieuw";
            this.btnNieuwEnumMember.UseVisualStyleBackColor = true;
            this.btnNieuwEnumMember.Click += new System.EventHandler(this.btnNieuwEnumMember_Click);
            // 
            // btnEnumMemberBewerken
            // 
            this.btnEnumMemberBewerken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnumMemberBewerken.Enabled = false;
            this.btnEnumMemberBewerken.Location = new System.Drawing.Point(106, 197);
            this.btnEnumMemberBewerken.Name = "btnEnumMemberBewerken";
            this.btnEnumMemberBewerken.Size = new System.Drawing.Size(75, 25);
            this.btnEnumMemberBewerken.TabIndex = 10;
            this.btnEnumMemberBewerken.Text = "Bewerken";
            this.btnEnumMemberBewerken.UseVisualStyleBackColor = true;
            this.btnEnumMemberBewerken.Click += new System.EventHandler(this.btnEnumMemberBewerken_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Elementen:";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(25, 64);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(332, 127);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Naam";
            this.columnHeader1.Width = 157;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Waarde";
            this.columnHeader2.Width = 170;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(201, 228);
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
            this.btnCancel.Location = new System.Drawing.Point(282, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // EnumBewerken
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(369, 265);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnEnumMemberWissen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNieuwEnumMember);
            this.Controls.Add(this.btnEnumMemberBewerken);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNaam);
            this.Name = "EnumBewerken";
            this.Text = "EnumBewerken";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNaam;
        private System.Windows.Forms.Button btnEnumMemberWissen;
        private System.Windows.Forms.Button btnNieuwEnumMember;
        private System.Windows.Forms.Button btnEnumMemberBewerken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}