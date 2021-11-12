using JsonToCsv.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JsonToCsv
{
    public class Program
    {
        static void Main(string[] args)
        {
            IArguments arguments = new Arguments(args);
            if (arguments.IsQuit)
                return;
            Json jsonFile = new Json(arguments);

            Console.WriteLine("Hello World!");
        }
    }
}
