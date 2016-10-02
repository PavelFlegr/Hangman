﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program2
    {
        static Game g;
        static void Main(string[] Args)
        {
            g = new Game("test");
            Status status;
            Redraw();
            do
            {
                status = g.Next(GetInput());
                Redraw();
            } while (status == Status.neutral);
        }

        static char GetInput()
        {
            return Console.ReadKey(true).KeyChar;
        }

        static void Redraw()
        {
            Console.Clear();
            Console.WriteLine("Life: {0}", g.Lives);
            Console.WriteLine(g.Word);
        }
    }
}