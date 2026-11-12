public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        int courseTaken = 0 ;
        var waiting = new int[numCourses];
        var unlock =  new List<int>[numCourses];

        for(int i = 0 ; i<numCourses; i++)
        {
            unlock[i] = new List<int>();
        }
        
        foreach(var prerequisite in prerequisites)
        {
            unlock[prerequisite[1]].Add(prerequisite[0]);
            waiting[prerequisite[0]]++;
        }

        var queue = new Queue<int>();
        for(int i=0; i<numCourses; i++)
        {
            if(waiting[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        while(queue.Count > 0)
        {
            int course =  queue.Dequeue();
            courseTaken++;
            foreach(var prerequisite in unlock[course])
            {
                waiting[prerequisite]--;
                if(waiting[prerequisite] == 0)
                {
                    queue.Enqueue(prerequisite);
                }
            }

        }
        return courseTaken == numCourses;
    }
}