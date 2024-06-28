namespace HomeworkGB5
{
    internal class Calculator : ICalc
    {
        public event EventHandler<string>? GotResult;
        private Stack<int> last = new();
        public int Result { get; set; }
        public Calculator()
        {
            Result = 0;
        }
        public Calculator(int result)
        {
            Result = result;
        }
        private void OnGotResult(string args)
        {
            GotResult?.Invoke(this, args);
        }
        public void Divide(int value)
        {
            if (value == 0)
            {
                Console.WriteLine("Делитель не может быть равным нулю.");
                return;
            }
            last.Push(Result);
            Result /= value;
            OnGotResult("деление");
        }

        public void Multiply(int value)
        {
            last.Push(Result);
            Result *= value;
            OnGotResult("умножение");
        }

        public void Substract(int value)
        {
            last.Push(Result);
            Result -= value;
            OnGotResult("вычитание");
        }

        public void Sum(int value)
        {
            last.Push(Result);
            Result += value;
            OnGotResult("сложение");
        }
        public void CancelLast()
        {
            if (last.TryPop(out int value))
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
