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
    public partial class EnumElementBewerken : Form
    {
        public EnumElementBewerken()
        {
            InitializeComponent();
        }

        public void ShowDialog(string naam, double waarde, out string nieuwenaam, out double nieuwewaarde)
        {
            txtNaam.Text = naam;
            txtWaarde.Text = waarde.ToString();
            if(this.ShowDialog() == DialogResult.OK)
            {
                nieuwenaam = txtNaam.Text;
                nieuwewaarde = Convert.ToDouble(txtWaarde.Text);
            }
            else
            {
                nieuwenaam = naam;
                nieuwewaarde = waarde;
            }
        }
    }
}
