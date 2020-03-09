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
    NumInt,
    NumFloat,

    //reserved words
    If, 
    Then, 
    Else, 
    ElseIf, 
    End, 
    Repeat,
    Until, 
    Read,
    Write,
    Return,
    EndLine,
    
    // data type
    String,
    Integer,
    Float,

    //conditional operators
    LessThan,
    GreaterThan,
    IsEqual,
    IsNotEqual,

    //arithmetic operators
    Plus,
    Minus,
    Mult,
    Division,

    Comma,
    BracketLeft,
    BracketRight,
    SemiColon,

    //todo boolean operators 
    BoolOR,
    BoolAnd,
    
    Assign //todo
}

enum State
{
    Identifier,
    Assignment,
    InOR,
    InAnd,
    InNotEqual,
    Number,
    String,
    Start,
    Done,
    InComment, 
    InSlash,
    EndingComment
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
                { "elseif" , TokenType.ElseIf}, 
                { "end" , TokenType.End}, 
                { "repeat" , TokenType.Repeat}, 
                { "until" , TokenType.Until}, 
                { "return" , TokenType.Return}, 
                { "endl" , TokenType.EndLine}, 
                { "read" , TokenType.Read}, 
                { "write" , TokenType.Write},
                { "string" , TokenType.String},
                { "int" , TokenType.Integer},
                { "float" , TokenType.Float}
            };

        public readonly static Dictionary<string, TokenType> SPECIAL_SYMBOLS = 
            new Dictionary<string, TokenType>{
                { "=", TokenType.IsEqual},
                { "<", TokenType.LessThan},
                { ">", TokenType.GreaterThan},
                { "+", TokenType.Plus},
                { "-", TokenType.Minus},
                { "*", TokenType.Mult},
                { "/", TokenType.Division},
                { ",", TokenType.Comma},
                { "(", TokenType.BracketLeft},
                { ")", TokenType.BracketRight},
                { ";", TokenType.SemiColon},
                { "<>", TokenType.IsNotEqual},
                { "&&", TokenType.BoolAnd},
                { "||", TokenType.BoolOR}
            };

        public TokenType Type { get; set; }
        public int Value { get; set; }
        public string Lexeme { get; set; }
    }
}
