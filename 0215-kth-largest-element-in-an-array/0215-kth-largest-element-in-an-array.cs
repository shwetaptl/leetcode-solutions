public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int,int> queue = new PriorityQueue<int,int>();
        foreach(var n in nums)
        {
            queue.Enqueue(n,n);
            if(queue.Count > k)
            {
                queue.Dequeue();
            }
        }
        return queue.Peek();
    }
}
//Time Complexity: O(n log k) for k ≥ 2; O(n) when k = 1.

//Space Complexity: O(k)

//Approach: Min Heap of size k.