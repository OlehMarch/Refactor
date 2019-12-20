using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pp_lr_1
{
    public partial class ExtractMethodForm : Form
    {
        public ExtractMethodForm()
        {
            InitializeComponent();
        }

        private void B_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void B_Confirm_Click(object sender, EventArgs e)
        {
            if (TB_MethodName.Text.Length >= 5)
            {
                StreamWriter sw_file = new StreamWriter("temp");
                sw_file.Write(TB_MethodName.Text);
                sw_file.Close();

                Close();
            }
            else
            {
                MessageBox.Show("Method name must be not less then 5 characters!", "Warning!", MessageBoxButtons.OK);
            }
        }
    }
}
