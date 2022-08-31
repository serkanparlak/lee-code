// See https://aka.ms/new-console-template for more information
Console.WriteLine(Solution.LengthOfLongestSubstring("pwwkew"));


public class Solution
{
    public static int LengthOfLongestSubstring(string s)
    {
        var record = 0;
        var bag = new List<char>();
        foreach (var c in s)
        {
            if (!bag.Contains(c))
                bag.Add(c);
            else
            {
                if (record < bag.Count)
                    record = bag.Count;
                var index = bag.IndexOf(c);
                for (int i = 0; i <= index; i++)
                {
                    bag.RemoveAt(0);
                }
                bag.Add(c);
            }
        }
        if (record < bag.Count)
            record = bag.Count;
        return record;
    }
}