using System;
using TinyCompiler.Model;

namespace TinyCompiler.Controller
{
    class Scanner
    {

        Token current_token = new Token();

        public Token getToken()
        {
            string lexeme = "";
            TokenType type = TokenType.EndOfFile;
            State current_state = State.Start;
            while (current_state != State.Done)
            {
                char ch = getNextChar();
                switch (current_state)
                {
                    case State.Start:
                        Boolean success;
                        (current_state, success) = getNewState();
                        if (!success)
                        {
                            current_token = getSingleToken();
                            current_state = State.Done;
                        }
                        break;
                    case State.InSlash:
                        //todo law space -> division token
                        //else if '*' go to incomment
                        //else error
                        break;
                    case State.InComment:
                        //if '*' go to ending comment 
                        //else add to lexeme
                        break;
                    case State.EndingComment:
                        //if '/' endcomment else if '*' stay here 
                        //else go to incomment
                        break;
                    case State.Identifier:
                        current_token = getNumberToken();
                        current_state = State.Done;
                        break;
                    case State.Number:
                        current_token = getNumberToken();
                        current_state = State.Done;
                        break;
                    case State.String:
                        current_token = getStringToken();
                        current_state = State.Done;
                        break;

                    case State.Assignment:
                        current_state = State.Done;
                        if(ch == '=')
                        {
                            current_token.Type = TokenType.Assign;
                        }
                        else
                        {
                            //todo error
                        }
                        break;

                    case State.InAnd:
                        current_state = State.Done;
                        if (ch == '&')
                        {
                            current_token.Type = TokenType.BoolAnd;
                        }
                        else
                        {
                            //todo error
                        }
                        break;

                    case State.InNotEqual:
                        current_state = State.Done;
                        if (ch == '>')
                        {
                            current_token.Type = TokenType.IsNotEqual;
                        }
                        else
                        {
                            //todo error
                        }
                        break;

                    case State.InOR:
                        current_state = State.Done;
                        if (ch == '|')
                        {
                            current_token.Type = TokenType.BoolOR;
                        }
                        else
                        {
                            //todo error
                        }
                        break;
                }
            }
   
            //todo swich case/loop, set in it the type and lexeme

            current_token.Lexeme = lexeme;
            current_token.Type = type;
            if(current_token.Type == TokenType.Id)
            {
                setTypeIfReserved();
            }
            return current_token;
        }

        private Token getNumberToken()
        {
            throw new NotImplementedException();
        }

        private Token getStringToken()
        {
            throw new NotImplementedException();
        }

        private char getNextChar()
        {
            throw new NotImplementedException();
        }

        private Token getSingleToken()
        {
            throw new NotImplementedException();
        }

        private (State, Boolean) getNewState()
        {
            throw new NotImplementedException();
        }

        private void setTypeIfReserved()
        {
            foreach(string word in Token.RESERVED_WORDS.Keys)
            {
                if (current_token.Lexeme.Equals(word))
                {
                    current_token.Type = Token.RESERVED_WORDS[word];
                }
            }
        }
    }
}
