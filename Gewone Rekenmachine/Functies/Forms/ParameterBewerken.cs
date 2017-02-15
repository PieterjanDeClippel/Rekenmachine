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
    public partial class ParameterBewerken : Form
    {
        public ParameterBewerken()
        {
            InitializeComponent();
        }

        public List<Enum> EnumList;

        public DialogResult ShowDialog(Parameter param, out Parameter result)
        {
            txtParamNaam.Text = param.Naam;
            if (param.Is_Getal)
                rbnTypeGetal.Checked = true;
            else
                rbnTypeEnum.Checked = true;

            Enums.Items.Clear();
            string enummap = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Rekenmachine/Enums/";
            foreach(string bestand in Directory.GetFiles(enummap))
                if(Path.GetExtension(bestand) == ".enum")
                    Enums.Items.Add(Path.GetFileNameWithoutExtension(bestand));

            Enums.SelectedItem = param.EnumNaam;
            txtBeschrijving.Text = param.Beschrijving;
            chkOptioneel.Checked = param.Optioneel;

            txtStandaardWaarde.Text = param.StandaardWaarde.ToString();

            DialogResult dr = this.ShowDialog();
            if(dr == DialogResult.OK)
            {
                result = new Parameter();
                result.Naam = txtParamNaam.Text;
                result.Is_Getal = rbnTypeGetal.Checked;
                result.EnumNaam = Enums.SelectedItem == null ? "" : Enums.SelectedItem.ToString();
                result.Beschrijving = txtBeschrijving.Text;
                result.Optioneel = chkOptioneel.Checked;
                result.StandaardWaarde = Convert.ToDouble(txtStandaardWaarde.Text);
            }
            else
            {
                result = param;
            }
            return dr;
        }
        
        int zoek_enum_index(string en, double waarde)
        {
            string EnumBestand = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Rekenmachine\Enums\{0}.enum", en);
            FileStream fs = new FileStream(EnumBestand, FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            string tekst = reader.ReadToEnd();
            reader.Close();
            fs.Close();

            double[] waarden = tekst.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(T => Convert.ToDouble(T.Split('\t')[1])).ToArray();
            return Array.IndexOf<double>(waarden, waarde);
        }

        private void chkOptioneel_CheckedChanged(object sender, EventArgs e)
        {
            txtStandaardWaarde.Enabled = chkOptioneel.Checked;
            label4.Enabled = chkOptioneel.Checked;
        }

        private void rbnTypeGetal_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = rbnTypeEnum.Checked;
        }
        
        private void btnEnumBewerken_Click(object sender, EventArgs e)
        {
            EnumBewerken dlg = new EnumBewerken();
            dlg.ShowDialog(Enums.SelectedItem.ToString());
        }

        private void Enums_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool b = Enums.SelectedIndex != -1;
            btnEnumBewerken.Enabled = b;
            btnEnumWissen.Enabled = b;
        }

        private void btnNieuweEnum_Click(object sender, EventArgs e)
        {

        }
    }
}
