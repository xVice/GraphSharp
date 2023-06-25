using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphSharp
{
    public class PlotViewJsonRep
    {
        public string expression { get; set; }
        public Color color { get; set; }
        public PlotViewJsonRep(string expression, Color color)
        {
            this.expression = expression;
            this.color = color;
        }
    }


    public partial class PlotView : UserControl
    {
        public string expression { get; set; }
        public Color color { get; set; }

        private Form1 mainForm;

        [JsonConstructor]
        public PlotView(string expression, Color color)
        {
            this.expression = expression;
            this.color = color;

            InitializeComponent();
        }

        public PlotView(Form1 mainForm, string expression, Color color)
        {
            this.mainForm = mainForm;
            this.expression = expression;
            this.color = color;
           
            InitializeComponent();
        }

        public void SetMainForm(Form1 mainForm)
        {
            this.mainForm = mainForm;
        }

        public string GetExpression()
        {
            return expression;
        }

        public Pen GetPen()
        {
            return new Pen(color);   
        }

        private void PlotView_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = expression;
            panel1.BackColor = color;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = color;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Update the selected color
                color = colorDialog.Color;
                panel1.BackColor = color;
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            mainForm.RemoveExpView(this);
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
     
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            expression = richTextBox1.Text;
        }
    }
}
