public class Solution {
    public int OrangesRotting(int[][] grid) {
        int minMinutes = 0;
        int fresh = 0 ; 
        int rows = grid.Length, cols = grid[0].Length;
        var queue = new Queue<(int R, int C)>();

        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                if (grid[r][c] == 2) queue.Enqueue((r, c));
                else if (grid[r][c] == 1) fresh++;

        var dirs = new (int Dr, int Dc)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        while (queue.Count > 0 && fresh > 0)
        {
            minMinutes++;
            int queueSize = queue.Count;
            for(int i = 0 ; i < queueSize ; i++)
            {
                var (r, c) = queue.Dequeue();
                foreach (var (dr, dc) in dirs)
                {
                    int nr = r + dr, nc = c + dc;
                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
                    if (grid[nr][nc] != 1) continue;       

                    grid[nr][nc] = 2;   
                    fresh--;       
                    queue.Enqueue((nr, nc));
                }
            }
        }

        return fresh == 0 ? minMinutes : -1;
    }
}