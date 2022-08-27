static void Main()
{
    Console.WriteLine(new Solution().RomanToInt("MMCDXXV"));
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
        short index = (short)(chars.Length - 1);
        short total = 0;
        short anchorTotal = 0;
        char ancher;
        while (index >= 0)
        {
            ancher = chars[index];
            var anchorValue = dict.GetValueOrDefault(ancher);
            if (index == 0)
            {
                total += anchorValue;
                break;
            }
            if (index < chars.Length - 1 && anchorValue == dict.GetValueOrDefault(chars[index + 1]))
            {
                total += anchorValue;
                index--;
                continue;
            }
            var currentValue = dict.GetValueOrDefault(chars[index - 1]);
            anchorTotal = anchorValue;
            while (anchorValue == currentValue)
            {
                if (--index == 0) break;
                anchorTotal += currentValue;
                currentValue = dict.GetValueOrDefault(chars[index - 1]);
            }
            if (anchorValue > currentValue)
            {
                anchorTotal -= currentValue;
            }
            else
            {
                anchorTotal += currentValue;
            }
            total += anchorTotal;
            index -= 2;
        }
        return total;
    }
}

