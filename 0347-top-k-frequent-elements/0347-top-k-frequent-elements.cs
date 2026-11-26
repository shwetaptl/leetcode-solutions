public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var result = new int[k];
        Dictionary<int,int> count = new Dictionary<int,int>();
        foreach(int num in nums)
        {
            count[num] = count.GetValueOrDefault(num) + 1;
        }
        var bucket = new List<int>[nums.Length + 1];
        foreach(var (num, freq) in count)
        {
            if(bucket[freq] == null)
            {
                bucket[freq] = new List<int>();
            }
            bucket[freq].Add(num);
        }
        int index= 0;
        for(int i = bucket.Length - 1 ; i>=0 ; i--)
        {
            if(bucket[i] == null) continue;

            foreach(var frequent in bucket[i])
            {
                result[index++] = frequent;
                k--;
                if(k == 0)
                    return result;
            }
        }
        return result;
    }
}
//o(n) - time and space 