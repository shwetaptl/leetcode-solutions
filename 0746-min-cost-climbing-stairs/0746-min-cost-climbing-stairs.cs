public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        // int twoBack = 0, oneBack = 0;      // cheapest cost to arrive at positions i − 2 and i − 1
        // for (int i = 2; i <= cost.Length; i++)       // i = cost.Length is the top
        // {
        //     int current = Math.Min(oneBack + cost[i - 1], twoBack + cost[i - 2]);
        //     twoBack = oneBack;
        //     oneBack = current;
        // }
        // return oneBack;


        int n = cost.Length;
        int[] dp = new int[n + 1];          // dp[i] = cheapest cost to ARRIVE at position i (n = the top)
        dp[0] = 0;                          // start on stair 0 for free
        dp[1] = 0;                          // start on stair 1 for free

        for (int i = 2; i <= n; i++)
        {
            int fromOneBelow = dp[i - 1] + cost[i - 1];   // leave stair i−1, climb 1
            int fromTwoBelow = dp[i - 2] + cost[i - 2];   // leave stair i−2, climb 2
            dp[i] = Math.Min(fromOneBelow, fromTwoBelow);
        }
        return dp[n];

        
    }
}