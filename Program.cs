using System;

namespace OTUS_Loops_Selection
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputStringWidth = UserInputNumber();
            string inputText = UserInputText();
            string continuousBorder = ContinuousBorder(inputText, inputStringWidth);
            string almostEmptyString = AlmostEmptyString(inputText, inputStringWidth);
            string outputString = OutputString(inputText, inputStringWidth);
            string firstChessString = FirstChessString(inputText, inputStringWidth);
            string secondChessString = SecondChessString(inputText, inputStringWidth);
            
            if (continuousBorder.Length > 40)
                throw new Exception("Длина строки больше 40 символов");

            FirstBlock(continuousBorder, almostEmptyString, outputString, inputStringWidth);
            SecondBlock(continuousBorder, firstChessString, secondChessString, inputStringWidth);
            ThirdBlock(continuousBorder, continuousBorder.Length);

            Console.ReadKey(true);
        }

        private static void FirstBlock(string border, string almostEmptyString, string text, int n)
        {
            for (int i = 0; i < n * 2; i++)
            {
                if (i == 0)
                    Console.WriteLine(border);
                else if (i > 0 && i != n)
                    Console.WriteLine(almostEmptyString);
                else
                    Console.WriteLine(text);

            }
        }
        private static void SecondBlock(string border, string firstChessString, string secondChessString, int n)
        {
            for (int i = 0; i < n * 2; i++)
            {
                if (i == 0)
                    Console.WriteLine(border);
                else if (i > 0 && i % 2 != 0)
                    Console.WriteLine(firstChessString);
                else
                    Console.WriteLine(secondChessString);

            }
        }
        private static void ThirdBlock(string border, int n)
        {
            int i = n - 2, j = n - 2;
            char[,] flag = new char[i, j];
            for (int k = 0; k < i; k++)
            {
                for (int m = 0; m < j; m++)
                {
                    if (m == k)
                        flag[k, m] = '+';
                    else if (m == j - 1 - k)
                        flag[k, m] = '+';
                    else
                        flag[k, m] = ' ';
                }
            }
            Console.WriteLine(border);
            for (int k = 0; k < i; k++)
            {
                Console.Write('+');
                for (int m = 0; m < j; m++)
                {
                    Console.Write(flag[k, m]);
                }
                Console.Write('+');
                Console.WriteLine();
            }
            Console.WriteLine(border);
        }
        private static string SecondChessString(string text, int n)
        {
            string outputString = default;
            string auxiliaryString = default;
            for (int i = 0; i < (text.Length + n * 2); i++)
            {
                if (i % 2 != 0)
                    auxiliaryString += "+";
                else
                    auxiliaryString += " ";
            }
            return outputString = "+" + auxiliaryString.Trim() + "+";
        }
        private static string FirstChessString(string text, int n)
        {
            string outputString = default;
            for (int i = 0; i < (text.Length + n * 2); i++)
            {
                if (i % 2 == 0)
                    outputString += "+";
                else
                    outputString += " ";
            }
            return outputString;
        }
        private static string OutputString(string text, int n)
        {
            string auxiliaryString = default;
            for (int i = 0; i < n - 1; i++)
            {
                auxiliaryString += " ";
            }
            string outputString = "+" + auxiliaryString + text + auxiliaryString + "+";
            return outputString;
        }
        private static string AlmostEmptyString(string text, int n)
        {
            string emptyString = default;
            for (int i = 0; i < (text.Length + n * 2); i++)
            {
                if (i == 0 || i == (text.Length + n * 2) - 1)
                {
                    emptyString += "+";
                    continue;
                }
                emptyString += " ";
            }
            return emptyString;
        }
        private static string ContinuousBorder(string text, int n)
        {
            string border = default;
            for (int i = 0; i < (text.Length + n * 2); i++)
            {
                border += "+";
            }
            return border;
        }
        private static int UserInputNumber()
        {
            while (true)
            {
                Console.Write("Введите размерность таблицы: ");
                bool convertResult = int.TryParse(Console.ReadLine(), out int inputNumber);
                if (convertResult == false || inputNumber < 1 || inputNumber > 6)
                    continue;
                else
                    return inputNumber;
            }
        }
        private static string UserInputText()
        {
            string inputText;
            while (true)
            {
                Console.Write("Введите произвольный текст: ");
                if ((inputText = Console.ReadLine()) == string.Empty)
                    continue;
                else
                    return inputText;
            }
        }
    }
}
