using System.Linq;
using System.Text;
using System.Text.Json;
using JsonToCsv.Interfaces;
using System.IO;

namespace JsonToCsv
{
    public class Csv
    {
        private readonly string[] _windows1251 = { "windows1251", "1251", "win1251", "windows-1251", "win-1251" };
        private readonly IArguments _arguments;
        private readonly JsonElement _root;
        private string _csv;
        
        public Csv(IArguments arguments, JsonElement root)
        {
            _arguments = arguments;
            _root = root;
            MakeCsvString();
            Write();
        }
        private void MakeCsvString()
        {
            bool isOnlyName = true;
            _csv = GetItemsFromJson(isOnlyName);
            _csv += GetItemsFromJson();
            _csv = _csv.Trim();
        }
        private string GetItemsFromJson(bool isOnlyName = false)
        {
            var jsonArray = _root.EnumerateArray();
            string csv = "";
            while (jsonArray.MoveNext())
            {
                var block = jsonArray.Current;
                var blockArray = block.EnumerateObject();

                while (blockArray.MoveNext())
                {
                    var line = blockArray.Current;
                    if (isOnlyName)
                        csv += line.Name;
                    else
                        csv += line.Value;
                    csv += _arguments.SeparatorArgument;
                }
                csv = csv[0..^1] + Consts.EndOfLine;
                
                if (isOnlyName)
                    break;
            }
            jsonArray.Reset();
            return csv;
        }
        private void Write()
        {
            bool isAppend = false;
            using (StreamWriter sw = new StreamWriter(_arguments.OutputPathArgument, isAppend, GetEncoding()))
            {
                sw.WriteLine(_csv);
            }
        }
        private Encoding GetEncoding()
        {
            Encoding encoding = Encoding.Default;
            var comparisons = _windows1251.Where(x => _arguments.EncodeArgument.Equals(x)).Count();
            if (comparisons > 0)
                encoding = Encoding.GetEncoding(1251);
            return encoding;
            
        }
    }
}
