using System;
using System.Collections.Generic;

namespace Rollingadie
{/// <summary>
/// Class Roll
/// </summary>
    class Roll
    {
        public EventArgs e = null;
        public delegate void DieHandler(Roll d, EventArgs e);
        public event DieHandler TwoSixes;
        public event DieHandler GreaterThanOrEqual20;
        public int Number;
        public Random rnd = new Random();
        private int First { get; set; }
        private int Second { get; set; }
        private int k = 0;
        private int i = 0;
        private int count = 0;
        //Array of the last 5 throws
        private List<int> ThrowsResult = new List<int>();

        /// <summary>
        /// Roll constructor
        /// </summary>
        public Roll()
        {
            for (int i = 0; i < 5; ++i)
            {
                //initializing array
                ThrowsResult.Add(-25);
            }
        }

        //rolling a die
        public void StartRolling()
        {
            while (count < 50)
            {
                System.Threading.Thread.Sleep(500);

                //get die result
                Number = rnd.Next(1, 7);
                ThrowsResult[count % 5] = Number;

                //printing that number
                Console.WriteLine(Number);

                if (TwoSixesInRow())
                {
                    TwoSixes?.Invoke(this, e);
                }
                if (count % 5 == 4)
                {
                    if (GreaterThanOrEqual())
                    {
                        GreaterThanOrEqual20?.Invoke(this, e);
                    }
                }
                count++;
            }
        }
        /// <summary>
        /// returns true if we throw two sixes in a row
        /// </summary>
        /// <returns></returns>
        public bool TwoSixesInRow()
        {
            if (i == 0)
            {
                First = Number;
                i = 1;
            }
            else
            {
                Second = Number;
                // we throw two sixes in a row 
                if (First == 6 && Second == 6)
                {
                    i = 1;
                    return true;
                }
                else
                {
                    First = Second;
                    i = 1;
                }
            }
            return false;
        }
        /// <summary>
        /// returns true if sum of numbers of last 5 throws is >= 20
        /// </summary>
        /// <returns></returns>
        public bool GreaterThanOrEqual()
        {
            int sum = 0;

            for (int i = 0; i < 5; ++i)
            {
                //sum is sum of last 5 throws
                sum += ThrowsResult[i];
            }

            if (sum >= 20)
            {
                return true;
            }
            return false;
        }
    }
}
