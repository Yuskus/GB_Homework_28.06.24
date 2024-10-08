﻿namespace HomeworkGB5
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Привет! Это калькулятор. " +
                "\nВы можете проводить здесь разные операции: " +
                "\n1) Сложение (+) \n2) Вычитание (-) \n3) Умножение (*) " +
                "\n4) Деление(/) \n5) А также отмена операции (z) " +
                "\nВведите тип операции с помощью символа, а затем введите число." +
                "\nЧтобы выйти из цикла используйте q или введите пустую строку." +
                "\nНо для начала задайте значение, с которым будут проводиться операции." +
                "\n");

            var calc = new Calculator(double.TryParse(Console.ReadLine(), out double startValue) ? startValue : 0);

            calc.GotResult += Calculator_GoResult;

            while (true)
            {
                string[] args = Ask("Введите тип операции и число через пробел: ").Trim().Split(' ');

                if (args.Length == 1)
                {
                    if (args[0] == "q" || args[0] == "Q")
                    {
                        break;
                    }
                    else if (args[0] == "z" || args[0] == "Z")
                    {
                        calc.CancelLast();
                        continue;
                    }
                }
                else if (args.Length == 2)
                {
                    if (double.TryParse(args[1], out double res))
                    {
                        switch (args[0])
                        {
                            case "+": Execute(calc.Sum, res); break;
                            case "-": Execute(calc.Substract, res); break;
                            case "*": Execute(calc.Multiply, res); break;
                            case "/": Execute(calc.Divide, res); break;
                            default: Console.WriteLine("Вы что-то перепутали! Такой операции нет."); break;
                        }
                        continue;
                    }
                }
                Console.WriteLine("Возможно, вы ошиблись. Попробуйте снова.");
            }

            Console.WriteLine("Калькулятор завершил работу. Пока!");

            calc.GotResult -= Calculator_GoResult;

            Console.ReadKey(true);
        }
        static string Ask(string text)
        {
            Console.WriteLine(text);
            string line = Console.ReadLine() ?? "";
            return line == "" ? "q" : line;
        }
        static void Execute(Action<double> action, double value = 1)
        {
            try
            {
                action?.Invoke(value);
            }
            catch (CalculatorDivideByZeroException ex)
            {
                Console.WriteLine(ex);
            }
            catch (CalculatorOperationCauseOverflowException ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Calculator_GoResult(object? sender, string args)
        {
            Console.WriteLine($"Тип операции {args}. Результат: "+ (sender as Calculator)?.Result);
        }
    }
}
