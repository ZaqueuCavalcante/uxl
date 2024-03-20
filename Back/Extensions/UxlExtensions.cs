using System.Text;

namespace Uxl.Back.Extensions;

public static class UxlExtensions
{
    private const string CharacterSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    public static string ToBase62(this byte[] original)
    {
        var arr = Array.ConvertAll(original, t => (int)t);

        var converted = BaseConvert(arr, 256, 62);
        var builder = new StringBuilder();
        foreach (var t in converted)
        {
            builder.Append(CharacterSet[t]);
        }
        return builder.ToString();
    }

    private static int[] BaseConvert(int[] source, int sourceBase, int targetBase)
    {
        var result = new List<int>();
        var leadingZeroCount = Math.Min(source.TakeWhile(x => x == 0).Count(), source.Length - 1);
        int count;
        while ((count = source.Length) > 0)
        {
            var quotient = new List<int>();
            var remainder = 0;
            for (var i = 0; i != count; i++)
            {
                var accumulator = source[i] + remainder * sourceBase;
                var digit = accumulator / targetBase;
                remainder = accumulator % targetBase;
                if (quotient.Count > 0 || digit > 0)
                {
                    quotient.Add(digit);
                }
            }

            result.Insert(0, remainder);
            source = quotient.ToArray();
        }
        result.InsertRange(0, Enumerable.Repeat(0, leadingZeroCount));
        return result.ToArray();
    }
}
