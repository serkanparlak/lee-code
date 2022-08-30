using System.Text;
var arr1 = new[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
var arr2 = new[] { 4, 6, 5 };
var l1 = arr1.Aggregate<int, ListNode>(null, (list, current) => new ListNode(current, list));
var l2 = arr2.Aggregate<int, ListNode>(null, (list, current) => new ListNode(current, list));

// See https://aka.ms/new-console-template for more information
Console.WriteLine(Solution.AddTwoNumbers(l1, l2));

public class Solution
{
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        StringBuilder l1str = new StringBuilder();
        StringBuilder l2str = new StringBuilder();
        ListNode temp1 = l1;
        ListNode temp2 = l2;
        while (temp1 != null || temp2 != null)
        {
            l1str.Insert(0, temp1 != null ? temp1.val.ToString() : "0");
            l2str.Insert(0, temp2 != null ? temp2.val.ToString() : "0");
            temp1 = temp1?.next;
            temp2 = temp2?.next;
        }
        var total = findSum(l1str.ToString(), l2str.ToString());

        ListNode res = new ListNode(Int16.Parse(total.Last().ToString()), null);
        ListNode current = res;
        for (int i = total.Length - 2; i >= 0; i--)
        {
            current.next = new ListNode(Int16.Parse(total[i].ToString()), null);
            current = current.next;
        }
        return res;
    }

    static string findSum(string str1, string str2)
    {
        // Before proceeding further, make sure length
        // of str2 is larger.
        if (str1.Length > str2.Length)
        {
            string t = str1;
            str1 = str2;
            str2 = t;
        }

        // Take an empty string for storing result
        string str = "";

        // Calculate length of both string
        int n1 = str1.Length, n2 = str2.Length;

        // Reverse both of strings
        char[] ch = str1.ToCharArray();
        Array.Reverse(ch);
        str1 = new string(ch);
        char[] ch1 = str2.ToCharArray();
        Array.Reverse(ch1);
        str2 = new string(ch1);

        int carry = 0;
        for (int i = 0; i < n1; i++)
        {
            // Do school mathematics, compute sum of
            // current digits and carry
            int sum = ((int)(str1[i] - '0') +
                    (int)(str2[i] - '0') + carry);
            str += (char)(sum % 10 + '0');

            // Calculate carry for next step
            carry = sum / 10;
        }

        // Add remaining digits of larger number
        for (int i = n1; i < n2; i++)
        {
            int sum = ((int)(str2[i] - '0') + carry);
            str += (char)(sum % 10 + '0');
            carry = sum / 10;
        }

        // Add remaining carry
        if (carry > 0)
            str += (char)(carry + '0');

        // reverse resultant string
        char[] ch2 = str.ToCharArray();
        Array.Reverse(ch2);
        str = new string(ch2);

        return str;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}