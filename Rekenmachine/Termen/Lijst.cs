using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rekenmachine
{
    public class Lijst : Term
    {
        #region ctor
        public Lijst()
            : base(enTerm_type.Lijst)
        {

        }
        #endregion
        #region Items
        private List<Complex> items = new List<Complex>();
        public List<Complex> Items
        {
            get { return items; }
        }
        #endregion
    }
}
