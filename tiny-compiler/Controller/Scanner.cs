using System;
using System.Collections.Generic;
using TinyCompiler.Model;
using TinyCompiler.Model.Errors;

namespace TinyCompiler.Controller
{
    class Scanner
    {
        int count = 0;
        Token current_token = new Token();
        private Char SavedChar = '\0';
        private string lexeme;
        private string fileText;
        private int lineCount = 1;
        private int indexInCurrentLine = 0;
        public List<Token> getTokens()
        {
            List<Token> tokens = new List<Token>();

            Token currentToken = getSafeToken();
            while (currentToken.Type != TokenType.EndOfFile)
            {
                tokens.Add(currentToken);
                currentToken = getSafeToken();
            }
            return tokens;
        }
        public Token getSafeToken()
        {
            bool safe = false;
            Token t = null;
            while (!safe)
            {
                try
                {
                    t = getToken();
                    if (t.Type != TokenType.Comment)
                    {
                        safe = true;
                    }
                }
                catch (TokenizationException)
                {
                }
            }

            return t;
        }
        public Token getToken()
        {
            current_token = new Token();
            lexeme = "";
            Tuple<string, string> errorExpectedFound = new Tuple<string, string>("", "");
            State current_state = State.Start;
            while (current_state != State.Done && current_state != State.Error)
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
                            current_token.Type = TokenType.Comment;
                        }
                        else
                            current_state = State.InComment;
                        break;
                    case State.Identifier:
                        current_token.Type = TokenType.Id;
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
                        current_token.Type = TokenType.Integer;
                        if (char.IsDigit(ch))
                        {
                            lexeme += ch;
                        }
                        else if (ch == '.')
                        {
                            lexeme += ch;
                            current_state = State.intToFloat;
                        }
                        else
                        {
                            current_state = State.Done;
                            SavedChar = ch;
                        }
                        break;
                    case State.Float:
                        current_token.Type = TokenType.Float;
                        if (Char.IsDigit(ch))
                            lexeme += ch;
                        else
                        {
                            current_state = State.Done;
                            SavedChar = ch;
                        }
                        break;
                    case State.intToFloat:
                        current_token.Type = TokenType.Float;
                        current_state = State.Float;
                        if (Char.IsDigit(ch))
                            lexeme += ch;
                        else
                        {
                            current_state = State.Error;
                            errorExpectedFound = new Tuple<string, string>("number", ch.ToString());
                            SavedChar = ch;
                        }
                        break;
                    case State.String:
                        current_token.Type = TokenType.String;
                        if (ch == '"')
                            current_state = State.Done;
                        lexeme += ch;
                        break;

                    case State.Assignment:
                        current_token.Type = TokenType.Assign;
                        current_state = State.Done;
                        if (ch == '=')
                        {
                            lexeme += ch;
                            current_token.Type = TokenType.Assign;
                        }
                        else
                        {
                            SavedChar = ch;
                            errorExpectedFound = new Tuple<string, string>("=", ch.ToString());
                            current_state = State.Error;
                        }
                        break;

                    case State.InAnd:
                        current_token.Type = TokenType.BoolAnd;
                        current_state = State.Done;
                        if (ch == '&')
                        {
                            lexeme += ch;
                            current_token.Type = TokenType.BoolAnd;
                        }
                        else
                        {
                            SavedChar = ch;
                            errorExpectedFound = new Tuple<string, string>("&", ch.ToString());
                            current_state = State.Error;
                        }
                        break;

                    case State.InNotEqual:
                        current_state = State.Done;
                        if (ch == '>')
                        {
                            lexeme += ch;
                            current_token.Type = TokenType.IsNotEqual;
                        }
                        else
                        {
                            current_token.Type = TokenType.LessThan;
                            SavedChar = ch;
                        }
                        break;

                    case State.InOR:
                        current_token.Type = TokenType.BoolOR;
                        current_state = State.Done;
                        if (ch == '|')
                        {
                            lexeme += ch;
                            current_token.Type = TokenType.BoolOR;
                        }
                        else
                        {
                            SavedChar = ch;
                            errorExpectedFound = new Tuple<string, string>("|", ch.ToString());
                            current_state = State.Error;
                        }
                        break;
                }
            }

            if (current_state == State.Error)
            {
                throw new TokenizationException(lineCount, indexInCurrentLine, errorExpectedFound.Item1, errorExpectedFound.Item2);
            }

            current_token.Lexeme = lexeme;
            if (current_token.Type == TokenType.Id)
            {
                setTypeIfReserved();
            }
            current_token.lineNum = lineCount;
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
            indexInCurrentLine++;
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
                    {
                        state = State.Start;
                        if (c == '\n')
                        {
                            lineCount++;
                            indexInCurrentLine = 0;
                        }
                    }
                    else
                        foreach (string word in Token.SPECIAL_SYMBOLS.Keys)
                        {
                            if (c.ToString().Equals(word))
                            {
                                state = State.Done;
                                current_token.Type = Token.SPECIAL_SYMBOLS[word];
                            }
                        }
                    break;
            }
            if (state == State.Error)
            {
                throw new TokenizationException(lineCount, indexInCurrentLine, "nothing expected", c.ToString());
            }
            if (state != State.Start)
            {
                lexeme += c;
            }
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