using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace HW_05
{
    class Program
    {
        static List<string> temp = new List<string>(Console.ReadLine().Split(' '));

        static void Main(string[] args)
        {
            int userChoice;

            while (true)
            {
                Console.WriteLine("\n\tПоток простых чисел");
                Console.WriteLine("!!! Для остановки потока нажмите Esc !!!");
                Console.Write("Введите стартовое число: ");
                int.TryParse(Console.ReadLine(), out userChoice);
                Thread thread = new Thread(new ParameterizedThreadStart(GeneraterNumbers));
                thread.Start(userChoice);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    thread.Abort();
                    Console.WriteLine("Поток остановлен");
                }
                string path = @"C:\Test";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                Console.WriteLine("Получаем данные");
                string text = string.Join(" ", temp);

                using (FileStream fstream = new FileStream(@"C:\Test\note.txt", FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    fstream.Write(array, 0, array.Length);
                    Console.WriteLine("Данные записаны в файл");
                }
            }
        }

        static void GeneraterNumbers(object count)
        {
            int x = (int)count;
            while (x <= 29)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine(2 * x * (x++) + 29);
            }
        }
    }
}
