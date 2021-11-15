namespace JsonToCsv
{
    public static class Consts
    {
        public const string KeySymbol = "-";
        public const string NoMessageKey = KeySymbol + "q",
            InputPathKey = KeySymbol + "i",
            OutputPathKey = KeySymbol + "o",
            SeparatorKey = KeySymbol + "s",
            EncodeKey = KeySymbol + "e";
        public const int MaxSizeKey = 2;
        public const string EndOfLine = "\r\n";
    }
}
