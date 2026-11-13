public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
       var result = new List<IList<int>>();
        var path = new List<int>();
        var used = new bool[nums.Length];
        Backtrack();
        return result;

        void Backtrack()
        {
            if (path.Count == nums.Length)            // every number placed
            {
                result.Add(new List<int>(path));      // save a COPY
                return;
            }

            for (int i = 0; i < nums.Length; i++)     // order matters → start at 0
            {
                if (used[i]) continue;                // already in this ordering

                used[i] = true;                       // choose (mark)
                path.Add(nums[i]);                    // choose (add)
                Backtrack();                          // explore
                path.RemoveAt(path.Count - 1);        // undo (remove)
                used[i] = false;                      // undo (unmark)
            }
        } 
    }
}