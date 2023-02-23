using Calculator.Infrastructure.Commands;
using Calculator.Models;
using Calculator.ViewModels.Base;
using System;
using System.Data;
using System.Windows.Input;

namespace Calculator.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public ICommand InsertedNumberCommand { get; }
        public ICommand InsertedOperatorCommand { get; }
        public ICommand InsertedSingularCommand { get; }
        public DisplayModel Display { get; set; } = new();

        public MainViewModel()
        {
            #region Commands
            InsertedNumberCommand = new LambdaCommand(OnInsertedNumberCommandExecuted);
            InsertedOperatorCommand = new LambdaCommand(OnInsertedOperatorCommandExecuted);
            InsertedSingularCommand = new LambdaCommand(OnInsertedSingularCommandExecuted);
            #endregion
        }

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
            string operatr = (string)o;
            if (Display.PreviousOperand == String.Empty && !operatr.Equals("="))
            {
                Display.PreviousOperand = Display.CurrentInput;
                Display.CurrentInput = "0";
                Display.Operator = operatr;
                return;
            }
            switch (operatr)
            {
                case "=":
                    if (Display.Operator != String.Empty)
                    {
                        Calculate(Display.Operator);
                        Display.CurrentInput = Display.PreviousOperand;
                        Display.PreviousOperand = String.Empty;
                        Display.Operator = String.Empty;
                        return;
                    }
                    else
                    {
                        return;
                    }
                default:
                    if (Display.CurrentInput.Equals("0"))
                    {
                        Display.Operator = operatr;
                        return;
                    }
                    return;
                    Calculate(operatr);
                    break;
            }
            Display.Operator = operatr;
            Display.CurrentInput = "0";
        }

        public void Calculate(string operatr)
        {
            double prevOperandAsDouble = Double.Parse(Display.PreviousOperand);
            double currentInputAsDouble = Double.Parse(Display.CurrentInput);
            switch (operatr)
            {
                case "/":
                    Display.PreviousOperand = (prevOperandAsDouble / currentInputAsDouble).ToString();
                    break;
                case "*":
                    Display.PreviousOperand = (prevOperandAsDouble * currentInputAsDouble).ToString();
                    break;
                case "-":
                    Display.PreviousOperand = (prevOperandAsDouble - currentInputAsDouble).ToString();
                    break;
                case "%":
                    Display.PreviousOperand = (prevOperandAsDouble % currentInputAsDouble).ToString();
                    break;
                case "+":
                    Display.PreviousOperand = (prevOperandAsDouble + currentInputAsDouble).ToString();
                    break;
                default:
                    Display.CurrentInput = "DEBUG";
                    break;
            }
        }

        private void OnInsertedSingularCommandExecuted(object o)
        {
            double currInputAsNum = Double.Parse(Display.CurrentInput);
            switch ((string)o)
            {
                case "CE":
                    Display.CurrentInput = "0";
                    break;
                case "C":
                    Display.CurrentInput = "0";
                    Display.PreviousOperand = String.Empty;
                    Display.Operator = String.Empty;
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
                case "+/-":
                    Display.CurrentInput = (-Double.Parse(Display.CurrentInput)).ToString();
                    break;
                case ",":
                    if (!Display.CurrentInput.Contains(","))
                        Display.CurrentInput += ",";
                    break;
                default:
                    Display.CurrentInput = "0";
                    break;
            }
        }
    }
}
