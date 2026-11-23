public class Solution {
    // public int Rob(int[] nums) 
    // {
    //     if (nums.Length == 1) return nums[0];                  // one house: rob it

    //     int skipLast  = RobLine(nums, 0, nums.Length - 2);     // houses 0 .. n−2
    //     int skipFirst = RobLine(nums, 1, nums.Length - 1);     // houses 1 .. n−1
    //     return Math.Max(skipLast, skipFirst);
    // }

    // // House Robber I on nums[start .. end]
    // private int RobLine(int[] nums, int start, int end)
    // {
    //     if (start == end) return nums[start];                  // only one house in this line

    //     int twoBack = nums[start];                             // best with the first house
    //     int oneBack = Math.Max(nums[start], nums[start + 1]);  // best with the first two houses

    //     for (int i = start + 2; i <= end; i++)                 // from the third house on
    //     {
    //         int current = Math.Max(oneBack, nums[i] + twoBack);   // skip house i, or rob it
    //         twoBack = oneBack;
    //         oneBack = current;
    //     }
    //     return oneBack;
    // }

    public int Rob(int[] nums)
    {
        int n = nums.Length;
        if (n == 1) return nums[0];

        int answer1 = RobLine(nums, 0, n - 2);    // skip the LAST house
        int answer2 = RobLine(nums, 1, n - 1);    // skip the FIRST house
        return Math.Max(answer1, answer2);
    }

    // House Robber I on houses start .. end (dp version)
    private int RobLine(int[] nums, int start, int end)
    {
        if (start == end) return nums[start];                    // only one house in this line

        int[] dp = new int[nums.Length];                         // dp[i] uses the real house index i
        dp[start] = nums[start];                                 // first house of the line
        dp[start + 1] = Math.Max(nums[start], nums[start + 1]);  // first two houses of the line

        for (int i = start + 2; i <= end; i++)
            dp[i] = Math.Max(dp[i - 1], nums[i] + dp[i - 2]);    // skip vs. rob house i

        return dp[end];
    }

}