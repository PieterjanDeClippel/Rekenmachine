using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Rekenmachine
{
    public class Matrix : Term
    {
        #region ctor
        public Matrix()
            : base(enTerm_type.Matrix)
        {

        }
        #endregion
        #region Items
        private List<List<Complex>> items = new List<List<Complex>>();
        public List<List<Complex>> Items
        {
            get { return items; }
        }
        #endregion
        #region Dimensie
        public Point Dimensie
        {
            get
            {
                if (items.Count == 0)
                    return new Point(0, 0);
                else
                    return new Point(items.Count, items[0].Count);
            }
            set
            {
                while(items.Count != value.X)
                {
                    if (items.Count < value.X)
                        items.Add(new List<Complex>());
                    else
                        items.RemoveAt(items.Count - 1);
                }
                foreach(List<Complex> rij in items)
                {
                    if (rij.Count < value.Y)
                        rij.Add(new Complex());
                    else
                        rij.RemoveAt(rij.Count - 1);
                }
            }
        }
        
        #endregion
        public static Matrix I(int b)
        {
            Matrix result = new Matrix();
            for (int i = 0; i < b; i++)
            {
                result.items.Add(new List<Complex>());
                for (int j = 0; j < b; j++)
                {
                    result.items.Last().Add(new Complex(Complex.bepaling.Real_Imag, i == j ? 1 : 0, 0));
                }
            }
            return result;
        }
        
        public Complex Determinant
        {
            get
            {
                if (Dimensie.X != Dimensie.Y)
                    throw new InvalidOperationException("Determinant kan enkel berekend worden bij vierkante matrices");
                else if (Dimensie.X == 2)
                {
                    return (Complex)(items[0][0] * items[1][1] - items[1][0] * items[0][1]);
                }
                else
                {
                    Term som = new Complex();
                    for (int i = 0; i < Dimensie.X; i++)
                        som += (items[i][0] * (Complex)Math.Pow(-1, i) * RestMatrix(i, 0).Determinant);
                    return (Complex)som;
                }
            }
        }

        private Matrix RestMatrix(int rij, int kolom)
        {
            Matrix result = new Matrix();
            result.Dimensie = new Point(this.Dimensie.X - 1, this.Dimensie.Y - 1);
            for (int i = 0; i < result.Dimensie.X; i++)
            {
                int r = i >= rij ? i + 1 : i;
                for (int j = 0; j < result.Dimensie.Y; j++)
                {
                    int k = j >= kolom ? j + 1 : j;
                    result.items[i][j] = this.items[r][k];
                }
            }
            return result;
        }
    }
}
