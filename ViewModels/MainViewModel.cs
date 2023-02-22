using Calculator.Infrastructure.Commands;
using Calculator.Models;
using Calculator.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculator.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public ICommand InsertedNumberCommand { get; }
        public ICommand InsertedOperatorCommand { get; }
        public ICommand InsertedSingularCommand { get; }
        public DisplayModel Display { get; set; } = new();

        private void OnInsertedNumberCommandExecuted(object o)
        {
            string number = (string)o;
            if (Display.CurrentInput.Equals("0"))
            {
                Display.CurrentInput = number;
                return;
            }
            Display.CurrentInput += number.ToString();
        }

        private void OnInsertedOperatorCommandExecuted(object o)
        {
            if(Display.PreviousOperand == String.Empty)
                Display.PreviousOperand = "0";
            Display.Operator = (string)o;
            DataTable dataTable = new DataTable();
            switch (Display.Operator)
            {
                case "+/-":
                    Display.CurrentInput = (-Double.Parse(Display.CurrentInput)).ToString();
                    break;
                case ",":
                    if (!Display.CurrentInput.Contains(","))
                        Display.CurrentInput += ",";
                    break;
                case "=":
                    if (Display.Operator != String.Empty)
                        Display.CurrentInput = (string)dataTable.Compute($"{Display.PreviousOperand}{Display.Operator}{Display.CurrentInput}", ""); ;
                    break;
                default:
                    Display.CurrentInput = (string)dataTable.Compute($"{Display.PreviousOperand}{Display.Operator}{Display.CurrentInput}","");
                    break;
            }
        }

        private void OnInsertedSingularCommandExecuted(object o)
        {
            if (Display.CurrentInput.Equals("0"))
                return;
            double currInputAsNum = Double.Parse(Display.CurrentInput);
            switch ((string)o)
            {
                case "CE":
                    Display.CurrentInput = "0";
                    Display.PreviousOperand = String.Empty;
                    Display.Operator = String.Empty;
                    break;
                case "C":
                    Display.CurrentInput = "0";
                    break;
                case "DEL":
                    if (Display.CurrentInput == "0")
                        break;
                    if (Display.CurrentInput != "0" && Display.CurrentInput.Length == 1)
                    {
                        Display.CurrentInput = "0";
                    }
                    else
                    {
                        Display.CurrentInput = Display.CurrentInput.Substring(0, Display.CurrentInput.Length - 1);
                    }
                    break;
                case "1/x":
                    Display.CurrentInput = (1 / currInputAsNum).ToString();
                    break;
                case "X^2":
                    Display.CurrentInput = (currInputAsNum * currInputAsNum).ToString();
                    break;
                case "X^-2":
                    Display.CurrentInput = Math.Sqrt(currInputAsNum).ToString();
                    break;
                default:
                    Display.CurrentInput = "0";
                    break;
            }
            Display.CurrentInput += (string)o;
        }

        public MainViewModel()
        {
            #region Commands
            InsertedNumberCommand = new LambdaCommand(OnInsertedNumberCommandExecuted);
            InsertedOperatorCommand = new LambdaCommand(OnInsertedOperatorCommandExecuted);
            InsertedSingularCommand = new LambdaCommand(OnInsertedSingularCommandExecuted);
            #endregion
        }
    }
}
