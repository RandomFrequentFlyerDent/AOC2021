namespace Answers.Utilities
{
    public static class Extensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }

        public static List<T> Copy<T>(this List<T> original)
        {
            var copy = new List<T>();
            original.ForEach(t => copy.Add(t));
            return copy;
        }
    }
}
