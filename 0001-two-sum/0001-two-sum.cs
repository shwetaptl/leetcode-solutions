public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int,int> numIndices = new Dictionary<int,int>();
        for(int i=0 ; i<nums.Length; i++)
        {
            int continer = target - nums[i];
            if(numIndices.ContainsKey(continer))
            {
                return new int[]{i,numIndices[continer]};
            }
            numIndices[nums[i]] = i;
        }
        return Array.Empty<int>();
    }
}