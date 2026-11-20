public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        int n = isConnected.Length;
        int noOfProvinces = 0 ;
        var visited = new bool[n];
        var queue = new Queue<int>();

        //Create graph
        var graph = new List<int>[n];
        for(int i = 0 ; i< n ; i++) graph[i] = new List<int>();

        for(int i = 0 ; i< n; i++)
        {
            for(int j = 0 ; j < n ; j++)
            {
                if(i == j) continue;
                if(isConnected[i][j] == 1) graph[i].Add(j);
            }
        }

        for(int i = 0 ; i<n ; i++)
        {
            if(visited[i]) continue;
            visited[i] = true;
            queue.Enqueue(i);
            noOfProvinces++;
            BFS();
        }
        return noOfProvinces;

        void BFS()
        {
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach(var neighbour in graph[node])
                {
                    if(visited[neighbour]) continue;
                    visited[neighbour] = true;
                    queue.Enqueue(neighbour);

                }
            }
        }

    }
}