public class Solution2
{
    public static bool IsPalindrome(ListNode head)
    {
        int length = 0;
        ListNode current = head;
        ListNode prev = null;
        ListNode next = null;
        while (current != null)
        {
            length++;
            current = current.next;
        }
        if (length <= 1)
            return true;
        current = head;
        for (int index = 0; index < length / 2; index++)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        if (length % 2 != 0)
            next = next.next;
        while (next != null && prev != null)
        {
            if (next.val != prev.val)
                return false;
            next = next.next;
            prev = prev.next;
        }
        return true;
    }
}
