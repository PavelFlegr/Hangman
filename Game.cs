using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Hangman
{
    class Game
    {
        Word _word;
        public string Word
        {
            get
            {
                return _word.Known;
            }
        }
        public int Lives { get; private set; }

        public Game(string word)
        {
            _word = new Word(word);
            Lives = 5;
        }

        public Status Next(char c)
        {
            CheckInput(c);
            return CheckStatus();
        }

        void CheckInput(char c)
        {
            if (!_word.CheckChar(c))
                Lives--;

        }

        Status CheckStatus()
        {
            if(Lives == 0)
                return Status.loss;

            if(_word.TestCompletion())
                return Status.win;

            return Status.neutral;
        }
    }
}
