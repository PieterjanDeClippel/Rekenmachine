using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rekenmachine
{
    public class Complex : Term
    {
        #region ctor
        public Complex(bepaling bep, double arg1, double arg2)
            : base(enTerm_type.Complex)
        {
            if(bep == bepaling.Modul_Arg)
            {
                real = arg1 * Math.Cos(arg2);
                imag = arg1 * Math.Sin(arg2);
            }
            else
            {
                real = arg1;
                imag = arg2;
            }
        }

        public Complex()
        {
        }

        public enum bepaling
        {
            Real_Imag,
            Modul_Arg
        }
        #endregion
        #region Reeel
        private double real;
        public double Real
        {
            get { return real; }
        }
        #endregion
        #region Imaginary
        private double imag;
        public double Imaginary
        {
            get { return imag; }
        }
        #endregion
        #region Modulus
        public double Modulus
        {
            get { return Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imag, 2)); }
        }
        #endregion
        #region Argument
        public double Argument
        {
            get { return Math.Atan2(imag, real); }
        }
        #endregion
        public static explicit operator Complex (double d)
        {
            return new Complex(bepaling.Real_Imag, d, 0);
        }
    }
}
