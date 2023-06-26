using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace GraphSharp
{
    public partial class StateForm : Form
    {

        private Dictionary<string, float> floats = new Dictionary<string, float>();
        public StateForm()
        {
            InitializeComponent();
        }

        public Dictionary<string, float> GetVariables()
        {
            return floats;
        }

        private void StateForm_Load(object sender, EventArgs e)
        {

        }

        public void RemoveFloat(string name)
        {
            if(floats.ContainsKey(name))
            {
                floats.Remove(name);
                ReloadFloatViews();
            }
        
        }

        private void ReloadFloatViews()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach(var variable in floats)
            {
                flowLayoutPanel1.Controls.Add(new FloatView(this, variable.Key, variable.Value));
            }
        }

        private void hopeButton3_Click(object sender, EventArgs e)
        {
            var resultClass = new InputForm("Enter the floats name.", "Enter the name of the variable for the new float.\nThis bit is used for code generation so you basically enter this value here:\nfloat {->this<-} = {Next Prompt};", "Foo");
            var result = resultClass.ShowDialog();
            if (result == DialogResult.OK)
            {
                string variableName = resultClass.GetValue();
                var resultClass2 = new InputForm("Enter the floats value.", "Enter the value of the new float.\nThis bit is also used for code generation so you basically enter this value here:\nfloat {Previous Prompt} = {->this<-};", "0.1 <- Use This format!");
                var result2 = resultClass2.ShowDialog();
                if(result2 == DialogResult.OK)
                {
                   
                    float variableValue = float.Parse(resultClass2.GetValue(), CultureInfo.InvariantCulture.NumberFormat);
                    floats.Add(variableName, variableValue);
                    ReloadFloatViews();
                }
                else if(result2 == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
            else if(result == DialogResult.Cancel)
            {
                this.Close();
            }
            
        }
    }
}
