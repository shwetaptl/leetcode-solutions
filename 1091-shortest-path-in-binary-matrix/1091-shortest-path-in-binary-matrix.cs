public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {  
        int shortedPath = 0;
        int row = grid.Length;
        int col = grid[0].Length;
        if(grid[0][0] != 0 || grid[row -1 ][col - 1] != 0)  return -1;
        if(row == 1 && col == 1) return 1;

        var queue= new Queue<(int r, int c)>();
        grid[0][0] = 1;
        queue.Enqueue((0,0));

        var dir = new (int dr, int dc)[]{(1,0),(-1,0),(0,1),(0,-1),(1,1),(-1,-1),(1,-1),(-1,1)};

        while(queue.Count > 0)
        {
            shortedPath++;
            int levelLength = queue.Count;

            for(int i = 0 ; i<levelLength ; i++)
            {
                var (r,c)  = queue.Dequeue();
                foreach(var (dr,dc) in dir)
                {
                    int nr = r+dr, nc = c+dc;
                    if(nr < 0 || nr >= row || nc <0 || nc >= col) continue;
                    if (grid[nr][nc] != 0) continue;

                    if(nr == row -1 && nc == col -1) return ++shortedPath;
                    grid[nr][nc] = 1;
                    queue.Enqueue((nr,nc));
                }
            }
            
        }
        return -1;
    }
}