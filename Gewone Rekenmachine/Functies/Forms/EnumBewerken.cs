using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gewone_Rekenmachine
{
    public partial class EnumBewerken : Form
    {
        public EnumBewerken()
        {
            InitializeComponent();
        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool b = listView1.SelectedItems.Count != 0;
            btnEnumMemberBewerken.Enabled = b;
            btnEnumMemberWissen.Enabled = b;
        }

        private void btnEnumMemberBewerken_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = listView1.SelectedItems[0];
            EnumElementBewerken frm = new EnumElementBewerken();
            string enumnaam;
            double enumwaarde;
            frm.ShowDialog(lvi.Text, Convert.ToDouble(lvi.SubItems[1].Text), out enumnaam, out enumwaarde);
            lvi.Text = enumnaam;
            lvi.SubItems[1].Text = enumwaarde.ToString();
        }

        public void ShowDialog(string EnumNaam)
        {
            string bestandsnaam = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Rekenmachine\Enums\{0}.enum";
            FileStream fs = new FileStream(string.Format(bestandsnaam, EnumNaam), FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            string tekst = reader.ReadToEnd();
            reader.Close();
            fs.Close();
            
            txtNaam.Text = EnumNaam;
            string[] elementen = tekst.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            listView1.Items.Clear();
            foreach(string element in elementen)
            {
                string[] naamwaarde = element.Split('\t');
                ListViewItem lvi = new ListViewItem();
                lvi.Text = naamwaarde[1];
                lvi.SubItems.Add(naamwaarde[0]);
                listView1.Items.Add(lvi);
            }

            if(this.ShowDialog() == DialogResult.OK)
            {
                ListViewItem[] lvis = new ListViewItem[listView1.Items.Count];
                listView1.Items.CopyTo(lvis, 0);
                string result = string.Join("\r\n", lvis.Select(T => T.SubItems[1].Text + '\t' + T.Text).ToArray());
                fs = new FileStream(string.Format(bestandsnaam, EnumNaam), FileMode.Truncate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                writer.Write(result);
                writer.Close();
                fs.Close();
                Application.DoEvents();
                if(txtNaam.Text != EnumNaam)
                {
                    File.Move(string.Format(bestandsnaam, EnumNaam), string.Format(bestandsnaam, txtNaam.Text));
                }
            }
        }

        private void btnNieuwEnumMember_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            string enumnaam;
            double enumwaarde;
            EnumElementBewerken frm = new EnumElementBewerken();
            frm.ShowDialog("", 0, out enumnaam, out enumwaarde);
            lvi.Text = enumnaam;
            lvi.SubItems.Add(enumwaarde.ToString());
            listView1.Items.Add(lvi);
        }

        private void btnEnumMemberWissen_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
                listView1.Items.Remove(listView1.SelectedItems[0]);
        }
    }
}
