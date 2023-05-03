namespace Generic_Swap_Method_Strings
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToList();

            var swap = new GenericSwap<string>(list);

            swap.SwapValues(indexes[0], indexes[1]);

            Console.WriteLine(swap.ToString());
        }
    }
}