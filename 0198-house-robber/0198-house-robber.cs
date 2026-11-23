public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) return nums[0];
        int twoBack = nums[0];                       
        int oneBack = Math.Max(nums[0], nums[1]);    

        for (int i = 2; i < nums.Length; i++)
        {
            int current = Math.Max(oneBack, nums[i] + twoBack);
            twoBack = oneBack;
            oneBack = current;
        }
        
        return oneBack;
    }
}