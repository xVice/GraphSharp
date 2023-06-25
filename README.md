# GraphSharp

GraphSharp is a Windows Forms application for plotting mathematical functions. It allows users to input mathematical expressions and visualize the corresponding graphs.

![graphsharp img](https://raw.githubusercontent.com/xVice/storage/main/graphsharp.PNG)

## Features

- Plot custom mathematical functions
- Adjustable scale for the x and y axes
- Dynamic graph updating
- Save and load graphs in JSON format
- Export graphs as PNG images

## Getting Started

To run the application, follow these steps:

1. Clone the repository: `git clone https://github.com/your-username/GraphSharp.git`
2. Open the solution in Visual Studio.
3. Build the solution to restore NuGet packages.
4. Run the application by pressing F5.

## Usage

1. Enter a mathematical expression in the input box.
2. Click the "Add Plot" button to add the function to the graph.
3. Adjust the scale of the graph using the provided controls.
4. Click the "Redraw" button to update the graph.
5. Use the mouse to explore the graph by hovering over points.
6. Save the graph as a PNG image by clicking the "Save as PNG" button.
7. Save the graph configuration as a JSON file by clicking the "Save as JSON" button.
8. Load a graph configuration from a JSON file by clicking the "Open JSON" button.

### Types of Mathematical Expressions

The application supports two types of mathematical expressions:

1. Single-line Expression:
   - This type of expression should directly return the result of the mathematical calculation.
   - Example: `x => 2 * x + 3`

2. Multi-line Expression:
   - This type of expression allows for more complex calculations by using additional statements.
   - Example:
   ```csharp
    float result = 0;
    for (int i = 0; i < 5; i++)
    {
        result += (float)Math.Sin(x * i);
    }
    return result;
   ```
   - Note: Make sure to include the `return` statement in the multi-line expression to specify the result.

You can also download a demo.json project [here](https://github.com/xVice/storage/blob/main/demo.json)

## Dependencies

- .NET Framework 4.7.2 or later
- Newtonsoft.Json (version x.x.x)
- System.Drawing (version x.x.x)
- System.Windows.Forms (version x.x.x)
- Microsoft.CodeAnalysis (version x.x.x)

## License

This project is licensed under the [MIT License](LICENSE).

