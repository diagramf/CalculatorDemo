using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorDemo.Core;
using CalculatorDemo.MVVM.Model;

namespace CalculatorDemo.MVVM.ViewModel
{
    public class MainViewModel
    {
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

        public ResultModel ResultModel { get; set; }

        public MainViewModel()
        {
            ResultModel = new ResultModel
            {
                ResultLabel = "0"
            };

            ZeroClick = new RelayCommand(o =>
            {
                Debug.Print("Zero");
            });

            OneClick = new RelayCommand(o =>
            {
                Debug.Print("One");
            });

            TwoClick = new RelayCommand(o =>
            {
                Debug.Print("Two");
            });

            ThreeClick = new RelayCommand(o =>
            {
                Debug.Print("Three");
            });

            FourClick = new RelayCommand(o =>
            {
                Debug.Print("Four");
            });

            FiveClick = new RelayCommand(o =>
            {
                Debug.Print("Five");
            });

            SixClick = new RelayCommand(o =>
            {
                Debug.Print("Six");
            });

            SevenClick = new RelayCommand(o =>
            {
                Debug.Print("Seven");
            });

            EightClick = new RelayCommand(o =>
            {
                Debug.Print("Eight");
            });

            NineClick = new RelayCommand(o =>
            {
                Debug.Print("Nine");
            });
        }
    }
}
