using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gewone_Rekenmachine
{
    public partial class TussendoorBerekening : Form
    {
        public TussendoorBerekening()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(Tmp_Param param_in, List<string> hoofdparams, out Tmp_Param param_out)
        {
            txtNaam.Text = param_in.Naam;
            txtBeschrijving.Text = param_in.Beschrijving;
            txtBerekening.Text = param_in.Berekening;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(hoofdparams.ToArray());
            DialogResult dr = this.ShowDialog();
            if(dr == DialogResult.OK)
            {
                param_out = new Tmp_Param();
                param_out.Berekening = txtBerekening.Text;
                param_out.Beschrijving = txtBeschrijving.Text;
                param_out.Naam = txtNaam.Text;
            }
            else
            {
                param_out = param_in;
            }
            return dr;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            int start = txtBerekening.SelectionStart;
            if (index != -1)
            {
                txtBerekening.Text = txtBerekening.Text.Insert(txtBerekening.SelectionStart, listBox1.Items[index].ToString());
                txtBerekening.SelectionStart = start + listBox1.Items[index].ToString().Length;
                txtBerekening.SelectionLength = 0;
            }
            txtBerekening.Focus();
        }

        private void btnNegatief_Click(object sender, EventArgs e)
        {
            int index = txtBerekening.SelectionStart;
            int lengte = txtBerekening.SelectionLength;

            string txt =
                txtBerekening.Text.Substring(0, index) +
                "–" +
                txtBerekening.Text.Substring(index + lengte);
            txtBerekening.Text = txt;
            txtBerekening.SelectionStart = index + 1;
            txtBerekening.SelectionLength = 0;
        }

        private void btnWortel_Click(object sender, EventArgs e)
        {
            int index = txtBerekening.SelectionStart;
            int lengte = txtBerekening.SelectionLength;

            string txt =
                txtBerekening.Text.Substring(0, index) +
                "√" +
                txtBerekening.Text.Substring(index + lengte);
            txtBerekening.Text = txt;
            txtBerekening.SelectionStart = index + 1;
            txtBerekening.SelectionLength = 0;
        }
    }
}
