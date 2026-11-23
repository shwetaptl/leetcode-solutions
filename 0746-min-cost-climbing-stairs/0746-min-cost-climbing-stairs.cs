public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int twoBack = 0, oneBack = 0;      // cheapest cost to arrive at positions i − 2 and i − 1
        for (int i = 2; i <= cost.Length; i++)       // i = cost.Length is the top
        {
            int current = Math.Min(oneBack + cost[i - 1], twoBack + cost[i - 2]);
            twoBack = oneBack;
            oneBack = current;
        }
        return oneBack;
    }
}