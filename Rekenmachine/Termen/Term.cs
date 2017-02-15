using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rekenmachine
{
    public class Term
    {
        #region ctor
        public Term(enTerm_type type)
        {
            term_type = type;
        }
        #endregion
        #region Term_type
        public enum enTerm_type
        {
            Complex,
            Lijst,
            Matrix
        }
        private enTerm_type term_type;
        public enTerm_type Term_Type
        {
            get { return term_type; }
        }
        #endregion
        #region Operators
        #region +
        public static Term operator +(Term term1, Term term2)
        {
            switch (term1.term_type)
            {
                case enTerm_type.Complex:
                    Complex cpx1 = (Complex)term1;
                    switch (term2.term_type)
                    {
                        case enTerm_type.Complex:
                            Complex cpx2 = (Complex)term2;
                            return new Complex(Complex.bepaling.Real_Imag, cpx1.Real + cpx2.Real, cpx1.Imaginary + cpx2.Imaginary);
                        case enTerm_type.Lijst:
                            Lijst lst2 = (Lijst)term2;
                            Lijst result = new Lijst();
                            result.Items.AddRange(lst2.Items.Select(T => (Complex)(term1 + T)));
                            return result;
                        case enTerm_type.Matrix:
                            Matrix mtr2 = (Matrix)term2;
                            Matrix result2 = new Matrix();
                            result2.Items.AddRange(mtr2.Items.Select(T => T.Select(U => (Complex)(U + term1)).ToList()).ToArray());
                            return result2;
                    }
                    break;
                case enTerm_type.Lijst:
                    Lijst lst1 = (Lijst)term1;
                    switch (term2.term_type)
                    {
                        case enTerm_type.Complex:
                            Complex cpx2 = (Complex)term2;
                            Lijst result = new Lijst();
                            result.Items.AddRange(lst1.Items.Select(T => new Complex(Complex.bepaling.Real_Imag, cpx2.Real + T.Real, cpx2.Imaginary + T.Imaginary)));
                            return result;
                        case enTerm_type.Lijst:
                            Lijst lst2 = (Lijst)term2;
                            if (lst1.Items.Count != lst2.Items.Count)
                                throw new Exception("Lijst + Lijst: De lijsten zijn niet even lang");
                            Lijst result3 = new Lijst();
                            for (int i = 0; i < result3.Items.Count; i++)
                                result3.Items.Add((Complex)(lst1.Items[i] + lst2.Items[i]));
                            return result3;
                        case enTerm_type.Matrix:
                            throw new Exception("Lijst + Matrix: Kan lijst en matrix niet optellen");
                        default:
                            throw new Exception("Type van term2 niet gekend");
                    }
                case enTerm_type.Matrix:
                    Matrix mtr1 = (Matrix)term1;
                    switch (term2.term_type)
                    {
                        case enTerm_type.Complex:
                            return term2 + term1;
                        case enTerm_type.Lijst:
                            throw new Exception("Matrix + Lijst: Kan matrix en lijst niet optellen");
                        case enTerm_type.Matrix:
                            Matrix mtr2 = (Matrix)term2;
                            if (mtr1.Dimensie != mtr2.Dimensie)
                                throw new Exception("Matrix + Matrix: De dimensies zijn niet gelijk");
                            Matrix result = new Matrix();
                            for (int i = 0; i < mtr1.Dimensie.X; i++)
                            {
                                result.Items.Add(new List<Complex>());
                                for (int j = 0; j < mtr1.Dimensie.Y; j++)
                                    result.Items[i].Add((Complex)(mtr1.Items[i][j] + mtr2.Items[i][j]));
                            }
                            return result;
                        default:
                            throw new Exception("Type van term2 niet gekend");
                    }
                default:
                    throw new Exception("Type van term1 niet gekend");
            }
            return null;
        }
        #endregion
        #region -
        public static Term operator -(Term term1)
        {
            switch (term1.term_type)
            {
                case enTerm_type.Complex:
                    Complex cpx = (Complex)term1;
                    return new Complex(Complex.bepaling.Real_Imag, -cpx.Real, -cpx.Imaginary);
                case enTerm_type.Lijst:
                    Lijst lst = (Lijst)term1;
                    Lijst result = new Lijst();
                    result.Items.AddRange(lst.Items.Select(T => (Complex)(-T)));
                    return result;
                case enTerm_type.Matrix:
                    Matrix mtr = (Matrix)term1;
                    Matrix result2 = new Matrix();
                    result2.Items.AddRange(mtr.Items.Select(T => T.Select(U => (Complex)(-U)).ToList()));
                    return result2;
                default:
                    throw new Exception("Type van term1 niet gekend");
            }
        }
        #endregion
        #region -
        public static Term operator -(Term term1, Term term2)
        {
            return (term1 + -term2);
        }
        #endregion
        #region *
        public static Term operator *(Term term1, Term term2)
        {
            switch (term1.term_type)
            {
                case enTerm_type.Complex:
                    Complex cpx1 = (Complex)term1;
                    switch (term2.term_type)
                    {
                        case enTerm_type.Complex:
                            Complex cpx2 = (Complex)term2;
                            return new Complex(Complex.bepaling.Modul_Arg, cpx1.Modulus * cpx2.Modulus, cpx1.Argument + cpx2.Argument);
                        case enTerm_type.Lijst:
                            Lijst lst2 = (Lijst)term2;
                            Lijst result = new Lijst();
                            result.Items.AddRange(lst2.Items.Select(T => (Complex)(cpx1 * T)));
                            return result;
                        case enTerm_type.Matrix:
                            Matrix mtr2 = (Matrix)term2;
                            Matrix result2 = new Matrix();
                            result2.Items.AddRange(mtr2.Items.Select(T => T.Select(U => (Complex)(U * term1)).ToList()));
                            return result2;
                        default:
                            throw new Exception("Type van term2 niet gekend");
                    }
                case enTerm_type.Lijst:
                    Lijst lst1 = (Lijst)term1;
                    switch (term2.term_type)
                    {
                        case enTerm_type.Complex:
                            Complex cpx2 = (Complex)term2;
                            Lijst result = new Lijst();
                            result.Items.AddRange(lst1.Items.Select(T => (Complex)(cpx2 * T)));
                            return result;
                        case enTerm_type.Lijst:
                            Lijst lst2 = (Lijst)term2;
                            if (lst1.Items.Count != lst2.Items.Count)
                                throw new Exception("Lijst * Lijst: De lijsten zijn niet even lang");
                            Lijst result2 = new Lijst();
                            for (int i = 0; i < lst1.Items.Count; i++)
                                result2.Items.Add((Complex)(lst1.Items[i] * lst2.Items[i]));
                            return result2;
                        case enTerm_type.Matrix:
                            throw new Exception("Lijst * Matrix: Kan lijst en matrix niet vermenigvuldigen");
                        default:
                            throw new Exception("Type van term2 niet gekend");

                    }
                case enTerm_type.Matrix:
                    break;
            }
            return null;
        }
        public static Term operator *(Matrix term1, Complex term2)
        {
            return term2 * term1;
        }
        public static Lijst operator *(Matrix term1, Lijst term2)
        {
            throw new Exception("Matrix * Lijst: Kan matrix en lijst niet vermenigvuldigen");
        }
        public static Matrix operator *(Matrix term1, Matrix term2)
        {
            if (term1.Dimensie.Y != term2.Dimensie.X)
                throw new Exception("Matrix * Matrix: De dimensies zijn niet geschikt");
            Matrix result = new Matrix();
            for (int i = 0; i < term1.Dimensie.X; i++)
            {
                result.Items.Add(new List<Complex>());
                for (int j = 0; j < term2.Dimensie.Y; j++)
                {
                    Complex som = new Complex(Complex.bepaling.Real_Imag, 0, 0);
                    //for (int p = 0; p < term1.Dimensie.Y; p++)
                    //    som += term1.Items[i][p] * term2.Items[p][j];
                    result.Items.Last().Add(som);
                }
            }
            return result;
        }
        #endregion
        #region /
        public static Complex operator /(Complex term1, Complex term2)
        {
            Complex toeg = new Complex(Complex.bepaling.Real_Imag, term2.Real, -term2.Imaginary);
            //Complex teller = term1 * toeg;
            //Complex noemer = term2 * toeg;
            //return new Complex(Complex.bepaling.Real_Imag, teller.Real / noemer.Real, teller.Imaginary / noemer.Real);
            return null;
        }
        public static Lijst operator /(Complex term1, Lijst term2)
        {
            Lijst result = new Lijst();
            result.Items.AddRange(term2.Items.Select(T => term1 / T));
            return result;
        }
        public static Matrix operator /(Complex term1, Matrix term2)
        {
            throw new Exception("Complex / Matrix: Kan complex en matrix niet delen");
        }
        public static Lijst operator /(Lijst term1, Complex term2)
        {
            Lijst result = new Lijst();
            result.Items.AddRange(term1.Items.Select(T => T / term2));
            return result;
        }
        public static Lijst operator /(Lijst term1, Lijst term2)
        {
            if (term1.Items.Count != term2.Items.Count)
                throw new Exception("Lijst / Lijst: De dimensies zijn niet gelijk");
            Lijst result = new Lijst();
            //for (int i = 0; i < term1.Items.Count; i++)
            //    result.Items.Add(term1.Items[i] + term2.Items[i]);
            return result;
        }
        public static Lijst operator /(Lijst term1, Matrix term2)
        {
            throw new Exception("Lijst / Matrix: Kan lijst en matrix niet delen");
        }
        public static Matrix operator /(Matrix term1, Complex term2)
        {
            Matrix result = new Matrix();
            for (int i = 0; i < term1.Dimensie.X; i++)
            {
                result.Items.Add(new List<Complex>());
                for (int j = 0; j < term1.Dimensie.Y; j++)
                    result.Items[0].Add(term1.Items[i][j] / term2);
            }
            return result;
        }
        public static Lijst operator /(Matrix term1, Lijst term2)
        {
            throw new Exception("Matrix / Lijst: Kan matrix en lijst niet delen");
        }
        public static Lijst operator /(Matrix term1, Matrix term2)
        {
            throw new Exception("Matrix / Matrix: Kan matrix en matrix niet delen");
        }
        #endregion
        #region %
        /*public static Complex operator %(Complex term1, Complex term2)
        {

        }
        public static Lijst operator %(Complex term1, Lijst term2)
        {

        }
        public static Matrix operator %(Complex term1, Matrix term2)
        {

        }
        public static Lijst operator %(Lijst term1, Complex term2)
        {

        }
        public static Lijst operator %(Lijst term1, Lijst term2)
        {

        }
        public static Lijst operator %(Lijst term1, Matrix term2)
        {

        }
        public static Lijst operator %(Matrix term1, Complex term2)
        {

        }
        public static Lijst operator %(Matrix term1, Lijst term2)
        {

        }
        public static Lijst operator %(Matrix term1, Matrix term2)
        {

        }*/
        #endregion
        #region ^
        public static Complex operator ^(Complex term1, Complex term2)
        {
            //http://www.abecedarical.com/zenosamples/zs_complexnumbers.html
            double T = Math.Pow(term1.Modulus, term2.Real) * Math.Exp(-term1.Argument * term2.Imaginary);
            double re = T * Math.Cos(term2.Real * term1.Argument + term2.Imaginary * Math.Log(term1.Modulus));
            double im = T * Math.Sin(term2.Real * term1.Argument + term2.Imaginary * Math.Log(term1.Modulus));
            return new Complex(Complex.bepaling.Real_Imag, re, im);
        }
        public static Lijst operator ^(Complex term1, Lijst term2)
        {
            Lijst result = new Lijst();
            result.Items.AddRange(term2.Items.Select(T => term1 ^ T));
            return result;
        }
        public static Matrix operator ^(Complex term1, Matrix term2)
        {
            throw new Exception("Complex ^ Matrix: Kan complex en matrix niet verheffen");
        }
        public static Lijst operator ^(Lijst term1, Complex term2)
        {
            Lijst result = new Lijst();
            result.Items.AddRange(term1.Items.Select(T => term2 ^ T));
            return result;
        }
        public static Lijst operator ^(Lijst term1, Lijst term2)
        {
            if (term1.Items.Count != term2.Items.Count)
                throw new Exception("Lijst ^ Lijst: De lijsten zijn niet even lang");
            Lijst result = new Lijst();
            for (int i = 0; i < term1.Items.Count; i++)
                result.Items.Add(term1.Items[i] ^ term2.Items[i]);
            return result;
        }
        public static Lijst operator ^(Lijst term1, Matrix term2)
        {
            throw new Exception("Lijst ^ Matrix: Kan lijst en matrix niet verheffen");
        }
        public static Matrix operator ^(Matrix term1, Complex term2)
        {
            if (term2.Imaginary != 0)
                throw new Exception("Matrix ^ Complex: Exponent moet een geheel getal zijn");
            if (term2.Real % 1 != 0)
                throw new Exception("Matrix ^ Complex: Exponent moet een geheel getal zijn");
            if (term1.Dimensie.X != term1.Dimensie.Y)
                throw new Exception("Matrix ^ Complex: Matrix moet vierkant zijn");
            Matrix result = Matrix.I(term1.Dimensie.X);
            for (int i = 0; i < Convert.ToInt16(term2.Real); i++)
                result *= term1;
            return result;
        }
        public static Lijst operator ^(Matrix term1, Lijst term2)
        {
            throw new Exception("Matrix ^ Lijst: Kan matrix en lijst niet verheffen");
        }
        public static Lijst operator ^(Matrix term1, Matrix term2)
        {
            throw new Exception("Matrix ^ Matrix: Kan matrix en matrix niet verheffen");
        }
        #endregion
        #endregion
        #region Functies
        public static Complex ln(Complex term)
        {
            return new Complex(Complex.bepaling.Real_Imag, Math.Log(term.Modulus), term.Argument);
        }
        #endregion
    }
}
