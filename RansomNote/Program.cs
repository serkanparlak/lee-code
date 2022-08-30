Console.WriteLine(Solution.CanConstruct("aa", "aba"));

public class Solution
{
    public static bool CanConstruct(string ransomNote, string magazine)
    {
        foreach (var item in ransomNote.ToCharArray())
        {
            var index = magazine.IndexOf(item);
            if (index > -1)
                magazine = magazine.Remove(index, 1);
            else
                return false;
        }
        return true;
    }
}