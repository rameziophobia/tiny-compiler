using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCompiler.Model
{
    static class Error
    {
        private static List<String> ErrorList = null;
        public static List<String> getErrorList()
        {
            if (ErrorList == null)
                ErrorList = new List<String>();
            return ErrorList;
        }
        public class TokenizationException : Exception
        {
            public TokenizationException(int lineCount, int indexInCurrentLine, string expected, string found)
            : base($"syntax error in line {lineCount} at {indexInCurrentLine} found '{found}', expecting a '{expected}'")
            {
            }
        }
        //TODO add more Exception types
        //TODO each Exception will on creation will add itself to the list <- maybe not...
        //TODO each Excepiton will be displayed diffrently by the GUI
    }
}