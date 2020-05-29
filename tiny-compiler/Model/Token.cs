using System.Collections.Generic;

namespace TinyCompiler.Model
{
    class Token
    {
        public readonly static Dictionary<string, TokenType> RESERVED_WORDS =
            new Dictionary<string, TokenType>{
                { "until" , TokenType.Until},
                { "return" , TokenType.Return},
                { "then" , TokenType.Then},
                { "if" , TokenType.If},
                { "repeat" , TokenType.Repeat},
                { "endl" , TokenType.EndLine},
                { "float" , TokenType.FloatType},
                { "read" , TokenType.Read},
                { "write" , TokenType.Write},
                { "string" , TokenType.StringType},
                { "int" , TokenType.IntegerType},
                { "end" , TokenType.End},
                { "else" , TokenType.Else},
                { "elseif" , TokenType.ElseIf}
            };

        public readonly static Dictionary<string, TokenType> SPECIAL_SYMBOLS =
            new Dictionary<string, TokenType>{
                { "(", TokenType.BracketLeft},
                { ")", TokenType.BracketRight},
                { "+", TokenType.Plus},
                { "=", TokenType.IsEqual},
                { "<", TokenType.LessThan},
                { "&&", TokenType.BoolAnd},
                { ",", TokenType.Comma},
                { "{", TokenType.BraceLeft},
                { "}", TokenType.BraceRight},
                { ";", TokenType.SemiColon},
                { ">", TokenType.GreaterThan},
                { "<>", TokenType.IsNotEqual},
                { "-", TokenType.Minus},
                { "*", TokenType.Mult},
                { "/", TokenType.Division},
                { "||", TokenType.BoolOR}
            };

        public int lineNum { get; set; }

        public TokenType Type { get; set; }
        public int Value { get; set; }
        public string Lexeme { get; set; }
    }
}


enum TokenType
{
    Comment,
    StringType,
    Division,
    Comma,
    BracketLeft,
    Else,
    ElseIf,
    End,
    Write,
    IntegerType,
    FloatType,
    Repeat,
    Until,
    Read,
    IsNotEqual,
    Error,
    NumInt,
    Id,
    BracketRight,
    EndOfFile,
    BraceLeft,
    BraceRight,
    NumFloat,
    If,
    Then,
    Plus,
    Minus,
    Mult,
    SemiColon,
    BoolOR,
    BoolAnd,
    Assign,
    Return,
    EndLine,
    String,
    Integer,
    Float,
    LessThan,
    GreaterThan,
    IsEqual
}

enum State
{
    intToFloat,
    InAnd,
    InOR,
    Start,
    Error,
    Done,
    InComment,
    InSlash,
    Int,
    Float,
    InNotEqual,
    EndingComment,
    Assignment,
    String,
    Identifier
}

