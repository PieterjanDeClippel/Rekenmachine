using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gewone_Rekenmachine
{
    public class GrafischeFunctie : Functie
    {
        #region ctor
        public GrafischeFunctie()
            : base(enFunctie_type.gui)
        {
        }
        #endregion
        #region Naam
        private string naam;
        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }
        #endregion
        #region Beschrijving
        private string beschrijving;
        public string Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }
        #endregion
        #region Voorschrift
        private string voorschrift;
        public string Voorschrift
        {
            get { return voorschrift; }
            set { voorschrift = value; }
        }
        #endregion
        #region Parameters
        private List<Parameter> parameters = new List<Parameter>();
        public List<Parameter> Parameters
        {
            get { return parameters; }
        }
        #endregion
        #region Temp_param
        private List<Tmp_Param> temp = new List<Tmp_Param>();
        public List<Tmp_Param> Temp
        {
            get { return temp; }
        }
        #endregion
    }
}
