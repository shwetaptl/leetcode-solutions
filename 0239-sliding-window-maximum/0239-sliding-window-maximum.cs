public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        LinkedList<int> dqueue = new LinkedList<int>();
        List<int> result = new List<int>();
        for(int i = 0 ; i < nums.Length ; i++)
        {
            if(dqueue.Count > 0 &&  dqueue.First.Value < i-k+1)
            {
                dqueue.RemoveFirst();
            }

            while(dqueue.Count > 0 && nums[dqueue.Last.Value] <= nums[i])
            {
                dqueue.RemoveLast();
            }

            dqueue.AddLast(i);

            if(i - k + 1 >= 0)//window
                result.Add(nums[dqueue.First.Value]);
        }
        return result.ToArray();
    }
}