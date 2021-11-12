using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToCsv.Interfaces
{
    public interface IArguments
    {
        public bool IsQuit { get; }
        public string InputPathArgument { get; }
        public string OutputPathArgument { get; }
        public string SeparatorArgument { get;  }
        public string EncodeArgument { get; }
    }
}
