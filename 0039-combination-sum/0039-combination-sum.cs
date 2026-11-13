public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var result = new List<IList<int>>();
        var path = new List<int>();
        Array.Sort(candidates);                          // sorted → can stop early
        Backtrack(0, target);
        return result;

        void Backtrack(int start, int remaining)
        {
            if (remaining == 0)                          // exactly reached the target
            {
                result.Add(new List<int>(path));         // save a COPY
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (candidates[i] > remaining) break;    // too big, and so is everything after

                path.Add(candidates[i]);                         // choose
                Backtrack(i, remaining - candidates[i]);         // explore (i: can reuse)
                path.RemoveAt(path.Count - 1);                   // undo
            }
        }
    }
}