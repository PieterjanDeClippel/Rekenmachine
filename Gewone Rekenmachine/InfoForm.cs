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
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
            this.Resize += InfoForm_Resize;
            this.Paint += InfoForm_Paint;
            this.DoubleBuffered = true;
        }

        private void InfoForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            Font norm = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Regular);
            Font bold = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);

            SizeF funcNaamSize = gr.MeasureString(functienaam + ": ", bold);
            SizeF funcDescSize = gr.MeasureString(functieBeschrijving, norm);
            SizeF paramNaamSize = gr.MeasureString(paramNaam + ": ", bold);
            SizeF paramDescSize = gr.MeasureString(paramBeschrijving, norm);

            this.Size = new Size((int)Math.Max(funcNaamSize.Width + funcDescSize.Width + 2, paramNaamSize.Width + paramDescSize.Width) + 4, (int)(funcNaamSize.Height + paramNaamSize.Height + 4));
            gr.Clear(SystemColors.Info);

            Rectangle rct = new Rectangle(0, 0, Width - 1, Height - 1);
            gr.DrawRectangle(Pens.Black, rct);
            
            Brush br = new SolidBrush(this.ForeColor);
            gr.DrawString(functienaam + ": ", bold, new SolidBrush(this.ForeColor), 2, 2);
            gr.DrawString(functieBeschrijving, norm, br, funcNaamSize.Width + 2, 2);
            gr.DrawString(ParamNaam + ": ", bold, new SolidBrush(this.ForeColor), 2, funcNaamSize.Height + 2);
            gr.DrawString(paramBeschrijving, norm, new SolidBrush(this.ForeColor), paramNaamSize.Width + 2, funcNaamSize.Height + 2);
        }

        private void InfoForm_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        #region FunctieNaam
        private string functienaam;
        public string FunctieNaam
        {
            get { return functienaam; }
            set
            {
                functienaam = value;
                this.Invalidate();
            }
        }
        #endregion
        #region FunctieBeschrijving
        private string functieBeschrijving;
        public string FunctieBeschrijving
        {
            get { return functieBeschrijving; }
            set
            {
                functieBeschrijving = value;
                this.Invalidate();
            }
        }
        #endregion
        #region ParamNaam
        private string paramNaam;
        public string ParamNaam
        {
            get { return paramNaam; }
            set
            {
                paramNaam = value;
                this.Invalidate();
            }
        }
        #endregion
        #region FunctieBeschrijving
        private string paramBeschrijving;
        public string ParamBeschrijving
        {
            get { return paramBeschrijving; }
            set
            {
                paramBeschrijving = value;
                this.Invalidate();
            }
        }
        #endregion

        private void InfoForm_MouseHover(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void InfoForm_MouseLeave(object sender, EventArgs e)
        {
            Opacity = 0.5;
        }

		private void InfoForm_Activated(object sender, EventArgs e)
		{
			Application.OpenForms[0].Activate();
		}
	}
}
