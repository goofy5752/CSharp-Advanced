namespace Generic_Box_of_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine(new Box<string>(Console.ReadLine()));
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine(new Box<int>(int.Parse(Console.ReadLine())));
            //}

            var items = new List<string>();

            for (int i = 0; i < n + 1; i++)
            {
                items.Add(Console.ReadLine());
            }

            var itemToCompare = items[items.Count - 1];

            items.RemoveAt(items.Count - 1);

            var box = new Box<string>(items);

            Console.WriteLine(box.CompareItems(items[items.Count - 1]));
        }
    }
}