public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        
        bool[] dp = new bool[s.Length+1];
        dp[0] = true;

        for(int i = 0 ; i <= s.Length ; i++)
        {
            foreach(string word in wordDict)
            {
                 int start = i - word.Length;
                 if(start >=0 && dp[start] && s.Substring(start,word.Length) == word)
                 {
                    dp[i] = true;
                    break;
                 }
            }
        }
        return dp[s.Length];
    }
}
//Time  - O(n × m × L): n = s.Length, m = wordDict.Count, L = max word length 
//Space -  O(n) for dp