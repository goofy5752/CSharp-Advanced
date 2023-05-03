using System.Text;

namespace Generic_Swap_Method_Strings
{
    public class GenericSwap<T>
    {
        public GenericSwap(List<T> value) 
        {
            this.Values = value;
        }

        public List<T> Values { get; set; } = new List<T>();

        public List<T> SwapValues(int firstIndex, int secondIndex)
        {
            var firstItem = this.Values[firstIndex];
            var secondItem = this.Values[secondIndex];

            Values[firstIndex] = secondItem;
            Values[secondIndex] = firstItem;

            return Values;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in Values)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString();
        }
    }
}
