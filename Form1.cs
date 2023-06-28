using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Linq.Expressions;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using System.IO;

namespace GraphSharp
{
    public partial class Form1 : Form
    {
        private float Scale = 40f;
        private Bitmap bitmap;
        private Graphics graphics;
        private int Width, Height;
        private bool isDragging = false;
        private Point mouseDownLocation;
        private float offsetX = 0;
        private float offsetY = 0;

        private StateForm stateForm;
        private Size oldSize = new Size();

        public Form1()
        {

            Width = 1183; Height = 833;
            bitmap = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Text = "Grapsharp";
            ClientSize = new Size(Width, Height);
            DoubleBuffered = true;
            
            

            InitializeComponent();

        }

        private void PlotFunction(Func<(float, float), (float, float)> function, Pen pen)
        {
            try
            {
                for (float t = -graphArea.Width / 2; t < graphArea.Width / 2; t += 1f / Scale)
                {
                    if (function != null)
                    {
                        var input = (t / Scale, -t / Scale);
                        var output = function(input);
                        float x = output.Item1 * Scale - offsetX;
                        float y = output.Item2 * Scale - offsetY;
                        graphics.FillRectangle(pen.Brush, graphArea.Width / 2 + x, graphArea.Height / 2 - y, 1, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Plot error..");
            }
        }



        private void graphArea_Paint(object sender, PaintEventArgs e)
        {
         
           
            
  
        }

        private bool ShouldTick = false;

        private void DrawAxes()
        {
            // Set up the axis line colors and font for labels
            Pen axisLinePen = Pens.White;
            Brush labelBrush = Brushes.White;
            Font labelFont = new Font("Arial", 10);

            // Calculate the maximum value for x-axis and y-axis based on the graph area and scale
            float maxXValue = graphArea.Width / Scale;
            float maxYValue = graphArea.Height / Scale;

            // Calculate the position of the origin (0, 0) within the graph area
            float originX = graphArea.Width / 2 + offsetX;
            float originY = graphArea.Height / 2 + offsetY;

            // Draw the x-axis
            graphics.DrawLine(axisLinePen, 0, originY, graphArea.Right, originY);
            for (float x = -maxXValue; x <= maxXValue; x += maxXValue / Scale)
            {
                float xPos = originX + x * Scale;
                if (xPos >= 0 && xPos <= graphArea.Width)
                {
                    graphics.DrawLine(axisLinePen, xPos, originY - 5, xPos, originY + 5);
                    string xLabel = x.ToString("0.000");
                    if (xLabel != "0.000" && ShouldTick)
                    {
                        graphics.DrawString(xLabel, labelFont, labelBrush, xPos - 10, originY + 10);
                    }
                }
            }

            // Draw the y-axis
            graphics.DrawLine(axisLinePen, originX, graphArea.Top, originX, graphArea.Bottom);
            for (float y = -maxYValue; y <= maxYValue; y += maxYValue / Scale)
            {
                float yPos = originY - y * Scale;
                if (yPos >= graphArea.Top && yPos <= graphArea.Bottom)
                {
                    graphics.DrawLine(axisLinePen, originX - 5, yPos, originX + 5, yPos);
                    string yLabel = y.ToString("0.000");
                    if (yLabel != "0.000" && ShouldTick)
                    {
                        graphics.DrawString(yLabel, labelFont, labelBrush, originX + 10, yPos - 10);
                    }
                }
            }
        }










        private void Redraw()
        {
            graphics.Clear(Color.FromArgb(20, 20, 20));
            DrawAxes();

            var views = flowLayoutPanel1.Controls.OfType<PlotView>().ToArray();

            if (views.Length != 0)
            {
                foreach (var view in views)
                {
                    PlotFunction(RunExpression(view.GetExpression(), view.GetUsingDirectives()), view.GetPen());
                }
            }

            graphArea.Image = bitmap;
            graphArea.Refresh();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            stateForm = new StateForm();
            graphArea.MouseWheel += new MouseEventHandler(Scroll);
            Redraw();
        }

        void Scroll(object sender, MouseEventArgs e)
        {
            Scale *= e.Delta > 0 ? 1.1f : 0.9f;
            Redraw();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
         
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
  
          
        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {
            Redraw();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (oldSize == ClientSize)
                return;

            bitmap = new Bitmap(graphArea.Width, graphArea.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Redraw();
        }

        public void RemoveExpView(PlotView view)
        {
            flowLayoutPanel1.Controls.Remove(view);
            Redraw();

        }

        private void hopeButton2_Click(object sender, EventArgs e)
        {
            //RunExpression();
            var selectedColor = Color.White;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Update the selected color
                selectedColor = colorDialog.Color;
            }
            flowLayoutPanel1.Controls.Add(new PlotView(this, hopeRichTextBox1.Text, selectedColor));


            Redraw();
        }

        private string GenerateUsingDirectiveCode(string[] directives)
        {
            StringBuilder directivessb = new StringBuilder();
            foreach (var directive in directives)
            {
                directivessb.AppendLine($"using {directive};");
            }
            return directivessb.ToString();
        }
        private float Foo = 0.1f;

        private string GenerateVariableCode(Dictionary<string, float> variables)
        {
            StringBuilder declarations = new StringBuilder();
            foreach (var variable in variables)
            {
                declarations.AppendLine($"private static float {variable.Key} = {variable.Value.ToString().Replace(",",".")}f;");
            }
            return declarations.ToString();
        }

        private Func<(float, float), (float, float)> RunExpression(string functionExpression, string[] usingDirectives)
        {
            if (!functionExpression.Contains(Environment.NewLine))
            {
                string code = $@"using System;
                         {GenerateUsingDirectiveCode(usingDirectives)}
                         
                         public class DynamicClass
                         {{
                              {GenerateVariableCode(stateForm.GetVariables())}
                              public static (float, float) DynamicMethod((float, float) tuple)
                              {{
                                   float x = tuple.Item1;
                                   float y = tuple.Item2;
                                   return (x, (float){functionExpression});
                              }}
                         }}";

                SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

                string assemblyName = "DynamicAssembly";
                MetadataReference[] references = new MetadataReference[]
                {
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Math).Assembly.Location)
                };

                CSharpCompilation compilation = CSharpCompilation.Create(
                    assemblyName,
                    syntaxTrees: new[] { syntaxTree },
                    references: references,
                    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

                using (var ms = new System.IO.MemoryStream())
                {
                    EmitResult result = compilation.Emit(ms);

                    if (!result.Success)
                    {
                        // Handle compilation errors
                        var failures = result.Diagnostics.Where(diagnostic =>
                            diagnostic.IsWarningAsError ||
                            diagnostic.Severity == DiagnosticSeverity.Error);

                        foreach (var diagnostic in failures)
                        {
                            MessageBox.Show(diagnostic.GetMessage());
                        }
                    }
                    else
                    {
                        ms.Seek(0, System.IO.SeekOrigin.Begin);

                        Assembly assembly = Assembly.Load(ms.ToArray());
                        Type type = assembly.GetType("DynamicClass");
                        MethodInfo methodInfo = type.GetMethod("DynamicMethod");

                        // Create a Func<float, float> delegate from the dynamically created method
                        var functionDelegate = (Func<(float, float), (float, float)>)Delegate.CreateDelegate(typeof(Func<(float, float),(float, float)>), methodInfo);

                        // Return the delegate
                        return functionDelegate;
                    }
                }
            }
            else
            {
                string code = $@"using System;
                         {GenerateUsingDirectiveCode(usingDirectives)}
                         
                         public class DynamicClass
                         {{
                              {GenerateVariableCode(stateForm.GetVariables())}
                              public static (float, float) DynamicMethod((float, float) tuple)
                              {{
                                   float x = tuple.Item1;
                                   float y = tuple.Item2;
                                   {functionExpression}
                                   return (x, y);
                              }}
                         }}";

                SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

                string assemblyName = "DynamicAssembly";
                MetadataReference[] references = new MetadataReference[]
                {
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Math).Assembly.Location)
                };

                CSharpCompilation compilation = CSharpCompilation.Create(
                    assemblyName,
                    syntaxTrees: new[] { syntaxTree },
                    references: references,
                    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

                using (var ms = new System.IO.MemoryStream())
                {
                    EmitResult result = compilation.Emit(ms);

                    if (!result.Success)
                    {
                        // Handle compilation errors
                        var failures = result.Diagnostics.Where(diagnostic =>
                            diagnostic.IsWarningAsError ||
                            diagnostic.Severity == DiagnosticSeverity.Error);

                        foreach (var diagnostic in failures)
                        {
                            MessageBox.Show(diagnostic.GetMessage());
                        }
                    }
                    else
                    {
                        ms.Seek(0, System.IO.SeekOrigin.Begin);

                        Assembly assembly = Assembly.Load(ms.ToArray());
                        Type type = assembly.GetType("DynamicClass");
                        MethodInfo methodInfo = type.GetMethod("DynamicMethod");

                        // Create a Func<float, float> delegate from the dynamically created method
                        var functionDelegate = (Func<(float, float), (float, float)>)Delegate.CreateDelegate(typeof(Func<(float, float), (float, float)>), methodInfo);

                        // Return the delegate
                        return functionDelegate;
                    }
                }

            }



            return null; // Return null if the delegate creation fails
        }

        private void hopeButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Save PNG File";
            saveFileDialog.Filter = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = "png";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                bitmap.Save(filePath, ImageFormat.Png);
                // Perform save operation with the selected file path
                
            }
        }

        private void graphArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - mouseDownLocation.X;
                int deltaY = e.Y - mouseDownLocation.Y;

                offsetX += deltaX / Scale;
                offsetY += deltaY / Scale;

                mouseDownLocation = e.Location;

                Redraw();
            }
            Text = $"GraphSharp - Mouse Position: ({(e.X - Width / 2) / Scale}, {-(e.Y - Height / 2) / Scale})";
        }

        private void hopeButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Save JSON File";
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = "json";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                // Perform save operation with the selected file path
                Console.WriteLine("JSON file saved to: " + filePath);

                var views = flowLayoutPanel1.Controls.OfType<PlotView>().ToList();
                var rViews = new List<PlotViewJsonRep>();
                foreach(var view in views)
                {
                    rViews.Add(new PlotViewJsonRep(view.expression, view.color));
                }
                // Example JSON data to save
                string jsonData = JsonExpressionsLoader.Save(rViews.ToArray());


                // Save the JSON data to the file
                File.WriteAllText(filePath, jsonData);
            }
        }

        private void hopeButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open JSON File";
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                // Perform open operation with the selected file path
                Console.WriteLine("JSON file opened: " + filePath);

                // Example check if current project should be overridden
                DialogResult overrideResult = MessageBox.Show("Opening this file will override the current project. Do you want to continue?", "Override Project", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (overrideResult == DialogResult.Yes)
                {
                    // Perform project override
                    Console.WriteLine("Project overridden.");

                    // Example reading the JSON data from the file
                    flowLayoutPanel1.Controls.Clear();
                    JsonExpressionsLoader loader = new JsonExpressionsLoader(filePath);
                    var views = loader.GetViews();
                    var rViews = new List<PlotView>();
                    
                    foreach(var view in views)
                    {
                        rViews.Add(new PlotView(this, view.expression, view.color));

                    }
                    flowLayoutPanel1.Controls.AddRange(rViews.ToArray());
                }
                else
                {
                    Console.WriteLine("Project not overridden.");
                }
            }
        }

        private void hopeButton6_Click(object sender, EventArgs e)
        {
            stateForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            oldSize = ClientSize;
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
   
        }

        private void hopeCheckBox1_Click(object sender, EventArgs e)
        {
            ShouldTick = hopeCheckBox1.Checked;
            Redraw();
        }


        private void graphArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseDownLocation = e.Location;
            }
        }

        private void graphArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void hopeButton7_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            Redraw();
        }


    }

    public class JsonExpressionsLoader
    {
        public string filePath = string.Empty;

        public JsonExpressionsLoader(string filePath)
        {
            this.filePath = filePath;
        }

        public PlotViewJsonRep[] GetViews()
        {
            if(filePath == string.Empty)
                return new PlotViewJsonRep[0];

            return JsonConvert.DeserializeObject<PlotViewJsonRep[]>(File.ReadAllText(filePath)); 

        }

        public static string Save(PlotViewJsonRep[] views)
        {
            
            return JsonConvert.SerializeObject(views, Formatting.Indented);
        }
    }
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

}
