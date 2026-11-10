public class Solution {
    public int NumIslands(char[][] grid) {
        int noOfIslands = 0 ;
        var dirs = new (int dr,int dc)[] {(1,0),(-1,0),(0,1),(0,-1)};
        int rows = grid.Length , cols = grid[0].Length;
        var queue = new Queue<(int r,int c)>();

        for(int i=0; i< rows; i++)
        {
            for(int j=0; j< cols ; j++)
            {
                if(grid[i][j] == '0') continue;
                noOfIslands ++;
                queue.Enqueue((i,j));
                while(queue.Count > 0)
                {
                    var (r,c) = queue.Dequeue();
                    foreach(var (dr,dc) in dirs)
                    {
                        int nr = dr+r, nc = dc+c;
                        if(nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
                        if(grid[nr][nc] == '0') continue;
                        
                        grid[nr][nc] = '0';
                        queue.Enqueue((nr,nc));
                    }
                }
            }
        }
        return noOfIslands;
    }
}