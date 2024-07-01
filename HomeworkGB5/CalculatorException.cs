namespace HomeworkGB5
{
    internal class CalculatorException : Exception
    {
        public Stack<CalculatorActionLog> ActionLog { get; private set; } = new();
        public CalculatorException() { }
        public CalculatorException(string message) : base(message) { }
        public CalculatorException(string message, Stack<CalculatorActionLog> log) : base(message)
        {
            ActionLog = log;
        }
        public CalculatorException(string message, Exception exception) : base(message, exception) { }
        public override string ToString()
        {
            return Message + " " + string.Join("\n", ActionLog.Select(x => $"Тип операции, вызвавшей исключение: {x.CalcAction}. Переданный аргумент: {x.CalcArgument}."));
        }
    }
    internal class CalculatorDivideByZeroException : CalculatorException
    {
        public CalculatorDivideByZeroException() { }
        public CalculatorDivideByZeroException(string message) : base(message) { }
        public CalculatorDivideByZeroException(string message, Stack<CalculatorActionLog> log) : base(message, log) { }
        public CalculatorDivideByZeroException(string message, Exception exception) : base(message, exception) { }
    }
    internal class CalculatorOperationCauseOverflowException : CalculatorException
    {
        public CalculatorOperationCauseOverflowException() { }
        public CalculatorOperationCauseOverflowException(string message) : base(message) { }
        public CalculatorOperationCauseOverflowException(string message, Stack<CalculatorActionLog> log) : base(message, log) { }
        public CalculatorOperationCauseOverflowException(string message, Exception exception) : base(message, exception) { }
    }
}
