namespace TinyCompiler.Model.Errors
{

    class InvalidSyntaxException : CompilationExpection
    {
        public InvalidSyntaxException(Token token, TokenType expected) : base($"Line: {token.lineNum} Unexpected Token: {token.Lexeme}, Expected: {expected}")
        {
            getErrorList().Add(this);
        }
        public InvalidSyntaxException(Token token) : base($"Line: {token.lineNum} Unexpected Token: {token.Lexeme}")
        {
            getErrorList().Add(this);
        }
    }
}
