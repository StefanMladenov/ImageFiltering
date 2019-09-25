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
    public partial class ColorInput : Form
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public ColorInput()
        {
            InitializeComponent();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RedColor.Text) ||
                String.IsNullOrEmpty(GreenColor.Text) ||
                String.IsNullOrEmpty(BlueColor.Text))
            {
                MessageBox.Show("Vrednosti nisu validne!");
                return;
            }

            this.Red = Int32.Parse(this.RedColor.Text);
            this.Blue = Int32.Parse(this.BlueColor.Text);
            this.Green = Int32.Parse(this.GreenColor.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
