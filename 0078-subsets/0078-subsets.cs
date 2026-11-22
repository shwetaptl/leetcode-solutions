public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var result = new List<IList<int>>();
        var path = new List<int>();
        BackTrack(0);
        return result;

        void BackTrack(int start)
        {
                result.Add(new List<int>(path));   
                for(int i = start; i< nums.Length; i++)
                {
                    path.Add(nums[i]);
                    BackTrack(i+1);
                    path.RemoveAt(path.Count - 1);
                }
        }
    }
}