using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDemo.MVVM.Model
{
    public sealed class ExpressionHistoryModel
    {
        public ObservableCollection<ExpressionModel> History { get; set; }

        public ExpressionModel LastExpression => History.LastOrDefault();
    }
}
