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
    public partial class NieuweFunctie : Form
    {
        public NieuweFunctie()
        {
            InitializeComponent();
        }

        public Functie.enFunctie_type GekozenSoort
        {
            get
            {
                if (rbnCode.Checked) return Functie.enFunctie_type.tekst;
                else return Functie.enFunctie_type.gui;
            }
            set
            {
                if (value == Functie.enFunctie_type.tekst) rbnCode.Checked = true;
                else rbnGui.Checked = true;
            }
        }
    }
}
