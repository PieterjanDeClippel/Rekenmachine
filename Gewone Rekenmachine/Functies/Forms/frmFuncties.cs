using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Gewone_Rekenmachine
{
    public partial class frmFuncties : Form
    {
        List<Functie> functies = new List<Functie>();
        string mapnaam_func = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Rekenmachine\Functies\";


        public frmFuncties()
        {
            InitializeComponent();
            MaakFuncties();
            /*
            Rijndael r = Rijndael.Create();
            string t = "byte[] key = new byte[] {";
            foreach (byte i in r.Key)
                t += ((int)i).ToString() + ",";
            t = t.Substring(0, t.Length - 1) + "};\r\nbyte[] IV = new byte[] {";
            foreach (byte i in r.IV)
                t += ((int)i).ToString() + ",";
            t = t.Substring(0, t.Length - 1) + "};";
            Clipboard.SetText(t);
            MessageBox.Show("Sleutel gekopieerd");*/
        }

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

		byte[] key = new byte[] { 145, 115, 204, 18, 169, 243, 250, 105, 39, 138, 185, 220, 40, 26, 170, 245, 197, 6, 10, 197, 197, 63, 70, 94, 112, 51, 156, 86, 54, 110, 252, 225 };
        byte[] IV = new byte[] { 244, 50, 208, 23, 38, 58, 11, 60, 87, 120, 171, 126, 57, 59, 26, 142 };
        
        void MaakFuncties()
        {
            foreach(string bestand in Directory.GetFiles(mapnaam_func))
            {
                FileStream fs = new FileStream(bestand, FileMode.Open);
                Rijndael rijAlg = Rijndael.Create();
                rijAlg.Key = key;
                rijAlg.IV = IV;
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(key,IV);

                CryptoStream cs = new CryptoStream(fs, decryptor, CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cs);
                
                string soort_functie = reader.ReadLine();
                switch (soort_functie)
                {
                    case "gui":
                        GrafischeFunctie f1 = new GrafischeFunctie();
                        f1.Beschrijving = reader.ReadLine();
                        f1.Voorschrift = reader.ReadLine();
                        f1.Naam = Path.GetFileNameWithoutExtension(bestand);

                        string tekst = reader.ReadToEnd().Trim();
                        string[] par = tekst.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
                        string parameters = par[0];
                        string tmp = par.Length < 2 ? "" : par[1];

                        foreach (string paramtekst in parameters.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                        {
                            Parameter p = new Parameter();
                            string[] it = paramtekst.Split(';');
                            p.Naam = it[0];
                            p.Beschrijving = it[1];
                            p.Is_Getal = it[2] == "getal";
                            p.EnumNaam = p.Is_Getal ? "" : it[2];
                            p.Optioneel = it[3] == "1";
                            p.StandaardWaarde = Convert.ToDouble(it[4]);
                            f1.Parameters.Add(p);
                        }
                        if(tmp != "")
                            foreach(string tmp_var in tmp.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                            {
                                Tmp_Param p = new Tmp_Param();
                                string[] it = tmp_var.Split(';');
                                p.Naam = it[0];
                                p.Beschrijving = it[1];
                                p.Berekening = it[2];
                                f1.Temp.Add(p);
                            }
                        functies.Add(f1);
                        Functies.Items.Add(f1.Naam);
                        break;
                    case "tekst":
                        TekstFunctie f2 = new TekstFunctie();
                        f2.Parse(reader.ReadToEnd());
                        functies.Add(f2);
                        Functies.Items.Add(Path.GetFileNameWithoutExtension(bestand));
                        break;
                }
                reader.Close();
                fs.Close();
            }
        }

        private void Functies_SelectedIndexChanged(object sender, EventArgs e)
        {
            changing = true;
            button1.Enabled = Functies.SelectedIndex != -1;
            if (Functies.SelectedIndex != -1)
            {
                Functie item = functies[Functies.SelectedIndex];
                switch (item.Functie_Type)
                {
                    case Functie.enFunctie_type.gui:
                        txtCode.Hide();
                        txtFunctieBeschrijving.Enabled = true;
                        txtFunctieNaam.Enabled = true;
                        txtFunctieVoorschrift.Enabled = true;

                        GrafischeFunctie f = (GrafischeFunctie)functies[Functies.SelectedIndex];
                        txtFunctieNaam.Text = f.Naam;
                        txtFunctieBeschrijving.Text = f.Beschrijving;
                        txtFunctieVoorschrift.Text = f.Voorschrift;

                        listView1.Items.Clear();
                        foreach (Parameter param in f.Parameters)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = param.Naam;
                            lvi.SubItems.Add(param.Is_Getal ? "Getal" : param.EnumNaam);
                            lvi.SubItems.Add(param.Beschrijving);
                            lvi.SubItems.Add(param.Optioneel ? "ja" : "nee");
                            lvi.SubItems.Add(param.Is_Getal ? param.StandaardWaarde.ToString() : "");
                            listView1.Items.Add(lvi);
                        }

                        listView2.Items.Clear();
                        foreach(Tmp_Param param in f.Temp)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = param.Naam;
                            lvi.SubItems.Add(param.Beschrijving);
                            lvi.SubItems.Add(param.Berekening);
                            listView2.Items.Add(lvi);
                        }

                        pnlGrafischeFunctie.Show();
                        break;
                    case Functie.enFunctie_type.tekst:
                        pnlGrafischeFunctie.Hide();
                        TekstFunctie ft = (TekstFunctie)functies[Functies.SelectedIndex];
                        txtCode.Text = ft.ToString();
                        txtCode.Show();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                txtFunctieBeschrijving.Enabled = false;
                txtFunctieNaam.Enabled = false;
                txtFunctieVoorschrift.Enabled = false;
                pnlGrafischeFunctie.Hide();
                txtCode.Hide();
            }
            EnableParamAddButtons(this, EventArgs.Empty);
            changing = false;
        }
        private void EnableParamAddButtons(object sender, EventArgs e)
        {
            bool t = listView1.SelectedItems.Count != 0;
            btnParamBewerken.Enabled = t;
            btnParamWissen.Enabled = t;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool t = listView2.SelectedItems.Count != 0;
            btnTmpBewerken.Enabled = t;
            btnTmpWissen.Enabled = t;
        }
        private void btnParamBewerken_Click(object sender, EventArgs e)
        {
            ParameterBewerken frm = new ParameterBewerken();
            Parameter p;
            GrafischeFunctie g = (GrafischeFunctie)functies[Functies.SelectedIndex];
            frm.ShowDialog(g.Parameters[listView1.SelectedIndices[0]], out p);
            g.Parameters[listView1.SelectedIndices[0]] = p;
            ListViewItem lvi = listView1.SelectedItems[0];
            lvi.Text = p.Naam;
            lvi.SubItems[2].Text = p.Beschrijving;
            lvi.SubItems[3].Text = p.Optioneel ? "ja" : "nee";
            lvi.SubItems[4].Text = p.Is_Getal ? p.StandaardWaarde.ToString() : "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string[] bestanden = Directory.GetFiles(mapnaam_func, "*.func");
            foreach (string bestand in bestanden)
                File.Delete(bestand);

            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = key;
            rijndael.IV = IV;
            ICryptoTransform sleutel = rijndael.CreateEncryptor();

            foreach (Functie f in functies)
            {
                switch (f.Functie_Type)
                {
                    case Functie.enFunctie_type.gui:
                        GrafischeFunctie gf = (GrafischeFunctie)f;
                        StringBuilder b = new StringBuilder();
                        b.AppendLine("gui");
                        b.AppendLine(gf.Beschrijving);
                        b.AppendLine(gf.Voorschrift);
                        b.AppendLine();
                        foreach (Parameter p in gf.Parameters)
                        {
                            b.AppendLine(string.Join(";", new string[] { p.Naam, p.Beschrijving, p.Is_Getal ? "getal" : p.EnumNaam, p.Optioneel ? "1" : "0", p.StandaardWaarde.ToString() }));
                        }
                        b.AppendLine();
                        foreach(Tmp_Param p in gf.Temp)
                        {
                            b.AppendLine(string.Join(";", new string[] { p.Naam, p.Beschrijving, p.Berekening }));
                        }

                        string bestand = mapnaam_func + gf.Naam + ".func";
                        FileStream fs = new FileStream(bestand, FileMode.Create);
                        CryptoStream cs = new CryptoStream(fs, sleutel, CryptoStreamMode.Write);
                        StreamWriter writer = new StreamWriter(cs);
                        writer.Write(b.ToString());
                        writer.Close();
                        fs.Close();
                        break;
                    case Functie.enFunctie_type.tekst:
                        TekstFunctie tf = (TekstFunctie)f;

                        string bestand2 = mapnaam_func + tf.Naam + ".func";
                        FileStream fs2 = new FileStream(bestand2, FileMode.Create);
                        CryptoStream cs2 = new CryptoStream(fs2, sleutel, CryptoStreamMode.Write);
                        StreamWriter writer2 = new StreamWriter(cs2);
                        writer2.Write("tekst\r\n" + tf.ToString());
                        writer2.Close();
                        fs2.Close();
                        break;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        bool changing = false;
        private void txtFunctieNaam_TextChanged(object sender, EventArgs e)
        {
            if (changing) return;
            GrafischeFunctie f = (GrafischeFunctie)functies[Functies.SelectedIndex];
            f.Naam = txtFunctieNaam.Text;
            // annoying windows forms bug
            Functies.SelectedIndexChanged -= Functies_SelectedIndexChanged;
            Functies.Items[Functies.SelectedIndex] = txtFunctieNaam.Text;
            Functies.SelectedIndexChanged += Functies_SelectedIndexChanged;
        }

        private void txtFunctieBeschrijving_TextChanged(object sender, EventArgs e)
        {
            if (changing) return;
            GrafischeFunctie f = (GrafischeFunctie)functies[Functies.SelectedIndex];
            f.Beschrijving = txtFunctieBeschrijving.Text;
        }

        private void txtFunctieVoorschrift_TextChanged(object sender, EventArgs e)
        {
            if (changing) return;
            GrafischeFunctie f = (GrafischeFunctie)functies[Functies.SelectedIndex];
            f.Voorschrift = txtFunctieVoorschrift.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCode.Rtf.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtCode.SelectionColor = Color.Blue;
        }

        private void btnNieuweParam_Click(object sender, EventArgs e)
        {
            GrafischeFunctie g = (GrafischeFunctie)functies[Functies.SelectedIndex];
            Parameter nieuw = new Parameter();
            ParameterBewerken frm = new ParameterBewerken();
            if (frm.ShowDialog(nieuw, out nieuw) == DialogResult.OK)
            {
                g.Parameters.Add(nieuw);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = nieuw.Naam;
                lvi.SubItems.Add(nieuw.Is_Getal ? "Getal" : nieuw.EnumNaam);
                lvi.SubItems.Add(nieuw.Beschrijving);
                lvi.SubItems.Add(nieuw.Optioneel ? "ja" : "nee");
                lvi.SubItems.Add(nieuw.Is_Getal ? nieuw.StandaardWaarde.ToString() : "");
                listView1.Items.Add(lvi);
            }
        }
        private void btnParamWissen_Click(object sender, EventArgs e)
        {
            GrafischeFunctie g = (GrafischeFunctie)functies[Functies.SelectedIndex];
            g.Parameters.RemoveAt(listView1.SelectedIndices[0]);
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        public const int WM_ERASEBKGND = 0x0014;
        [DebuggerNonUserCode()]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WM_ERASEBKGND)
                m.Result = IntPtr.Zero;
            base.WndProc(ref m);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GrafischeFunctie g = (GrafischeFunctie)functies[Functies.SelectedIndex];
            Tmp_Param nieuw = new Tmp_Param();
            TussendoorBerekening frm = new TussendoorBerekening();

            ListViewItem[] lvis = new ListViewItem[listView1.Items.Count];
            listView1.Items.CopyTo(lvis, 0);

            if (frm.ShowDialog(nieuw, lvis.Select(T => T.SubItems[0].Text).ToList(), out nieuw) == DialogResult.OK)
            {
                g.Temp.Add(nieuw);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = nieuw.Naam;
                lvi.SubItems.Add(nieuw.Beschrijving);
                lvi.SubItems.Add(nieuw.Berekening);
                listView2.Items.Add(lvi);
            }
        }

        private void btnTmpBewerken_Click(object sender, EventArgs e)
        {
            TussendoorBerekening frm = new TussendoorBerekening();
            Tmp_Param p;
            GrafischeFunctie g = (GrafischeFunctie)functies[Functies.SelectedIndex];

            ListViewItem[] lvis = new ListViewItem[listView1.Items.Count];
            listView1.Items.CopyTo(lvis, 0);

            frm.ShowDialog(g.Temp[listView2.SelectedIndices[0]], lvis.Select(T => T.SubItems[0].Text).ToList(), out p);
            g.Temp[listView2.SelectedIndices[0]] = p;
            ListViewItem lvi = listView2.SelectedItems[0];
            lvi.Text = p.Naam;
            lvi.SubItems[1].Text = p.Beschrijving;
            lvi.SubItems[2].Text = p.Berekening;
        }

        private void btnTmpWissen_Click(object sender, EventArgs e)
        {
            GrafischeFunctie g = (GrafischeFunctie)functies[Functies.SelectedIndex];
            g.Temp.RemoveAt(listView2.SelectedIndices[0]);
            listView2.Items.Remove(listView2.SelectedItems[0]);
        }

        private void Functies_MouseDown(object sender, MouseEventArgs e)
        {
            Functies.SelectedIndex = Functies.IndexFromPoint(e.Location);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NieuweFunctie frm = new NieuweFunctie();
            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                switch(frm.GekozenSoort)
                {
                    case Functie.enFunctie_type.gui:
                        GrafischeFunctie nieuwgf = new GrafischeFunctie();
                        nieuwgf.Naam = "nieuwe functie";
                        functies.Add(nieuwgf);
                        Functies.Items.Add(nieuwgf.Naam);
                        break;
                    case Functie.enFunctie_type.tekst:
                        TekstFunctie nieuwtf = new TekstFunctie();
                        nieuwtf.Parse("function nieuwefunctie()\r\n{\r\n}");
                        functies.Add(nieuwtf);
                        Functies.Items.Add("nieuwefunctie");
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Functie item = functies[Functies.SelectedIndex];
            functies.RemoveAt(Functies.SelectedIndex);
            Functies.Items.RemoveAt(Functies.SelectedIndex);
        }

        private void btnTeken(object sender, EventArgs e)
        {
            int index = txtFunctieVoorschrift.SelectionStart;
            int lengte = txtFunctieVoorschrift.SelectionLength;

            string txt = 
                txtFunctieVoorschrift.Text.Substring(0, index) + 
                ((Control)sender).Text + 
                txtFunctieVoorschrift.Text.Substring(index + lengte);
            txtFunctieVoorschrift.Text = txt;
            txtFunctieVoorschrift.Focus();
            txtFunctieVoorschrift.SelectionStart = index + 1;
            txtFunctieVoorschrift.SelectionLength = 0;
        }
    }
}