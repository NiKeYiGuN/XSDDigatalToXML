using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XSDDigitalToXML
{
    public partial class ErrorReportForm : Form
    {
        private IList<string> errors = new List<string>();

        public IList<string> Errors { get { return this.errors; } set { this.errors = value; } }

        public ErrorReportForm()
        {
            InitializeComponent();
        }

        private void ErrorReportForm_Load(object sender, EventArgs e)
        {
            foreach (string s in this.errors)
                this.textBoxReport.Text += s + "\r\n";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
