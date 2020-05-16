namespace TinyCompiler.Model.Errors
{
    class TokenizationException : CompilationExpection
    {
        public TokenizationException(int lineCount, int indexInCurrentLine, string expected, string found)
        : base($"syntax error in line {lineCount} at {indexInCurrentLine} found '{found}', expecting a '{expected}'")
        {
            CompilationExpection.getErrorList().Add(this);
        }
    }
}
