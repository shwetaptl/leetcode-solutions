public class Solution {
    public int CountComponents(int n, int[][] edges) {

        var graph = new List<int>[n];
        for(int i = 0 ; i< n ; i++) graph[i] = new List<int>();
        foreach(var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var queue= new Queue<int>();
        var visited = new bool[n];
        int components = 0 ;

        for(int i=0 ; i< n ; i++)
        {

            if(visited[i]) continue;
            components++;
            visited[i] = true;
            queue.Enqueue(i);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach(var neighbor in graph[current])
                {
                    if(!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }

        }
        return components;
    }
}