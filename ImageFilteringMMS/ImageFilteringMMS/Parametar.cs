using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFilteringMMS
{
    public partial class Parametar : Form
    {
        public int nValue { get; set; }
        public Parametar()
        {
            InitializeComponent();
        }
        public Parametar(int defaultValue)
        {
            InitializeComponent();
            this.textBoxValue.Value = defaultValue;
        }

        private void OK_clicked(object sender, EventArgs e)
        {
            this.nValue = Int32.Parse(this.textBoxValue.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
