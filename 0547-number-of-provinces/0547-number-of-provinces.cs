public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        
        int n = isConnected.Length;
        var visited = new bool[n];
        int provinces = 0 ;
        var queue= new Queue<int>();

        for(int i=0 ; i< n ; i++)
        {

            if(visited[i]) continue;

            provinces++;
            visited[i] = true;
            queue.Enqueue(i);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                for(int j = 0 ; j < n ; j++)
                {
                    if(isConnected[current][j] == 1 && !visited[j])
                    {
                        visited[j] = true;
                        queue.Enqueue(j);
                    }
                }
            }

        }
        return provinces;

    }
}