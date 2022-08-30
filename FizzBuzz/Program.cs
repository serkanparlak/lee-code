// See https://aka.ms/new-console-template for more information
Console.WriteLine(Solution.FizzBuzz(4));

public class Solution
{
    public static IList<string> FizzBuzz(int n)
    {
        var list = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                list.Add("FizzBuzz");
            else if (i % 3 == 0)
                list.Add("Fizz");
            else if (i % 5 == 0)
                list.Add("Buzz");
            else
                list.Add(i.ToString());
        }
        return list;
    }
}