using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerConfiguration serverConfiguration = new ServerConfiguration();
            Dictionary<string, List<string>> tableColInfo = new Dictionary<string, List<string>>();
            Console.WriteLine("CSV Extraction Program");
            Console.WriteLine("======================");
            serverConfiguration.SetUpTableAndColumn(tableColInfo);
            Console.ReadLine();
        }
    }
}
