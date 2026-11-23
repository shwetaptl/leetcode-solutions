public class Solution {
    public int Rob(int[] nums) {
        // if (nums.Length == 1) return nums[0];
        // int twoBack = nums[0];                       
        // int oneBack = Math.Max(nums[0], nums[1]);    

        // for (int i = 2; i < nums.Length; i++)
        // {
        //     int current = Math.Max(oneBack, nums[i] + twoBack);
        //     twoBack = oneBack;
        //     oneBack = current;
        // }
        
        // return oneBack;

        int n = nums.Length;
        if (n == 1) return nums[0];

        int[] dp = new int[n];              // dp[i] = most money from houses 0..i
        dp[0] = nums[0];                    // one house: rob it
        dp[1] = Math.Max(nums[0], nums[1]); // two houses: rob the richer one

        for (int i = 2; i < n; i++)
        {
            int skip = dp[i - 1];           // don't rob house i
            int rob = nums[i] + dp[i - 2];  // rob house i (so house i−1 is skipped)
            dp[i] = Math.Max(skip, rob);
        }
        return dp[n - 1];
        
    }
}