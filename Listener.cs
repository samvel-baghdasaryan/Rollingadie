using System;

namespace Rollingadie
{
    /// <summary>
    /// This class is for adding function to our events
    /// </summary>
    class Listener
    {
        //its first number of thrown die
        private int First { get; set; }
        //its second number of thrown die
        private int Second { get; set; }
        //number of two sixes in a row
        public int num = 0;

        /// <summary>
        /// Adding handlers to events
        /// </summary>
        /// <param name="d">Instance of Die</param>
        public void Subscribe(Roll d)
        {
            //event that triggered if die shows six two times in a row
            d.TwoSixes += new Roll.DieHandler(CountNumber);
            //event that triggered when sum of last 5 throws is greater than 20
            d.GreaterThanOrEqual20 += new Roll.DieHandler(GreaterEqual20);
        }
        //this function is called when sum of the numbers of last 5 throws is >= 20 
        private void GreaterEqual20(Roll d, EventArgs e)
        {
            Console.WriteLine("Sum of last 5 tosses is greater than or equal to 20");
        }
        //this function calculates the number of two sixes in a row
        private void CountNumber(Roll d, EventArgs e)
        {
            num++;
            Console.WriteLine("two Sixes in a row: ");
        }

    }
}
