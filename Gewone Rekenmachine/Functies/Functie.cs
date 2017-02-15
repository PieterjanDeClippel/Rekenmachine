using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gewone_Rekenmachine
{
    public class Functie
    {
        #region ctor
        public Functie(enFunctie_type Functie_Type)
        {
            functie_type = Functie_Type;
        }
        #endregion
        #region Functie_type
        public enum enFunctie_type
        {
            gui,
            tekst
        }
        private enFunctie_type functie_type;
        public enFunctie_type Functie_Type
        {
            get { return functie_type; }
        }
        #endregion
    }
}
