public class Solution {
    public int NumIslands(char[][] grid) {
        int noOfIslands = 0 ; 
        int row = grid.Length;
        int col = grid[0].Length;
        var dir = new (int dr, int dc)[]{(1,0),(-1,0),(0,1),(0,-1)};
        var queue = new Queue<(int r, int c)>();

        for(int i = 0 ; i< row ; i++)
        {
            for(int j= 0 ; j < col; j++)
            {
                if(grid[i][j] == '1')
                {
                    noOfIslands++;
                    queue.Enqueue((i,j));
                    DFS();
                }
                continue;
            }
        }

        return noOfIslands;

        void DFS()
        {
            while(queue.Count > 0)
            {
                var (r,c) = queue.Dequeue();

                foreach(var (dr,dc) in dir)
                {
                    int nr = r+dr, nc= c+dc;
                    if(nr<0 || nr >= row || nc < 0 || nc >= col) continue;
                    if(grid[nr][nc] != '1') continue;
                    grid[nr][nc] = '0' ; 
                    queue.Enqueue((nr,nc));
                }
            }
        }

    }
}