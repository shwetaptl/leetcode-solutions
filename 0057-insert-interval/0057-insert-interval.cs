public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var result = new List<int[]>();
        int i = 0 , n = intervals.Length;
        int start = newInterval[0], end = newInterval[1];

        while(i < n && intervals[i][1] < start)
            result.Add(intervals[i++]);

        while(i < n && intervals[i][0] <= end)
        {
            start = Math.Min(intervals[i][0],start);
            end = Math.Max(intervals[i][1],end);
            i++;
        }
        result.Add([start,end]);
        
        while(i<n)
        {
             result.Add(intervals[i++]);            
        }
        return result.ToArray();

    }
}
