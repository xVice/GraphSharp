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
    public partial class FloatView : UserControl
    {
        private string variableName;
        private float variableValue;

        private StateForm state;

        public FloatView(StateForm state, string variableName, float variableValue)
        {
            this.state = state;
            this.variableName = variableName;
            this.variableValue = variableValue;
            InitializeComponent();
        }

        private void FloatView_Load(object sender, EventArgs e)
        {
            label1.Text = $"{variableName}:{variableValue}";
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            state.RemoveFloat(variableName);
        }
    }
}
