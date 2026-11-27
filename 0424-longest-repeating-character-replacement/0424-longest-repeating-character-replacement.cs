public class Solution {
    public int CharacterReplacement(string s, int k) {
        int[] freq = new int[26];

        int left = 0;
        int maxFreq = 0;
        int maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            freq[s[right] - 'A']++;

            maxFreq = Math.Max(maxFreq, freq[s[right] - 'A']);

            while (right - left + 1 - maxFreq > k)
            {
                freq[s[left] - 'A']--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}