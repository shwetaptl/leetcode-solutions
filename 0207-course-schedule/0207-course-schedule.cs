public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        int finish= 0;
        int[] dependsOn = new int[numCourses];
        var dependdents = new List<int>[numCourses];

        for(int i = 0 ; i < numCourses ; i++)
        {
            dependdents[i] = new List<int>();
        }
        foreach(var pre in prerequisites)
        {
            dependdents[pre[1]].Add(pre[0]);
            dependsOn[pre[0]]++;
        }

        Queue<int> queue = new Queue<int>();
        for(int i = 0 ; i < numCourses ; i++)
        {
            if(dependsOn[i] == 0)
                queue.Enqueue(i);
        }

        while(queue.Count > 0)
        {
            var i = queue.Dequeue();
            finish++;
            foreach(var dependdent in dependdents[i])
            {
                dependsOn[dependdent]--;
                if(dependsOn[dependdent] == 0)
                    queue.Enqueue(dependdent);
            }
        }
        return finish == numCourses;
    }
}