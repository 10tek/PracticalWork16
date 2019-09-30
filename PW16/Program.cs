using System;
using System.Collections.Generic;
using System.IO;

namespace PW16
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\repos\PracticalWork16\PW16\Text.txt";
            //var path = Console.ReadLine();
            var symbols = new Dictionary<string, int>();
            File.CreateText(path).Close();
            using (var stream = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                stream.WriteLine("Galymzhan");
                stream.WriteLine("Oralbayev   ");
                stream.WriteLine("19 y.o");
            }

            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                var bytes = 0;
                for (int i = 0; i < stream.Length; i++)
                {
                    bytes = stream.ReadByte();
                    var symbol = ((char)bytes).ToString();
                    if (symbol == "\n")
                    {
                        symbol = "Переход в новую строку";
                    }
                    else if(symbol == " ")
                    {
                        symbol = "Пробел";
                    }
                    else if (symbol == "\r")
                    {
                        symbol = "Возврат каретки в 0";
                    }
                    if (!symbols.ContainsKey(symbol))
                    {
                        symbols.Add(symbol, 0);

                    }
                    symbols[symbol]++;
                }

                foreach (var symbol in symbols)
                {
                    Console.WriteLine($"{symbol.Key} - {symbol.Value}");
                }
            }




        }
    }
}
