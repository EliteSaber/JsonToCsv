using JsonToCsv.Interfaces;
using System;
using System.Text;

namespace JsonToCsv
{
    public class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            IArguments arguments = new Arguments(args);
            if (arguments.IsQuit)
            {
                if (!arguments.IsNoMessages)
                {
                    Console.WriteLine(arguments.Message);
                    Console.ReadKey();
                }
                return;
            }
            Json jsonFile = new Json(arguments);

            if (!arguments.IsNoMessages)
            {
                Console.WriteLine(arguments.Message + "Конвертирование прошло успешно!");
                Console.ReadKey();
            }
        }
    }
}
