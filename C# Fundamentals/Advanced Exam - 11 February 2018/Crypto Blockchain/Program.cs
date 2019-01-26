using System;
using System.Text.RegularExpressions;

namespace Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternCurly = @"{.*\d{3}.*}";
            string patternSquare = @"\[.*\d{3}.*]";
            string fullInput = "";

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                fullInput += Console.ReadLine();
            }

            MatchCollection matchCurly = Regex.Matches(fullInput, patternCurly);
            MatchCollection matchSquare = Regex.Matches(fullInput, patternSquare);
            char[] squareArr = new char[matchSquare.Count];
            char[] curlyArr = new char[matchCurly.Count];
            string squareNums = "";
            string curlyNums = "";
            foreach (Match item in matchSquare)
            {
                squareArr = item.Value.ToCharArray();
            }
            foreach (Match item in matchCurly)
            {
                curlyArr = item.Value.ToCharArray();
            }
            foreach (var item in squareArr)
            {
                if (item >= 48 && item <= 57)
                {
                    squareNums += item;
                }
            }
            foreach (var item in curlyArr)
            {
                if (item >= 48 && item <= 57)
                {
                    curlyNums += item;
                }
            }
            int counter = 0;
            if (curlyNums.Length % 3 == 0)
            {
                string num = "";
                for (int i = 0; i < curlyNums.Length; i++)
                {
                    num += curlyNums[i];
                    counter++;
                    if (counter == 3)
                    {
                        int realNum = int.Parse(num);
                        char c = Convert.ToChar(realNum - curlyArr.Length);
                        Console.Write(c);
                        counter = 0;
                        num = "";
                    }
                }
            }
            if (squareNums.Length % 3 == 0)
            {
                string num = "";
                for (int i = 0; i < squareNums.Length; i++)
                {
                    num += squareNums[i];
                    counter++;
                    if (counter == 3)
                    {
                        int realNum = int.Parse(num);
                        char c = Convert.ToChar(realNum - squareArr.Length);
                        Console.Write(c);
                        counter = 0;
                        num = "";
                    }
                }
            }
        }
    }
}