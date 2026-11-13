public class Solution {
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        var path = new StringBuilder();
        Backtrack(0, 0);
        return result;

        void Backtrack(int open, int close)
        {
            if (path.Length == 2 * n)                // L1: full length → valid by construction
            {
                result.Add(path.ToString());         // L2: save (ToString makes a copy)
                return;
            }

            if (open < n)                            // L3: can still open
            {
                path.Append('(');                    // choose
                Backtrack(open + 1, close);          // explore
                path.Length--;                       // undo
            }

            if (close < open)                        // L4: something to close
            {
                path.Append(')');                    // choose
                Backtrack(open, close + 1);          // explore
                path.Length--;                       // undo
            }
        }
    }
}