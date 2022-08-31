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
        // StringBuilder l2str = new StringBuilder();
        ListNode temp1 = l1;
        ListNode temp2 = l2;
        bool residual = false;
        while (temp1 != null || temp2 != null)
        {
            var sum = (temp1 != null ? temp1.val : 0) + (temp2 != null ? temp2.val : 0);
            if (residual)
                sum += 1;
            residual = sum > 9;
            l1str.Insert(0, (sum % 10).ToString());
            // l2str.Insert(0, temp2 != null ? temp2.val.ToString() : "0");
            temp1 = temp1?.next;
            temp2 = temp2?.next;
        }
        if (residual)
            l1str.Insert(0, "1");
        var total = l1str.ToString();

        ListNode res = new ListNode(Int16.Parse(total.Last().ToString()), null);
        ListNode current = res;
        for (int i = total.Length - 2; i >= 0; i--)
        {
            current.next = new ListNode(Int16.Parse(total[i].ToString()), null);
            current = current.next;
        }
        return res;
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