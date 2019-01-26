using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var allSociety = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] societyInfo = Console.ReadLine().Split();
                if (societyInfo.Length == 4)
                {
                    string name = societyInfo[0];
                    int age = int.Parse(societyInfo[1]);
                    string id = societyInfo[2];
                    string birthday = societyInfo[3];
                    allSociety.Add(new Citizen(name, age, id, birthday));
                }
                else
                {
                    string name = societyInfo[0];
                    int age = int.Parse(societyInfo[1]);
                    string group = societyInfo[2];
                    allSociety.Add(new Rebel(name, age, group));
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                foreach (var item in allSociety)
                {
                    if (item.Name == input)
                    {
                        item.BuyFood();
                    }
                }
            }
            int food = 0;
            foreach (var item in allSociety)
            {
                food += item.Food;
            }
            Console.WriteLine(food);
        }
    }
}