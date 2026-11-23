public class Solution {
    // public int ClimbStairs(int n) {
    //     if (n <= 2) return n;              // 1 → 1 way, 2 → 2 ways

    //     int twoBack = 1, oneBack = 2;      // ways to reach steps i − 2 and i − 1
    //     for (int i = 3; i <= n; i++)
    //     {
    //         int current = oneBack + twoBack;   // last move: 1 step or 2 steps
    //         twoBack = oneBack;
    //         oneBack = current;
    //     }
    //     return oneBack;
    // }
    public int ClimbStairs(int n)
    {
        if (n <= 2) return n;

        int[] dp = new int[n + 1];          // dp[i] = number of ways to reach step i
        dp[1] = 1;                          // "1"
        dp[2] = 2;                          // "1+1", "2"

        for (int i = 3; i <= n; i++)
            dp[i] = dp[i - 1] + dp[i - 2];  // last move: 1 step from i−1, or 2 steps from i−2

        return dp[n];
    }
}