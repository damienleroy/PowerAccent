namespace PowerAccent.Core.Extensions
{
    internal static class CharExtensions
    {
        public static char[] ToUpper(this char[] array)
        {
            char[] result = new char[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = Char.ToUpper(array[i]);
            }
            return result;
        }
    }
}
