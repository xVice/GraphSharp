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



    public partial class PlotView : UserControl
    {
  

        public string expression { get; set; }
        public Color color { get; set; }

        private List<string> usingDirectives = new List<string>();

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

        public string[] GetUsingDirectives()
        {
            return usingDirectives.ToArray();
        }

        public Pen GetPen()
        {
            return new Pen(color);   
        }

        private void PlotView_Load(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = expression;
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


        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
           
        }

        private void fastColoredTextBox1_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            expression = fastColoredTextBox1.Text;
        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            string use = Microsoft.VisualBasic.Interaction.InputBox("Add or delete a using directive for this node, enter the name of the directive e.x: System.Drawing", "Add/Delete Using Directives", "System.Drawing");
            if (usingDirectives.Contains(use))
            {
                usingDirectives.Remove(use);
            }
            else
            {
                usingDirectives.Add(use);
            }
        }
    }
}
