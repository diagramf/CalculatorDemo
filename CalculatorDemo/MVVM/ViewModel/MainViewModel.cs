using System;
using System.Collections.ObjectModel;
using System.Linq;
using CalculatorDemo.Core;
using CalculatorDemo.MVVM.Model;

namespace CalculatorDemo.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        // コマンド
        public RelayCommand ZeroClick { get; set; }
        public RelayCommand OneClick { get; set; }
        public RelayCommand TwoClick { get; set; }
        public RelayCommand ThreeClick { get; set; }
        public RelayCommand FourClick { get; set; }
        public RelayCommand FiveClick { get; set; }
        public RelayCommand SixClick { get; set; }
        public RelayCommand SevenClick { get; set; }
        public RelayCommand EightClick { get; set; }
        public RelayCommand NineClick { get; set; }

        public RelayCommand DotClick { get; set; }
        public RelayCommand AdditionClick { get; set; }
        public RelayCommand SubtractClick { get; set; }
        public RelayCommand MultiplyClick { get; set; }
        public RelayCommand DivideClick { get; set; }
        public RelayCommand ModuloClick { get; set; }
        public RelayCommand EqualClick { get; set; }
        public RelayCommand AllClearClick { get; set; }

        public ExpressionHistoryModel ExpressionHistory { get; set; }

        public string CurrentTerm { get; set; }

        private string _resultLabel;
        public string ResultLabel
        {
            get => _resultLabel;
            set
            {
                _resultLabel = value;
                OnPropertyChanged();
            }
        }

        private string _lastResultLabel;
        public string LastResultLabel
        {
            get => _lastResultLabel;

            set
            {
                _lastResultLabel = value;
                OnPropertyChanged();
            }
        }

        private enum ButtonKind
        {
            Zero = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,

            Dot,
            Addition,
            Subtract,
            Multiply,
            Divide,
            Modulo,
            Equal,
            AllClear
        }


        public MainViewModel()
        {
            InputAllClear();

            ExpressionHistory = new ExpressionHistoryModel()
            {
                History = new ObservableCollection<ExpressionModel>()
            };


            ZeroClick = new RelayCommand(o => InputButton(ButtonKind.Zero));
            OneClick = new RelayCommand(o => InputButton(ButtonKind.One));
            TwoClick = new RelayCommand(o => InputButton(ButtonKind.Two));
            ThreeClick = new RelayCommand(o => InputButton(ButtonKind.Three));
            FourClick = new RelayCommand(o => InputButton(ButtonKind.Four));
            FiveClick = new RelayCommand(o => InputButton(ButtonKind.Five));
            SixClick = new RelayCommand(o => InputButton(ButtonKind.Six));
            SevenClick = new RelayCommand(o => InputButton(ButtonKind.Seven));
            EightClick = new RelayCommand(o => InputButton(ButtonKind.Eight));
            NineClick = new RelayCommand(o => InputButton(ButtonKind.Nine));

            DotClick = new RelayCommand(o => InputButton(ButtonKind.Dot));
            AdditionClick = new RelayCommand(o => InputButton(ButtonKind.Addition));
            SubtractClick = new RelayCommand(o => InputButton(ButtonKind.Subtract));
            MultiplyClick = new RelayCommand(o => InputButton(ButtonKind.Multiply));
            DivideClick = new RelayCommand(o => InputButton(ButtonKind.Divide));
            ModuloClick = new RelayCommand(o => InputButton(ButtonKind.Modulo));
            EqualClick = new RelayCommand(o => InputButton(ButtonKind.Equal));
            AllClearClick = new RelayCommand(o => InputButton(ButtonKind.AllClear));
        }


        private int ButtonKindToNumber(ButtonKind kind)
        {
            return (int)kind;
        }

        private void InputButton(ButtonKind kind)
        {
            switch (kind)
            {
                case ButtonKind.Zero:
                case ButtonKind.One:
                case ButtonKind.Two:
                case ButtonKind.Three:
                case ButtonKind.Four:
                case ButtonKind.Five:
                case ButtonKind.Six:
                case ButtonKind.Seven:
                case ButtonKind.Eight:
                case ButtonKind.Nine:
                    InputNumber(kind);
                    break;

                case ButtonKind.Dot:
                    InputDot();
                    break;

                case ButtonKind.Addition:
                case ButtonKind.Subtract:
                case ButtonKind.Multiply:
                case ButtonKind.Divide:
                case ButtonKind.Modulo:
                    InputBinaryExpression(kind);
                    break;


                case ButtonKind.Equal:
                    InputEqual();
                    break;
                case ButtonKind.AllClear:
                    InputAllClear();
                    break;
            }
        }

        private void InputEqual()
        {
            if (char.IsDigit(ResultLabel.Last()))
            {
                ExpressionHistory.History.Add(new ExpressionModel(ResultLabel));
                LastResultLabel = ExpressionHistory.LastExpression.Expression.ToStringExpression() + " =";

                ResultLabel = ExpressionHistory.LastExpression.Expression.Evalute().ToString();
                CurrentTerm = ResultLabel;
            }
        }

        private void InputAllClear()
        {
            ResultLabel = "0";
            CurrentTerm = "0";
            LastResultLabel = "";
        }

        private void InputBinaryExpression(ButtonKind kind)
        {
            if (CurrentTerm != "" &&
                char.IsDigit(CurrentTerm.Last()))
            {
                if (kind == ButtonKind.Addition)
                {
                    ResultLabel += "+";
                }
                else if (kind == ButtonKind.Subtract)
                {
                    ResultLabel += "-";
                }
                else if (kind == ButtonKind.Multiply)
                {
                    ResultLabel += "*";
                }
                else if (kind == ButtonKind.Divide)
                {
                    ResultLabel += "/";
                }
                else if(kind == ButtonKind.Modulo)
                {
                    ResultLabel += "%";
                }
                else
                {
                    throw new Exception($"想定しないオペレータ {kind} が渡されました。");
                }

                CurrentTerm = "";
            }
        }

        private void InputDot()
        {
            if (!CurrentTerm.Contains(".") &&
                char.IsDigit(ResultLabel.Last()))
            {
                CurrentTerm += ".";
                ResultLabel += ".";
            }
        }

        private void InputNumber(ButtonKind kind)
        {
            int number = ButtonKindToNumber(kind);

            if (CurrentTerm == "0")
            {
                if (kind != ButtonKind.Zero)
                {
                    if (ResultLabel == "0")
                    {
                        ResultLabel = number.ToString();
                    }
                    else
                    {
                        ResultLabel += number.ToString();
                    }
                    CurrentTerm = number.ToString();
                }
            }
            else
            {
                ResultLabel += number.ToString();
                CurrentTerm += number.ToString();
            }
        }
    }
}
