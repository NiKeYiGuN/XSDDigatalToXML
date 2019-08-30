using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XSDDigitalToXML
{
    public partial class DiagramControl : UserControl
    {       
        public DiagramControl()
        {
            InitializeComponent();

            this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Home:
                case Keys.End:
                case Keys.Delete:
                    return true;
                case Keys.Shift | Keys.Right:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                case Keys.Shift | Keys.PageDown:
                case Keys.Shift | Keys.PageUp:
                case Keys.Shift | Keys.Home:
                case Keys.Shift | Keys.End:
                case Keys.Shift | Keys.Delete:
                    return true;
            }
            return base.IsInputKey(keyData);
        }

        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == WM_SETFOCUS)
            //	return;
            base.WndProc(ref m);
        }
    }
}
