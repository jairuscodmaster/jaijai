using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JairusCsharp
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private double CalculateArea(double length, double width) => length * width;
        private double CalculateArea(double radius) => Math.PI * radius * radius;
        private double CalculateArea(double baseLength, double height, bool isTriangle) => isTriangle ? 0.5 * baseLength * height : 0;

        private bool TryParseInput(string input1, string input2, out double value1, out double value2)
        {
            bool result = double.TryParse(input1, out value1);
            result &= double.TryParse(input2, out value2);
            return result;
        }

        private bool TryParseInput(string input, out double value)
        {
            return double.TryParse(input, out value);
        }

        private void CalculateAndDisplayArea(Func<double, double, double> areaFunc, double value1, double value2, string shapeName)
        {
            double area = areaFunc(value1, value2);
            listBox1.Items.Add($"{shapeName}: {value1}, {value2}, Area = {area}");
            textBox6.Text = $"Most Recent Result: {area}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TryParseInput(textBox1.Text, textBox2.Text, out double length, out double width))
                CalculateAndDisplayArea(CalculateArea, length, width, "Rectangle");
            else
                MessageBox.Show("Enter the numbers of length and width");
        }

        private void btn2CalculateCircle_Click(object sender, EventArgs e)
        {
            if (TryParseInput(textBox3.Text, out double radius))
            {
                double area = CalculateArea(radius);
                MessageBox.Show($"Circle: radius = {radius}, Area = {area}");
                listBox1.Items.Add($"Circle: radius = {radius}, Area = {area}");
                textBox6.Text = $"Most Recent Result: {area}";
            }
            else
            {
                MessageBox.Show("Enter a valid radius");
            }
        }

        private void btn3CalculateTriangle_Click(object sender, EventArgs e)
        {
            if (TryParseInput(textBox4.Text, textBox5.Text, out double baseLength, out double height))
            {
                double area = CalculateArea(baseLength, height, true);
                MessageBox.Show($"Triangle: base = {baseLength}, height = {height}, Area = {area}");
                listBox1.Items.Add($"Triangle: base = {baseLength}, Height = {height}, Area = {area}");
                textBox6.Text = $"Most Recent Result: {area}";
            }
            else
            {
                MessageBox.Show("Enter valid base and height");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}