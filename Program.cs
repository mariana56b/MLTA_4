using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLTA_4
{
   internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Оберіть алгоритм для виконання:");
                Console.WriteLine("1. Визначення мінімальної кількості монет для заданої суми.");
                Console.WriteLine("2. Переведення числа з десяткової системи у двійкову.");
                Console.WriteLine("0. Вихід з програми.");
                Console.Write("Введіть номер алгоритму (1, 2 або 0 для виходу): ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 0))
                {
                    Console.WriteLine("Некоректний вибір. Будь ласка, введіть 1, 2 або 0.");
                    Console.Write("Спробуйте ще раз: ");
                }

                if (choice == 0)
                {
                    Console.WriteLine("Завершення програми...");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        ExecuteMinCoins();
                        break;
                    case 2:
                        ExecuteBinaryConversion();
                        break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в головне меню...");
                Console.ReadKey();
            }
        }

        static void ExecuteMinCoins()
        {
            int[] coins = { 1, 2, 3, 5 };

            Console.Write("Введіть суму, для якої потрібно знайти мінімальну кількість монет: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 1000)
            {
                Console.WriteLine("Будь ласка, введіть ціле число в діапазоні від 1 до 1000.");
                Console.Write("Спробуйте ще раз: ");
            }

            int result = MinCoins(coins, n);
            if (result != -1)
                Console.WriteLine("Мінімальна кількість монет для суми " + n + ": " + result);
            else
                Console.WriteLine("Неможливо скласти суму " + n + " із заданих номіналів.");
        }

        static void ExecuteBinaryConversion()
        {
            Console.Write("Введіть число для переведення у двійкову систему: ");
            int y;
            while (!int.TryParse(Console.ReadLine(), out y) || y < 1 || y > 10000)
            {
                Console.WriteLine("Будь ласка, введіть ціле число в діапазоні від 1 до 10000.");
                Console.Write("Спробуйте ще раз: ");
            }

            string binaryRepresentation = ConvertToBinary(y);
            Console.WriteLine("Двійкове представлення числа " + y + ": " + binaryRepresentation);
        }

        static int MinCoins(int[] coins, int n)
        {
            int[] minCoins = new int[n + 1];
            for (int i = 1; i <= n; i++)
                minCoins[i] = int.MaxValue;
            minCoins[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                foreach (int coin in coins)
                {
                    if (i >= coin && minCoins[i - coin] != int.MaxValue)
                    {
                        minCoins[i] = Math.Min(minCoins[i], minCoins[i - coin] + 1);
                    }
                }
            }

            return minCoins[n] == int.MaxValue ? -1 : minCoins[n];
        }

        static string ConvertToBinary(int n)
        {
            if (n == 0) return "0";

            string binary = "";
            while (n > 0)
            {
                binary = (n % 2) + binary;
                n /= 2; 
            }
            return binary;
        }
    }
}
