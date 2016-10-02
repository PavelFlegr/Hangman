using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static int lives;
        static string word;
        static char[] guesses;
        StringBuilder sb = new StringBuilder();
        static Random rnd = new Random();

       /* static void Main(string[] args)
        {
            Prepare();
            while (true)
            {
                Redraw();
                GetChar();
                CheckStatus();
            }
        }*/

        static void Prepare()
        {
            word = "test";
            lives = 5;
            int index = rnd.Next(word.Length - 1);
            guesses = new char[word.Length];
            for (int i = 0; i < guesses.Length; i++)
                guesses[i] = '-';
            FillChar(word[index]);
        }

        static void Redraw()
        {
            Console.Clear();
            Console.WriteLine("Lives: {0}", lives);
            Console.WriteLine(guesses);
        }

        static void GetChar()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            var character = key.KeyChar;
            if(word.Contains(character) && !guesses.Contains(character))
            {
                FillChar(character);
            }
            else
            {
                lives -= 1;
            }
        }

        static void CheckStatus()
        {
            if(lives == 0)
            {
                RoundEnd("You lose");
                Environment.Exit(0);
            }
            if (new string(guesses) == word)
            {
                RoundEnd("You win");
                Environment.Exit(0);
            }
        }

        static void FillChar(char c)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == c)
                {
                    guesses[i] = c;
                }
            }
        }

        static void RoundEnd(string message)
        {
            Redraw();
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
