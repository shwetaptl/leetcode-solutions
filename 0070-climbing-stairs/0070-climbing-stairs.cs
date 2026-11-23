public class Solution {
    public int ClimbStairs(int n) {
        if (n <= 2) return n;              // 1 → 1 way, 2 → 2 ways

        int twoBack = 1, oneBack = 2;      // ways to reach steps i − 2 and i − 1
        for (int i = 3; i <= n; i++)
        {
            int current = oneBack + twoBack;   // last move: 1 step or 2 steps
            twoBack = oneBack;
            oneBack = current;
        }
        return oneBack;
    }
}