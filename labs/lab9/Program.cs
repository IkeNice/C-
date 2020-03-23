using System;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string[] Strings = new string[255];
            Console.Write("Введите количество строк: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Strings[i] = Console.ReadLine();
            }
            Console.Write("Введите подстроку для поиска: ");
            string str_find = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                if (Strings[i].IndexOf(str_find) != -1)
                {
                    Console.WriteLine(i + 1 + ": " + Strings[i]);
                }
            }

        }
    }
}
