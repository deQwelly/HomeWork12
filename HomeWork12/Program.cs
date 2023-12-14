using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork12
{
    internal class Program
    {
        public static void RandomInt()
        {
            Random rnd = new Random();
            Console.WriteLine(rnd.Next(1, 11));
        }

        public static int Factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }

        public static async Task FactAndSquare(int number)
        {
            await Task.Run(() => Console.WriteLine(Factorial(number)));
            Thread.Sleep(8000);
            Console.WriteLine(number * number);
        }

        async static Task Main(string[] args)
        {
            ///Задача 1
            Console.WriteLine("Задача 1: необходимо создать программу, где будет реализовано 3 потока. Каждый из потоков будет выводить на экран числа от 1 до 10");
            ThreadStart threadRandomInt = new ThreadStart(RandomInt);
            Thread thread1 = new Thread(threadRandomInt);
            Thread thread2 = new Thread(threadRandomInt);
            Thread thread3 = new Thread(threadRandomInt);

            thread1.Start();
            Thread.Sleep(10);
            thread2.Start();
            Thread.Sleep(10);
            thread3.Start();

            Thread.Sleep(10);


            ///Задача 2
            Console.WriteLine("\nЗадача 2: Необходимо создать программу, которая будет вычислять факториал от введенного числа и квадрат от введенного числа.\n" +
                "Вычисление факториала должно проходить\r\nасинхронно, вычисление возведения в квадрат синхронно.\n" +
                "В методе для вычислении факториала необходимо задержать поток на 8 с.");
            await FactAndSquare(5);

            ///Задача 3
            Console.WriteLine("\nЗадача 3: вернуть имена всех(!) методов, которые вы нашли для этого объекта.");
            Type refl_type = typeof(Refl);
            MethodInfo[] refl_methods =  refl_type.GetMethods();
            foreach (MethodInfo method in refl_methods)
            {
                Console.WriteLine($"{method.Name}");
            }
        }
    }
}
