/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
var asd = new[] { 1, 2, 2, 1 };
var linked = asd.Aggregate<int, ListNode>(null, (list, current) => new ListNode(current, list));
Console.WriteLine(Solution.IsPalindrome(linked));

public static class Solution
{
    public static bool IsPalindrome(ListNode head)
    {
        var arr = new List<int>();
        ListNode active = head;
        while (active != null)
        {
            arr.Add(active.val);
            active = active.next;
        }
        for (int i = 0; i < Math.Floor(arr.Count / 2d); i++)
        {
            if (arr[i] != arr[arr.Count - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
}

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}