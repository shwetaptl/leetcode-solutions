public class Solution {
    public int SubarraySum(int[] nums, int k) {
        Dictionary<int,int> seen = new Dictionary<int,int> {[0] = 1};
        int prefix = 0 , count = 0 ; 
        foreach(int num in nums)
        {
            prefix += num;
            if(seen.TryGetValue(prefix - k , out int c))
                count += c;
            seen[prefix] = seen.GetValueOrDefault(prefix) + 1;
        }
        return count;
    }
}