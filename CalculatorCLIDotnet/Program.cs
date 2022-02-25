using System;

namespace CalculatorCLIDotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Digite um número: ");
            float firstNumber = float.Parse(Console.ReadLine());
            Console.Write("Digite outro número: ");
            float secondNumber = float.Parse(Console.ReadLine());
            Menu(firstNumber, secondNumber);
        }

        static void Menu(float firstNumber, float secondNumber)
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Divisão");
            Console.WriteLine("4 - Multiplicação");
            Console.WriteLine("5 - Sair");

            Console.Write("Selecione uma opção: ");
            short res = short.Parse(Console.ReadLine());
            switch (res)
            {
                case 1: Sum(firstNumber, secondNumber); break;
                case 2: Subtract(firstNumber, secondNumber); break;
                case 3: Division(firstNumber, secondNumber); break;
                case 4: Multiplication(firstNumber, secondNumber); break;
                case 5: Environment.Exit(0); break;
                default: Menu(firstNumber, secondNumber); break;
            }
            System.Console.WriteLine();
            Console.ReadKey();
            Menu(firstNumber, secondNumber);
        }

        static void Sum(float n1, float n2)
        {
            var sum = n1 + n2;
            Console.WriteLine($"{n1} + {n2} = {sum}");
        }
        static void Subtract(float n1, float n2)
        {
            var sum = n1 - n2;
            Console.WriteLine($"{n1} - {n2} = {sum}");
        }
        static void Division(float n1, float n2)
        {
            var sum = n1 / n2;
            Console.WriteLine($"{n1} / {n2} = {sum}");
        }
        static void Multiplication(float n1, float n2)
        {
            var sum = n1 * n2;
            Console.WriteLine($"{n1} * {n2} = {sum}");
        }
    }
}
