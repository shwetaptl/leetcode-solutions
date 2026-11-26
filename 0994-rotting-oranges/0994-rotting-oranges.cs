public class Solution {
    public int OrangesRotting(int[][] grid) {
        int row = grid.Length;
        int col = grid[0].Length;
        int fresh = 0 ;
        Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
        var dir = new (int dr,int dc)[] {(1,0),(-1,0),(0,1),(0,-1)} ;

        for(int i = 0 ; i < row ; i++)
        {
            for(int j = 0 ; j < col; j++)
            {
                if(grid[i][j] == 2)
                    queue.Enqueue((i,j));
                else if(grid[i][j] == 1) 
                    fresh++;
            }
        }
        int min = 0 ;
        while(queue.Count > 0 && fresh > 0)
        {
            int levelCount = queue.Count;
            min++;
            for(int i = 0 ; i < levelCount ; i++)
            {
                (int r, int c) = queue.Dequeue();
                foreach(var (dr,dc) in dir)
                {
                    int nr = r + dr, nc = c+dc;
                    if(nr < 0 || nr >= row || nc< 0 || nc >= col) continue;
                    if(grid[nr][nc] != 1) continue;

                    grid[nr][nc] = 2;
                    fresh--;
                    queue.Enqueue((nr,nc));
                }
            }
        }
        return fresh == 0 ? min : -1;
    }
}