using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonToCsv.Interfaces;

namespace JsonToCsv
{
    public class Arguments : IArguments
    {
        private string[] _args;
        public const string KeySymbol = "-";
        public const string QuitKey = KeySymbol + "q",
            InputPathKey = KeySymbol + "i",
            OutputPathKey = KeySymbol + "o",
            SeparatorKey = KeySymbol + "s",
            EncodeKey = KeySymbol + "e";
        public bool IsQuit { get; private set; }
        public string InputPathArgument { get; private set; }
        public string OutputPathArgument { get; private set; }
        public string SeparatorArgument { get; private set; }
        public string EncodeArgument { get; private set; }
        public Arguments(string[] args)
        {
            _args = args;
            Parse();
        }
        private void Parse()
        {
            if (_args.Contains(QuitKey))
            {
                IsQuit = true;
                return;
            }

            for (int i = 0; i < _args.Length; i += 2)
            {
                if (i + 1 >= _args.Length)
                    break;
                switch (_args[i])
                {
                    case InputPathKey:
                        InputPathArgument = GetArgument(_args[i + 1]);
                        break;
                    case OutputPathKey:
                        OutputPathArgument = GetArgument(_args[i + 1]);
                        break;
                    case SeparatorKey:
                        SeparatorArgument = GetArgument(_args[i + 1]);
                        break;
                    case EncodeKey:
                        EncodeArgument = GetArgument(_args[i + 1]);
                        break;
                }
            }
        }
        private string GetArgument(string argument) => argument.Contains(KeySymbol) ? "" : argument;
    }
}
