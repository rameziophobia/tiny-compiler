using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum TokenType
{
    Id,
    EndOfFile,
    Error,
    Num,
    If, 
    Then, 
    Else, 
    End, 
    Repeat,
    Until, 
    Read,
    Write,
    Equal
    //todo +special symbols =, <, * etc
}

enum State
{
    Start,
    Comment //todo lesa 7aba stateskaman
}

namespace TinyCompiler.Model
{
    class Token
    {
        public readonly static Dictionary<string, TokenType> RESERVED_WORDS = 
            new Dictionary<string, TokenType>{
                { "if" , TokenType.If}, 
                { "then" , TokenType.Then}, 
                { "else" , TokenType.Else}, 
                { "end" , TokenType.End}, 
                { "repeat" , TokenType.Repeat}, 
                { "until" , TokenType.Until}, 
                { "read" , TokenType.Read}, 
                { "write" , TokenType.Write}
            };

        public readonly static Dictionary<string, TokenType> SPECIAL_SYMBOLS = 
            new Dictionary<string, TokenType>{
                { "=", TokenType.Equal },
                { "=", TokenType.Equal },
                { "=", TokenType.Equal },
                { "=", TokenType.Equal },
                { "=", TokenType.Equal },
                { "=", TokenType.Equal } //todo complete this
            };

        public TokenType Type { get; set; }
        public int Value { get; set; }
        public string Lexeme { get; set; }
    }
}
