using System;
using System.Linq;
using JsonToCsv.Interfaces;
using System.IO;

namespace JsonToCsv
{
    public class Arguments : IArguments
    {
        private readonly string[] _args;
        public string InputPathArgument { get; private set; } = "";
        public string OutputPathArgument { get; private set; } = "";
        public string SeparatorArgument { get; private set; } = ";";
        public string EncodeArgument { get; private set; } = "utf8";
        public string Message { get; private set; } = "";
        public bool IsQuit { get; private set; } = false;
        public bool IsNoMessages { get; private set; }
        public Arguments(string[] args)
        {
            _args = args;
            Parse();
            CheckInputFilePath();
            if (!IsQuit)
                CheckOutputFilePath();
        }
        private void Parse()
        {
            IsNoMessages = _args.Contains(Consts.NoMessageKey);

            for (int i = 0; i < _args.Length; i += 2)
            {
                if (i + 1 >= _args.Length)
                    break;
                switch (_args[i].ToLower())
                {
                    case Consts.InputPathKey:
                        InputPathArgument = GetArgument(_args[i + 1], InputPathArgument);
                        break;
                    case Consts.OutputPathKey:
                        OutputPathArgument = GetArgument(_args[i + 1], OutputPathArgument);
                        break;
                    case Consts.SeparatorKey:
                        SeparatorArgument = GetArgument(_args[i + 1], SeparatorArgument);
                        break;
                    case Consts.EncodeKey:
                        EncodeArgument = GetArgument(_args[i + 1], EncodeArgument).ToLower();
                        break;
                }
            }
        }
        private string GetArgument(string argument, string defaultArgument)
        {
            bool isKey = argument.Length <= Consts.MaxSizeKey && argument.Contains(Consts.KeySymbol);
            return isKey ? defaultArgument : argument;
        }
        private void CheckInputFilePath()
        {
            bool isNotExistFile = !File.Exists(InputPathArgument);
            if (!InputPathArgument.Contains(".json") || isNotExistFile)
            {
                Message += "Не найден входной *.json!" + Consts.EndOfLine
                    + "Завершение работы!";
                IsQuit = true;
            }
        }
        private void CheckOutputFilePath()
        {
            string path = "";
            if(!OutputPathArgument.Contains(".csv"))
            {
                bool isWrongName = OutputPathArgument.Length == 0;
                if (!isWrongName)
                    isWrongName = !char.IsLetterOrDigit(OutputPathArgument[^1]);

                if (isWrongName)
                    OutputPathArgument = Path.GetFileNameWithoutExtension(InputPathArgument);
                OutputPathArgument += ".csv";
            }
            path = Path.GetFullPath(OutputPathArgument);

            if (Directory.Exists(Path.GetDirectoryName(path)))
            {
                Message += $"Выходной файл: {path}{Consts.EndOfLine}";
            }
            else
            {
                Message += "Директории не существует!" + Consts.EndOfLine
                    + path + Consts.EndOfLine
                    + "Завершение работы!";
                IsQuit = true;
            }
        }
    }
}
