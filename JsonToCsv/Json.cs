using System.IO;
using System.Text;
using System.Text.Json;
using JsonToCsv.Interfaces;

namespace JsonToCsv
{
    public class Json
    {
        private IArguments _arguments;
        public Json(IArguments arguments)
        {
            _arguments = arguments;
            Read();
        }
        private void Read()
        {
            string textFromFile = "";
            using (FileStream fstream = File.OpenRead(_arguments.InputPathArgument))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                textFromFile = Encoding.Default.GetString(array);
            }
            JsonDocument json = JsonDocument.Parse(textFromFile);
            JsonElement root = json.RootElement;
            Csv csv = new Csv(_arguments, root);
        }
    }
}
