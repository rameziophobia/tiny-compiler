using System;
using System.Collections.Generic;

namespace TinyCompiler.Model
{
    class Error : Exception
    {
        private static List<Error> ErrorList = new List<Error>();
        private Error(int lineCount, int indexInCurrentLine, string expected, string found) : base($"syntax error in line {lineCount} at {indexInCurrentLine} found '{found}', expecting a '{expected}'") { }
        private Error(Token token, TokenType expected) : base($"Unexpected Token: {token.Lexeme}, Expected: {expected}") { }
        public Error(Token token) : base($"Unexpected Token: {token.Lexeme}") { }

        public static List<Error> getErrorList()
        {
            return ErrorList;
        }
        public static void clearErrorList()
        {
            ErrorList = new List<Error>();
        }
        public class TokenizationException : Error
        {
            public TokenizationException(int lineCount, int indexInCurrentLine, string expected, string found)
            : base(lineCount, indexInCurrentLine, expected, found)
            {
                ErrorList.Add(this);
            }
        }
        public class InvalidSyntaxException : Error
        {
            public InvalidSyntaxException(Token token, TokenType expected) : base(token, expected)
            {
                ErrorList.Add(this);
            }
            public InvalidSyntaxException(Token token) : base(token)
            {
                ErrorList.Add(this);
            }
        }
    }
    //TODO add more Exception types
    //TODO each Excepiton will be displayed diffrently by the GUI
}