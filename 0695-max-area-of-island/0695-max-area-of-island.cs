public class Solution
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        int maxArea = 0 ; 
        int row = grid.Length;
        int col = grid[0].Length;
        var dir = new (int dr, int dc)[]{(1,0),(-1,0),(0,1),(0,-1)};
        var queue = new Queue<(int r, int c)>();

        for(int i = 0 ; i< row ; i++)
        {
            for(int j= 0 ; j < col; j++)
            {
                if(grid[i][j] == 1)
                {
                    grid[i][j] = 0;
                    queue.Enqueue((i,j));
                    BFS();
                }
                continue;
            }
        }

        return maxArea;

        void BFS()
        {
            int count = 0 ; 
            while(queue.Count > 0)
            {
                var (r,c) = queue.Dequeue();
                count++;
                foreach(var (dr,dc) in dir)
                {
                    int nr = r+dr, nc= c+dc;
                    if(nr<0 || nr >= row || nc < 0 || nc >= col) continue;
                    if(grid[nr][nc] != 1) continue;
                    grid[nr][nc] = 0 ; 
                    queue.Enqueue((nr,nc));
                }
            }
            maxArea = Math.Max(maxArea,count);
        }
    }
}
