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

public class Solution1
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
