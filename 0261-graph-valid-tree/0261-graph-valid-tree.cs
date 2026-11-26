public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if(edges.Length != n-1) return false;

        var queue = new Queue<int>();
        bool[] visited = new bool[n];
        int visitedNode = 0;

        var graph = new List<int>[n];
        for(int i = 0 ; i< n ; i++)
        {
            graph[i] = new List<int>();
        }

        foreach(var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        visited[0] = true;
        queue.Enqueue(0);
        
        while(queue.Count > 0)
        {
            int i = queue.Dequeue();
            visitedNode++;
            foreach(var neighbor in graph[i])
            {
                if(visited[neighbor]) continue;
                visited[neighbor] = true;
                queue.Enqueue(neighbor);
            }
        }

        return visitedNode == n;

    }
}