using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Word
    {
        string word;
        IList<char> _known;
        public string Known
        {
            get
            {
                var sb = new StringBuilder();
                foreach(char s in _known)
                {
                    if (s == default(char)) {
                        sb.Append("_");
                    }
                    else
                    {
                        sb.Append(s);
                    }
                }

                return sb.ToString();
            }
        }

        public Word(string word)
        {
            this.word = word;
            _known = new char[this.word.Length];
        }

        public bool CheckChar(char character)
        {
            bool valid = word.Contains(character) && !_known.Contains(character);
            if(valid)
            {
                FillChar(character);
            }

            return valid;
        }

        public bool TestCompletion()
        {
            return word == Known;
        }

        private void FillChar(char c)
        {
            for(int i = 0; i < word.Length; i++)
            {
                if (word[i] == c)
                    _known[i] = c;
            }
        }
    }
}
