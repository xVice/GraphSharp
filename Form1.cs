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

        public Form1()
        {

            Width = 1183; Height = 833;
            bitmap = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Text = "Grapsharp";
            ClientSize = new Size(Width, Height);

            InitializeComponent();

        }

        private void PlotFunction(Func<float, float> function, Pen pen)
        {
            try
            {
                for (float x = -graphArea.Width / 2; x < graphArea.Width / 2; x += 1f / Scale)
                {
                    if(function != null)
                    {
                        float y = function(x / Scale) * Scale;
                        graphics.FillRectangle(pen.Brush, graphArea.Width / 2 + x, graphArea.Height / 2 - y, 1, 1);
                    }
             
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Plot error..");
            }

        }

        private void graphArea_Paint(object sender, PaintEventArgs e)
        {
         
           
            
  
        }

        private void DrawAxes()
        {
            graphics.DrawLine(Pens.White, graphArea.Width / 2, 0, graphArea.Width / 2, graphArea.Height);
            graphics.DrawLine(Pens.White, 0, graphArea.Height / 2, graphArea.Width, graphArea.Height / 2);
        }

        private void Redraw()
        {
            graphics.Clear(Color.FromArgb(20,20,20));
            DrawAxes();
            // Add your function plots here using the PlotFunction method
            // Example: PlotFunction(x => (float)Math.Sin(x), Pens.Red);
            // You can plot multiple functions by calling PlotFunction multiple times
            // Example 1: Quadratic function

            var views = flowLayoutPanel1.Controls.OfType<PlotView>().ToArray();

            if (views.Count() != 0)
            {
                foreach (var view in views)
                {

                    PlotFunction(RunExpression(view.GetExpression()), view.GetPen());
                }
            }

            

            graphArea.Image = bitmap;
            graphArea.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
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
            bitmap = new Bitmap(graphArea.Width, graphArea.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Redraw();
        }

        public void RemoveExpView(PlotView view)
        {
            flowLayoutPanel1.Controls.Remove(view);
            
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



        }

        private Func<float, float> RunExpression(string functionExpression)
        {
            if(!functionExpression.Contains("return "))
            {
                string code = @"
        using System;

        public class DynamicClass
        {
            public static float DynamicMethod(float input)
            {
                return (float)" + functionExpression + @";
            }
        }
    ";

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
                        var functionDelegate = (Func<float, float>)Delegate.CreateDelegate(typeof(Func<float, float>), methodInfo);

                        // Return the delegate
                        return functionDelegate;
                    }
                }
            }
            else
            {
                string code = @"
        using System;

        public class DynamicClass
        {
            public static float DynamicMethod(float input)
            {
                " + functionExpression + @";
            }
        }
    ";

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
                        var functionDelegate = (Func<float, float>)Delegate.CreateDelegate(typeof(Func<float, float>), methodInfo);

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
            Text = $"GrapSharp - Mouse Position: ({(e.X - Width / 2) / Scale}, {-(e.Y - Height / 2) / Scale})";
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

        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {
   
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
}
