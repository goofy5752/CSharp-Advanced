namespace Generic_Box_of_String
{
    public class Box<T> where T : IComparable
    {
        public T Result { get; set; }

        public List<T> Items { get; set; }

        public Box(T value)
        {
            this.Result = value;
        }

        public Box(List<T> items)
        {
            this.Items = items;
        }

        public int CompareItems(T value)
        {
            int counter = 0;

            foreach (T item in Items)
            {
                if (item.CompareTo(value) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {Result}" + Environment.NewLine;
        }
    }
}
