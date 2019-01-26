using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateModifier difference = new DateModifier();
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            Console.WriteLine(difference.DaysDifferenceCalc(date1, date2));
        }
    }
}