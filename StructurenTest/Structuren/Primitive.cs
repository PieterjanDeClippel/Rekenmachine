using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructurenTest
{
	public class Primitive : Structuur
	{
		private string tekst;
		public string Tekst
		{
			get { return tekst; }
			set { tekst = value; }
		}

		public override SizeF Size(Graphics gr,Font f)
		{
			if (tekst == "")
			{
				return new SizeF(25, 25);
			}
			else
			{
				return gr.MeasureString(tekst, f);
			}
		}
	}
}
