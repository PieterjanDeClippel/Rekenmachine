namespace Gewone_Rekenmachine
{
    partial class frmFuncties
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
			this.Functies = new System.Windows.Forms.ListBox();
			this.txtFunctieVoorschrift = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnNieuweParam = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btnParamBewerken = new System.Windows.Forms.Button();
			this.btnParamWissen = new System.Windows.Forms.Button();
			this.txtFunctieBeschrijving = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtFunctieNaam = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.pnlGrafischeFunctie = new System.Windows.Forms.Panel();
			this.btnXOR = new System.Windows.Forms.Button();
			this.btnXNOR = new System.Windows.Forms.Button();
			this.btnNegatief = new System.Windows.Forms.Button();
			this.btnWortel = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.button5 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.btnTmpBewerken = new System.Windows.Forms.Button();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnTmpWissen = new System.Windows.Forms.Button();
			this.txtCode = new System.Windows.Forms.RichTextBox();
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.pnlGrafischeFunctie.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Beschikbare functies:";
			// 
			// Functies
			// 
			this.Functies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.Functies.FormattingEnabled = true;
			this.Functies.IntegralHeight = false;
			this.Functies.Location = new System.Drawing.Point(12, 29);
			this.Functies.Name = "Functies";
			this.Functies.Size = new System.Drawing.Size(170, 310);
			this.Functies.TabIndex = 1;
			this.Functies.SelectedIndexChanged += new System.EventHandler(this.Functies_SelectedIndexChanged);
			this.Functies.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Functies_MouseDown);
			// 
			// txtFunctieVoorschrift
			// 
			this.txtFunctieVoorschrift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFunctieVoorschrift.Enabled = false;
			this.txtFunctieVoorschrift.Location = new System.Drawing.Point(79, 316);
			this.txtFunctieVoorschrift.Name = "txtFunctieVoorschrift";
			this.txtFunctieVoorschrift.Size = new System.Drawing.Size(314, 20);
			this.txtFunctieVoorschrift.TabIndex = 2;
			this.txtFunctieVoorschrift.TextChanged += new System.EventHandler(this.txtFunctieVoorschrift_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 321);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Voorschrift: ";
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader5});
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(3, 16);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(508, 75);
			this.listView1.TabIndex = 4;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.EnableParamAddButtons);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Naam";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Beschrijving";
			this.columnHeader4.Width = 116;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Optioneel";
			this.columnHeader3.Width = 68;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Standaardwaarde";
			this.columnHeader5.Width = 98;
			// 
			// btnNieuweParam
			// 
			this.btnNieuweParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNieuweParam.Location = new System.Drawing.Point(3, 97);
			this.btnNieuweParam.Name = "btnNieuweParam";
			this.btnNieuweParam.Size = new System.Drawing.Size(75, 25);
			this.btnNieuweParam.TabIndex = 5;
			this.btnNieuweParam.Text = "Nieuw";
			this.btnNieuweParam.UseVisualStyleBackColor = true;
			this.btnNieuweParam.Click += new System.EventHandler(this.btnNieuweParam_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Parameters:";
			// 
			// btnParamBewerken
			// 
			this.btnParamBewerken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnParamBewerken.Enabled = false;
			this.btnParamBewerken.Location = new System.Drawing.Point(84, 97);
			this.btnParamBewerken.Name = "btnParamBewerken";
			this.btnParamBewerken.Size = new System.Drawing.Size(75, 25);
			this.btnParamBewerken.TabIndex = 7;
			this.btnParamBewerken.Text = "Bewerken";
			this.btnParamBewerken.UseVisualStyleBackColor = true;
			this.btnParamBewerken.Click += new System.EventHandler(this.btnParamBewerken_Click);
			// 
			// btnParamWissen
			// 
			this.btnParamWissen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnParamWissen.Enabled = false;
			this.btnParamWissen.Location = new System.Drawing.Point(165, 97);
			this.btnParamWissen.Name = "btnParamWissen";
			this.btnParamWissen.Size = new System.Drawing.Size(75, 25);
			this.btnParamWissen.TabIndex = 8;
			this.btnParamWissen.Text = "Verwijder";
			this.btnParamWissen.UseVisualStyleBackColor = true;
			this.btnParamWissen.Click += new System.EventHandler(this.btnParamWissen_Click);
			// 
			// txtFunctieBeschrijving
			// 
			this.txtFunctieBeschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFunctieBeschrijving.Enabled = false;
			this.txtFunctieBeschrijving.Location = new System.Drawing.Point(79, 26);
			this.txtFunctieBeschrijving.Name = "txtFunctieBeschrijving";
			this.txtFunctieBeschrijving.Size = new System.Drawing.Size(438, 20);
			this.txtFunctieBeschrijving.TabIndex = 9;
			this.txtFunctieBeschrijving.TextChanged += new System.EventHandler(this.txtFunctieBeschrijving_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Beschrijving: ";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(552, 376);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 25);
			this.btnOK.TabIndex = 23;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(633, 376);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 25);
			this.btnCancel.TabIndex = 22;
			this.btnCancel.Text = "Annuleren";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// txtFunctieNaam
			// 
			this.txtFunctieNaam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFunctieNaam.Enabled = false;
			this.txtFunctieNaam.Location = new System.Drawing.Point(79, 0);
			this.txtFunctieNaam.Name = "txtFunctieNaam";
			this.txtFunctieNaam.Size = new System.Drawing.Size(438, 20);
			this.txtFunctieNaam.TabIndex = 24;
			this.txtFunctieNaam.TextChanged += new System.EventHandler(this.txtFunctieNaam_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "Naam:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(93, 345);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 25);
			this.button1.TabIndex = 28;
			this.button1.Text = "Verwijder";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.Location = new System.Drawing.Point(12, 345);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 25);
			this.button3.TabIndex = 26;
			this.button3.Text = "Nieuw";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// pnlGrafischeFunctie
			// 
			this.pnlGrafischeFunctie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlGrafischeFunctie.Controls.Add(this.btnXOR);
			this.pnlGrafischeFunctie.Controls.Add(this.btnXNOR);
			this.pnlGrafischeFunctie.Controls.Add(this.btnNegatief);
			this.pnlGrafischeFunctie.Controls.Add(this.btnWortel);
			this.pnlGrafischeFunctie.Controls.Add(this.splitContainer1);
			this.pnlGrafischeFunctie.Controls.Add(this.label5);
			this.pnlGrafischeFunctie.Controls.Add(this.label2);
			this.pnlGrafischeFunctie.Controls.Add(this.txtFunctieNaam);
			this.pnlGrafischeFunctie.Controls.Add(this.txtFunctieVoorschrift);
			this.pnlGrafischeFunctie.Controls.Add(this.txtFunctieBeschrijving);
			this.pnlGrafischeFunctie.Controls.Add(this.label4);
			this.pnlGrafischeFunctie.Location = new System.Drawing.Point(188, 29);
			this.pnlGrafischeFunctie.Name = "pnlGrafischeFunctie";
			this.pnlGrafischeFunctie.Size = new System.Drawing.Size(520, 341);
			this.pnlGrafischeFunctie.TabIndex = 29;
			this.pnlGrafischeFunctie.Visible = false;
			// 
			// btnXOR
			// 
			this.btnXOR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnXOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXOR.Location = new System.Drawing.Point(461, 313);
			this.btnXOR.Name = "btnXOR";
			this.btnXOR.Size = new System.Drawing.Size(25, 25);
			this.btnXOR.TabIndex = 37;
			this.btnXOR.Text = "⊕";
			this.btnXOR.UseVisualStyleBackColor = true;
			this.btnXOR.Click += new System.EventHandler(this.btnTeken);
			// 
			// btnXNOR
			// 
			this.btnXNOR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnXNOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXNOR.Location = new System.Drawing.Point(492, 313);
			this.btnXNOR.Name = "btnXNOR";
			this.btnXNOR.Size = new System.Drawing.Size(25, 25);
			this.btnXNOR.TabIndex = 36;
			this.btnXNOR.Text = "⊖";
			this.btnXNOR.UseVisualStyleBackColor = true;
			this.btnXNOR.Click += new System.EventHandler(this.btnTeken);
			// 
			// btnNegatief
			// 
			this.btnNegatief.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNegatief.Location = new System.Drawing.Point(399, 313);
			this.btnNegatief.Name = "btnNegatief";
			this.btnNegatief.Size = new System.Drawing.Size(25, 25);
			this.btnNegatief.TabIndex = 35;
			this.btnNegatief.Text = "–";
			this.btnNegatief.UseVisualStyleBackColor = true;
			this.btnNegatief.Click += new System.EventHandler(this.btnTeken);
			// 
			// btnWortel
			// 
			this.btnWortel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWortel.Location = new System.Drawing.Point(430, 313);
			this.btnWortel.Name = "btnWortel";
			this.btnWortel.Size = new System.Drawing.Size(25, 25);
			this.btnWortel.TabIndex = 34;
			this.btnWortel.Text = "√";
			this.btnWortel.UseVisualStyleBackColor = true;
			this.btnWortel.Click += new System.EventHandler(this.btnTeken);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(3, 52);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.listView1);
			this.splitContainer1.Panel1.Controls.Add(this.btnNieuweParam);
			this.splitContainer1.Panel1.Controls.Add(this.btnParamWissen);
			this.splitContainer1.Panel1.Controls.Add(this.btnParamBewerken);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.button5);
			this.splitContainer1.Panel2.Controls.Add(this.label6);
			this.splitContainer1.Panel2.Controls.Add(this.btnTmpBewerken);
			this.splitContainer1.Panel2.Controls.Add(this.listView2);
			this.splitContainer1.Panel2.Controls.Add(this.btnTmpWissen);
			this.splitContainer1.Size = new System.Drawing.Size(514, 260);
			this.splitContainer1.SplitterDistance = 125;
			this.splitContainer1.TabIndex = 33;
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button5.Location = new System.Drawing.Point(3, 103);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 25);
			this.button5.TabIndex = 28;
			this.button5.Text = "Nieuw";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(134, 13);
			this.label6.TabIndex = 27;
			this.label6.Text = "Tussendoor berekeningen:";
			// 
			// btnTmpBewerken
			// 
			this.btnTmpBewerken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnTmpBewerken.Enabled = false;
			this.btnTmpBewerken.Location = new System.Drawing.Point(84, 103);
			this.btnTmpBewerken.Name = "btnTmpBewerken";
			this.btnTmpBewerken.Size = new System.Drawing.Size(75, 25);
			this.btnTmpBewerken.TabIndex = 29;
			this.btnTmpBewerken.Text = "Bewerken";
			this.btnTmpBewerken.UseVisualStyleBackColor = true;
			this.btnTmpBewerken.Click += new System.EventHandler(this.btnTmpBewerken_Click);
			// 
			// listView2
			// 
			this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader7});
			this.listView2.FullRowSelect = true;
			this.listView2.HideSelection = false;
			this.listView2.Location = new System.Drawing.Point(3, 16);
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(508, 81);
			this.listView2.TabIndex = 26;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.Details;
			this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Naam";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Beschrijving";
			this.columnHeader8.Width = 120;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Berekening";
			this.columnHeader7.Width = 264;
			// 
			// btnTmpWissen
			// 
			this.btnTmpWissen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnTmpWissen.Enabled = false;
			this.btnTmpWissen.Location = new System.Drawing.Point(165, 103);
			this.btnTmpWissen.Name = "btnTmpWissen";
			this.btnTmpWissen.Size = new System.Drawing.Size(75, 25);
			this.btnTmpWissen.TabIndex = 30;
			this.btnTmpWissen.Text = "Verwijder";
			this.btnTmpWissen.UseVisualStyleBackColor = true;
			this.btnTmpWissen.Click += new System.EventHandler(this.btnTmpWissen_Click);
			// 
			// txtCode
			// 
			this.txtCode.AcceptsTab = true;
			this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCode.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCode.Location = new System.Drawing.Point(188, 29);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(520, 341);
			this.txtCode.TabIndex = 31;
			this.txtCode.Text = "";
			this.txtCode.Visible = false;
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.SynchronizingObject = this;
			// 
			// frmFuncties
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(720, 413);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.Functies);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pnlGrafischeFunctie);
			this.Controls.Add(this.txtCode);
			this.Name = "frmFuncties";
			this.Text = "Functies bewerken";
			this.pnlGrafischeFunctie.ResumeLayout(false);
			this.pnlGrafischeFunctie.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Functies;
        private System.Windows.Forms.TextBox txtFunctieVoorschrift;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnNieuweParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnParamBewerken;
        private System.Windows.Forms.Button btnParamWissen;
        private System.Windows.Forms.TextBox txtFunctieBeschrijving;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFunctieNaam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel pnlGrafischeFunctie;
        private System.Windows.Forms.RichTextBox txtCode;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnTmpBewerken;
        private System.Windows.Forms.Button btnTmpWissen;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnWortel;
        private System.Windows.Forms.Button btnNegatief;
		private System.Windows.Forms.Button btnXOR;
		private System.Windows.Forms.Button btnXNOR;
	}
}