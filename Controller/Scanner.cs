using TinyCompiler.Model;

namespace TinyCompiler.Controller
{
    class Scanner
    {
        
        public Token getToken()
        {
            string lexeme = "";
            TokenType type = TokenType.EndOfFile;
            Token token = new Token();
            //todo swich case/loop, set in it the type and lexeme

            token.Lexeme = lexeme;
            token.Type = type;
            if(token.Type == TokenType.Id)
            {
                setTypeIfReserved(token);
            }
            return token;
        }

        private void setTypeIfReserved(Token token)
        {
            foreach(string word in Token.RESERVED_WORDS.Keys)
            {
                if (token.Lexeme.Equals(word))
                {
                    token.Type = Token.RESERVED_WORDS[word];
                }
            }
        }
    }
}
