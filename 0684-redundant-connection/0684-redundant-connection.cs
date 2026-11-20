public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        var parent = new int[n+1];
        for(int i = 1 ; i<= n ; i++)
        {
            parent[i] = i;
        }

        int Find(int x)
        {
            while(parent[x] != x)
                x = parent[x];
            return x;
        }

        foreach(var edge in edges)
        {
            int A = Find(edge[0]);
            int B = Find(edge[1]);

            if(A != B)
                parent[B] = A;
            else
                return edge;
        }
        return Array.Empty<int>();
        
    }
}