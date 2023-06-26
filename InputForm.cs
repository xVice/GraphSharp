using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphSharp
{
    public partial class InputForm : Form
    {
        public string value;

        public InputForm(string title, string description, string defaultValue = "")
        {
            InitializeComponent();
            label1.Text = title;
            label2.Text = description;
            if(defaultValue != "")
            {
                hopeTextBox1.Text = defaultValue;
            }
            else
            {
                hopeTextBox1.Text = "";
            }

        }

        public dynamic GetValue()
        {
            return value;

        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {
            if(hopeTextBox1.Text != "" || hopeTextBox1.Text != string.Empty)
            {
                value = hopeTextBox1.Text;
                
                DialogResult = DialogResult.OK;
            }
            else
            {
                hopeTextBox1.BorderColorA = Color.Red;
                hopeTextBox1.BorderColorB = Color.Red;
            }
        }

        private void hopeButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
