namespace HomeworkGB5
{
    internal class Calculator : ICalc
    {
        public event EventHandler<string>? GotResult;
        private Stack<double> lastResult = new();
        private Stack<CalculatorActionLog> errorList = new();
        public double Result { get; private set; }
        public Calculator()
        {
            Result = 0;
        }
        public Calculator(double result)
        {
            Result = result;
        }
        private void OnGotResult(string args)
        {
            GotResult?.Invoke(this, args);
        }
        public void Divide(double value)
        {
            if (value == 0)
            {
                errorList.Push(new CalculatorActionLog(CalculatorAction.Divide, value));
                throw new CalculatorDivideByZeroException("Делитель не может быть равным нулю.", errorList);
            }
            else if (Result != 0 && Result != Result * value / value)
            {
                errorList.Push(new CalculatorActionLog(CalculatorAction.Divide, value));
                throw new CalculatorOperationCauseOverflowException("Переполнение при попытке деления.", errorList);
            }
            lastResult.Push(Result);
            Result /= value;
            OnGotResult("деление");
        }

        public void Multiply(double value)
        {
            if (Result != 0 && value != 0 && Result != Result * value / value)
            {
                errorList.Push(new CalculatorActionLog(CalculatorAction.Multiply, value));
                throw new CalculatorOperationCauseOverflowException("Переполнение при попытке умножения.", errorList);
            }
            lastResult.Push(Result);
            Result *= value;
            OnGotResult("умножение");
        }

        public void Substract(double value)
        {
            if (double.MinValue + value > Result || double.MaxValue - value < Result)
            {
                errorList.Push(new CalculatorActionLog(CalculatorAction.Substract, value));
                throw new CalculatorOperationCauseOverflowException("Переполнение при попытке вычитания.", errorList);
            }
            lastResult.Push(Result);
            Result -= value;
            OnGotResult("вычитание");
        }

        public void Sum(double value)
        {
            if (double.MinValue + value > Result || double.MaxValue - value < Result)
            {
                errorList.Push(new CalculatorActionLog(CalculatorAction.Sum, value));
                throw new CalculatorOperationCauseOverflowException("Переполнение при попытке сложения.", errorList);
            }
            lastResult.Push(Result);
            Result += value;
            OnGotResult("сложение");
        }
        public void CancelLast()
        {
            if (lastResult.TryPop(out double value))
            {
                Result = value;
                OnGotResult("отмена операции");
            }
            else
            {
                Console.WriteLine("Отмена операции не произошла, стэк пуст.");
            }
        }
    }
}
