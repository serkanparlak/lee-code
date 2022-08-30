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
// solution 1 (array)
Console.WriteLine(Solution1.IsPalindrome(linked));
// solution 2 (linked)
Console.WriteLine(Solution2.IsPalindrome(linked));
