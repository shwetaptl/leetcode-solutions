public class Solution {
    public int Jump(int[] nums) {
        int jumps = 0, currentEnd = 0, farthest = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if(i > farthest) return -1 ;
            farthest = Math.Max(farthest, i + nums[i]);

            if (i == currentEnd)
            {
                jumps++;
                currentEnd = farthest;
            }
        }
        return jumps;
    }
}