namespace JsonToCsv.Interfaces
{
    public interface IArguments
    {
        public bool IsNoMessages { get; }
        public bool IsQuit { get; }
        public string Message { get; }
        public string InputPathArgument { get; }
        public string OutputPathArgument { get; }
        public string SeparatorArgument { get;  }
        public string EncodeArgument { get; }
    }
}
