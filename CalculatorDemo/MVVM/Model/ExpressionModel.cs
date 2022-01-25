using ExpressionEvalutor;
using ExpressionEvalutor.Evaluation;
using ExpressionEvalutor.Syntax;

namespace CalculatorDemo.MVVM.Model
{
    public sealed class ExpressionModel
    {
        public Evalutor Expression { get; }
        public ExpressionModel(string expression)
        {
            SyntaxTree syntaxTree = SyntaxTree.Parse(expression);
            Expression = new Evalutor(syntaxTree.Root);
        }
    }
}
