using System;
using System.Collections.Generic;
using TinyCompiler.Model;

namespace TinyCompiler.Controller
{
    class Scanner
    {
        int count = 0;
        Token current_token = new Token();
        private Char SavedChar = '\0';
        private string lexeme;
        private string fileText;

        public List<Token> getTokens()
        {
            List<Token> tokens = new List<Token>();
            Token currentToken = getToken();
            while (currentToken.Type != TokenType.EndOfFile)
            {
                tokens.Add(currentToken);
            }
            return tokens;
        }

        public Token getToken()
        {
            lexeme = "";
            //todo TokenType type = TokenType.EndOfFile;
            State current_state = State.Start;
            while (current_state != State.Done)
            {
                char ch;
                if (SavedChar != '\0')
                {
                    ch = SavedChar;
                    SavedChar = '\0';
                }
                else
                {

                    char? temp = getNextChar();
                    if (temp is null)
                    {
                        Token endOfFileToken = new Token();
                        endOfFileToken.Type = TokenType.EndOfFile;
                        return endOfFileToken;
                    }
                    ch = temp.GetValueOrDefault();
                }
                switch (current_state)
                {
                    case State.Start:
                        current_state = getNewState(ch);
                        break;
                    case State.InSlash:
                        if (ch == '*')
                            current_state = State.InComment;
                        else
                        {
                            current_token.Type = TokenType.Division;
                            current_state = State.Done;
                            SavedChar = ch;
                        }
                        break;
                    case State.InComment:
                        if (ch == '*')
                            current_state = State.EndingComment;
                        break;
                    case State.EndingComment:
                        if (ch == '*')
                            continue;
                        else if (ch == '/')
                        {
                            current_state = State.Done;
                        }
                        else
                            current_state = State.InComment;
                        break;
                    case State.Identifier:
                        if (char.IsLetterOrDigit(ch))
                        {
                            lexeme += ch;
                            continue;
                        }
                        else
                        {
                            current_state = State.Done;
                            SavedChar = ch;
                        }
                        break;
                    case State.Int:
                        if (char.IsDigit(ch))
                        {
                            lexeme += ch;
                        }
                        else if (ch == '.')
                        {
                            lexeme += ch;
                            current_state = State.Float;
                        }
                        else
                        {
                            current_state = State.Done;
                            SavedChar = ch;
                        }
                        break;
                    case State.Float:
                        if (Char.IsDigit(ch))
                            lexeme += ch;
                        else
                        {
                            current_state = State.Done;
                            SavedChar = ch;
                        }
                        break;
                    case State.String:
                        if (ch == '"')
                            current_state = State.Done;
                        lexeme += ch;
                        break;

                    case State.Assignment:
                        current_state = State.Done;
                        if (ch == '=')
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


            current_token.Lexeme = lexeme;
            if (current_token.Type == TokenType.Id)
            {
                setTypeIfReserved();
            }
            return current_token;
        }
        public Scanner(string fileText)
        {
            this.fileText = fileText;
        }
        private char? getNextChar()
        {
            if (count >= fileText.Length)
                return null;
            char thisChar = fileText[count];
            count++;
            return thisChar;
        }

        private State getNewState(Char c)
        {
            State state = State.Error;
            switch (c)
            {
                case '/':
                    state = State.InSlash;
                    break;
                case '<':
                    state = State.InNotEqual;
                    break;
                case '&':
                    state = State.InAnd;
                    break;
                case '|':
                    state = State.InOR;
                    break;
                case ':':
                    state = State.Assignment;
                    break;
                case '"':
                    state = State.String;
                    break;
                default:
                    if (Char.IsLetter(c))
                        state = State.Identifier;
                    else if (Char.IsDigit(c))
                        state = State.Int;
                    else if (c == ' ' || c == '\t' || c == '\n')
                    { //TODO check if it catches all white space conditions
                        state = State.Start;
                    }
                    else
                        foreach (string word in Token.SPECIAL_SYMBOLS.Keys)
                        {
                            if (c.Equals(word))
                            {
                                state = State.Done;
                                current_token.Type = Token.SPECIAL_SYMBOLS[word];
                            }
                        }
                    break;
            }
            if (state != State.Error && state != State.Start)
                lexeme += c;
            return state;
        }

        private void setTypeIfReserved()
        {
            foreach (string word in Token.RESERVED_WORDS.Keys)
            {
                if (current_token.Lexeme.Equals(word))
                {
                    current_token.Type = Token.RESERVED_WORDS[word];
                }
            }
        }
    }
}
