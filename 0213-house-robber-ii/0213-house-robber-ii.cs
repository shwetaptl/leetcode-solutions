public class Solution {
    public int Rob(int[] nums) 
    {
        if (nums.Length == 1) return nums[0];                  // one house: rob it

        int skipLast  = RobLine(nums, 0, nums.Length - 2);     // houses 0 .. n−2
        int skipFirst = RobLine(nums, 1, nums.Length - 1);     // houses 1 .. n−1
        return Math.Max(skipLast, skipFirst);
    }

    // House Robber I on nums[start .. end]
    private int RobLine(int[] nums, int start, int end)
    {
        if (start == end) return nums[start];                  // only one house in this line

        int twoBack = nums[start];                             // best with the first house
        int oneBack = Math.Max(nums[start], nums[start + 1]);  // best with the first two houses

        for (int i = start + 2; i <= end; i++)                 // from the third house on
        {
            int current = Math.Max(oneBack, nums[i] + twoBack);   // skip house i, or rob it
            twoBack = oneBack;
            oneBack = current;
        }
        return oneBack;
    }
}