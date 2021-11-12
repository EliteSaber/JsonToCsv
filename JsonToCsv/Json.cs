using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonToCsv.Interfaces;

namespace JsonToCsv
{
    public class Json
    {
        private IArguments _arguments;
        public Json(IArguments arguments)
        {
            _arguments = arguments;
            Func();
        }
        private void Func()
        {
            string textFromFile = "";
            using (FileStream fstream = File.OpenRead(_arguments.InputPathArgument))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = Encoding.Default.GetString(array);
            }
            JsonDocument json = JsonDocument.Parse(textFromFile);
            JsonElement root = json.RootElement;
            var jsonArray = root.EnumerateArray();
            while (jsonArray.MoveNext())
            {
                var v = jsonArray.Current;
                //Console.WriteLine(v);
                var props = v.EnumerateObject();

                while (props.MoveNext())
                {
                    var prop = props.Current;
                    Console.WriteLine($"{prop.Name}: {prop.Value}");
                }
            }
        }
    }
}
