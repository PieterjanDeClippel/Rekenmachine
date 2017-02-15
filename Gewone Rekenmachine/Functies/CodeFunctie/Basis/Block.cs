using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gewone_Rekenmachine
{
    public class Block
    {
        private List<Variabele> availableVariables = new List<Variabele>();
        public List<Variabele> AvailableVariables
        {
            get { return availableVariables; }
        }

        private Block parent;
        public Block Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public void Parse(string input)
        {

        }
    }
}
