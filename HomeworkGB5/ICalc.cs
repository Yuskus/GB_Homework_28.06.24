namespace HomeworkGB5
{
    internal interface ICalc
    {
        event EventHandler<string> GotResult;
        void Sum(double value);
        void Substract(double value);
        void Multiply(double value);
        void Divide(double value);
        void CancelLast();
    }
}
