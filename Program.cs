using System;

namespace Rollingadie
{
    class Program
    {
        static void Main(string[] args)
        {
            Roll dice = new Roll();
            Listener l = new Listener();
            l.Subscribe(dice);
            dice.StartRolling();
            Console.WriteLine("two sixes in a row : " + l.num + "times");
            Console.ReadKey();
        }
    }
}