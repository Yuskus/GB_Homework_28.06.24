namespace HomeworkGB5
{
    internal class CalculatorActionLog
    {
        public CalculatorAction CalcAction { get; private set; }
        public double CalcArgument { get; private set; }
        public CalculatorActionLog(CalculatorAction calculatorAction, double calcArgument)
        {
            CalcAction = calculatorAction;
            CalcArgument = calcArgument;
        }
    }
}
