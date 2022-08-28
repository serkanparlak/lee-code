static void Main()
{
    Console.WriteLine(new Solution().RomanToInt("MCMXCIV"));
}

Main();

public class Solution
{
    private static Dictionary<char, short> dict = new Dictionary<char, short>
    {
        {'I',             1},
        {'V',             5},
        {'X',             10},
        {'L',             50},
        {'C',             100},
        {'D',             500},
        {'M',             1000}
    };

    public short RomanToInt(string s)
    {
        var chars = s.ToCharArray();
        short currentIndex = (short)(chars.Length - 1);
        short total = dict.GetValueOrDefault(chars.Last());
        while (currentIndex >= 0)
        {
            var currentKey = chars[currentIndex];
            var currentValue = dict.GetValueOrDefault(currentKey);
            var nextKey = currentIndex > 0 ? chars[currentIndex - 1] : '-';
            var nextValue = dict.GetValueOrDefault(nextKey);
            if (((currentKey == 'V' || currentKey == 'X') && nextKey == 'I') ||
                ((currentKey == 'L' || currentKey == 'C') && nextKey == 'X') ||
                ((currentKey == 'D' || currentKey == 'M') && nextKey == 'C'))
            {
                total -= nextValue;
            }
            else
            {
                total += nextValue;
            }
            currentIndex--;
        }
        return total;
    }
}

