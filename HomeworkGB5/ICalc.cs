namespace HomeworkGB5
{
    internal interface ICalc
    {
        event EventHandler<string> GotResult;
        void Sum(int value);
        void Substract(int value);
        void Multiply(int value);
        void Divide(int value);
        void CancelLast();
    }
}
