public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        int row = heights.Length, col = heights[0].Length;
        var result = new List<IList<int>>();
        var dir = new (int dr, int dc)[]{(0,1),(1,0),(-1,0),(0,-1)};
        var pacificQueue = new Queue<(int r, int c)>();
        var atlanticQueue = new Queue<(int r, int c)>();
        bool[,] visitPacific = new bool[row,col];
        bool[,] visitAtlantic = new bool[row,col];

        for(int i = 0 ; i < row ; i++)
        {
            visitPacific[i,0] = true;
            visitAtlantic[i,col-1] = true;
            pacificQueue.Enqueue((i,0));
            atlanticQueue.Enqueue((i,col-1));
        }
        for(int i = 0 ; i < col ; i++)
        {
            visitPacific[0,i] = true;
            visitAtlantic[row-1,i] = true;
            pacificQueue.Enqueue((0,i));
            atlanticQueue.Enqueue((row-1,i));
        }

        BFS(pacificQueue,visitPacific,row,col);
        BFS(atlanticQueue,visitAtlantic, row, col );

        for(int i = 0 ; i < row ;i++)
        {
            for(int j= 0 ; j<col ; j++)
            {
                if(visitPacific[i,j] && visitAtlantic[i,j])
                result.Add(new List<int>{i,j});
            }
        }

        return result;

        void BFS(Queue<(int r, int c)> queue, bool[,] visited, int row, int col )
        {
            while(queue.Count > 0)
            {
                var (r,c)  = queue.Dequeue();
                foreach(var (dr,dc) in dir)
                {
                    int nr = r+dr, nc = c+dc;
                    if(nr < 0 || nr >= row || nc <0 || nc >= col) continue;
                    if (visited[nr,nc]) continue;

                    if(heights[r][c] <= heights[nr][nc])
                    {
                        visited[nr,nc] = true;
                        queue.Enqueue((nr,nc));
                    }
                }
            }
        }


    }
}