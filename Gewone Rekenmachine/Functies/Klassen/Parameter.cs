using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gewone_Rekenmachine
{
    public class Parameter
    {
        #region Naam
        private string naam;
        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }
        #endregion
        #region Is_Getal
        private bool is_getal = true;
        public bool Is_Getal
        {
            get { return is_getal; }
            set { is_getal = value; }
        }
        #endregion
        #region EnumNaam
        private string enumnaam;
        public string EnumNaam
        {
            get { return enumnaam; }
            set { enumnaam = value; }
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
        #region Optioneel
        private bool optioneel;
        public bool Optioneel
        {
            get { return optioneel; }
            set { optioneel = value; }
        }
        #endregion
        #region StandaardWaarde
        private double standaardwaarde;
        public double StandaardWaarde
        {
            get { return standaardwaarde; }
            set { standaardwaarde = value; }
        }
        #endregion
    }
}