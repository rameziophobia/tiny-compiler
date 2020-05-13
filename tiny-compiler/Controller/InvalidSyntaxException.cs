using TinyCompiler.Model;

namespace TinyCompiler.Controller
{
    [System.Serializable]
    class InvalidSyntaxException : System.Exception
    {
        public InvalidSyntaxException(Token token, TokenType expected) : base($"Unexpected Token: {token.Lexeme}, Expected: {expected}") { }
        public InvalidSyntaxException(Token token) : base($"Unexpected Token: {token.Lexeme}") { }
    }
}
