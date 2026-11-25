public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int[] freq = new int[128];
        int left = 0 , right = 0 ;
        int best = 0 ; 

        while(right < s.Length)
        {
            if(freq[s[right]] != 0)
            {
                best = Math.Max(best, right-left);
                //srink window
                while(freq[s[right]] != 0)
                {
                    freq[s[left]]--;
                    left++;
                }
            }
            freq[s[right]]++;
            right++;
        } 

        best = Math.Max(best, right-left);
        return best;
    }
}