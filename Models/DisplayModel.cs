using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    internal class DisplayModel : INotifyPropertyChanged
    {
        private string _currentInput = "0";
        private string _previousOperand = String.Empty;
        private string _operator = String.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string CurrentInput
        {
            get => _currentInput;
            set
            {
                _currentInput = value;
                OnPropertyChanged();
            }
        }
        public string PreviousOperand
        {
            get => _previousOperand;
            set
            {
                _previousOperand = value;
                OnPropertyChanged();
            }
        }
        public string Operator
        {
            get => _operator;
            set
            {
                _operator = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
