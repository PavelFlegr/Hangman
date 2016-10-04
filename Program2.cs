using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman;

namespace Hangman
{
    class Program2
    {
        static Game g;
        static void Main(string[] Args)
        {
            var words = new List<string> { "jablko", "kostlivec", "zamek", "voda" };
            foreach(string word in words)
            {
                switch (StartGame(word))
                {
                    case Status.loss:
                        {
                            Console.WriteLine("You lost");
                            Console.ReadKey();
                            return;
                        }

                    case Status.win:
                        {
                            Console.WriteLine("You won");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Something went wrong");
                            Console.ReadKey();
                            return;
                        }
                }
                
            }
            Console.ReadKey(true);
        }

        static Status StartGame(string word)
        {
            g = new Game(word);
            Status status;
            Redraw();
            do
            {
                status = g.Next(GetInput());
                Redraw();
            } while (status == Status.neutral);

            return status;
        }

        static char GetInput()
        {
            return Console.ReadKey(true).KeyChar;
        }

        static void Redraw()
        {
            Console.Clear();
            Console.WriteLine("Life: {0}", g.Lives);
            Console.WriteLine(FormatWord(g.Word));
        }

        static string FormatWord(string word)
        {
            var sb = new StringBuilder();
            foreach (char c in word)
                sb.AppendFormat(" {0} ", c);
            return sb.ToString();
        }
    }
}
