public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));   // by start time

        var rooms = new PriorityQueue<int, int>();   // end time of each room in use (smallest first)

        foreach (var meeting in intervals)
        {
            if (rooms.Count > 0 && rooms.Peek() <= meeting[0])
                rooms.Dequeue();                     // the earliest room is free → reuse it

            rooms.Enqueue(meeting[1], meeting[1]);   // this meeting occupies a room until its end
        }
        return rooms.Count;   
    }
}