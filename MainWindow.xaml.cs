using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //private double NumToOperateWith { get; set; } = 0;
        //private string Operator = String.Empty;

        public MainWindow()
        {
            InitializeComponent();
            //MouseMove += ads;
            //Loaded += ads;
        }

        //public void ads(object sender, RoutedEventArgs e)
        //{
        //    Console.WriteLine("MOUSE MOVED");
        //}
        
        //public void ButtonClicked(object sender, RoutedEventArgs e)
        //{
        //    Button button = (Button)sender;
        //    string content = button.Content.ToString();
        //    double currTextAsNum = Double.Parse(Display.Text);
        //    switch (content)
        //    {
                //case "CE":
                //    Display.Text ="0";
                //    PreviousOperation.Text = "";
                //    NumToOperateWith = 0;
                //    break; 

                //case "C":
                //    Display.Text ="0";
                //    NumToOperateWith = 0;
                //    break;

                //case "DEL":
                //    if (Display.Text == "0")
                //        break;
                //    if(Display.Text != "0" && Display.Text.Length == 1)
                //    {
                //        NumToOperateWith = 0;
                //    }
                //    else
                //    {
                //        Display.Text =Display.Text.Substring(0, Display.Text.Length-1);
                //    }
                //    break;
                //case "1/x":
                //    Display.Text =(1/ currTextAsNum).ToString();
                //    break;
                //case "X^2":
                //    Display.Text = (currTextAsNum * currTextAsNum).ToString();
                //    break;
                //case "X^-2":
                //    Display.Text = Math.Sqrt(currTextAsNum).ToString();
        //            break;
        //        case "-":
        //            ProcessInsertedOperator("-", currTextAsNum);
        //            break;
        //        case "%":
        //            ProcessInsertedOperator("%", currTextAsNum);
        //            break;
        //        case "/":
        //            ProcessInsertedOperator("/", currTextAsNum);
        //            break;
        //        case "+":
        //            ProcessInsertedOperator("+", currTextAsNum);
        //            break;
        //        case "+/-":
        //            Display.Text =(-currTextAsNum).ToString();
        //            break;
        //        case "X":
        //            ProcessInsertedOperator("X", currTextAsNum);
        //            break;
        //        case ",":
        //            if (!Display.Text.Contains(","))
        //                Display.Text += ",";
        //            break;
        //        case "=":
        //            if (Operator != String.Empty)
        //                Display.Text =CalculateResult(currTextAsNum).ToString();
        //            NumToOperateWith = Double.Parse(Display.Text);
        //            break;
        //        default:
        //            if (Display.Text == "0")
        //                Display.Text = content;
        //            else
        //                Display.Text += content;
        //            break;
        //    }
        //}

        //private void ProcessInsertedOperator(string op, double currTextAsNum)
        //{
        //    if (Operator != String.Empty)
        //        Display.Text = CalculateResult(currTextAsNum).ToString();
        //    NumToOperateWith = Double.Parse(Display.Text);
        //    Operator = op;
        //    PreviousOperation.Text = NumToOperateWith.ToString() + Operator;
        //    Display.Text = "0";
        //}

        //private double CalculateResult(double secondOperand)
        //{
        //    switch (Operator)
        //    {
        //        case ("-"):
        //            return NumToOperateWith - secondOperand;
        //        case ("/"):
        //            return NumToOperateWith / secondOperand;
        //        case ("+"):
        //            return NumToOperateWith + secondOperand;
        //        case ("X"):
        //            return NumToOperateWith * secondOperand;
        //        case ("%"):
        //            return NumToOperateWith % secondOperand;
        //        default:
        //            return 0;
        //    }
        //}
    }
}
