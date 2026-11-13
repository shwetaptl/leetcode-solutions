public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        var result = new List<IList<int>>();
        var path = new List<int>();
        Array.Sort(candidates);                                  // duplicates side by side, enables break
        Backtrack(0, target);
        return result;

        void Backtrack(int start, int remaining)
        {
            if (remaining == 0)                                  // exactly hit the target
            {
                result.Add(new List<int>(path));                 // save a copy
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1])
                    continue;                                    // same value at the same level → skip
                if (candidates[i] > remaining)
                    break;                                       // too big, and so is everything after

                path.Add(candidates[i]);                         // choose
                Backtrack(i + 1, remaining - candidates[i]);     // explore (i + 1: use once)
                path.RemoveAt(path.Count - 1);                   // undo
            }
        }
    }
}