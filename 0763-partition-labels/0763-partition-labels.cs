public class Solution {
    public IList<int> PartitionLabels(string s) {
        int[] freq = new int[26];
        int lastIndex = 0;
        int start = 0 ;
        var result = new List<int>();
        for(int i = 0 ; i < s.Length ; i++)
        {
            freq[s[i] - 'a'] = i;
        }
        for(int i = 0 ; i < s.Length ; i++)
        {
            if(i > lastIndex) 
            {
                result.Add(lastIndex-start+1);
                lastIndex = i;
                start = i;
            }
            lastIndex = Math.Max(lastIndex , freq[s[i] - 'a']);
        }
        result.Add(lastIndex-start+1);
        return result;
    }
}