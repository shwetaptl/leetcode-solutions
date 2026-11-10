using System;
using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        var result = new List<IList<int>>();
        int rows = heights.Length, cols = heights[0].Length;
        var pacific = new bool[rows,cols];
        var atlantic = new bool[rows,cols];
        var pacificQueue = new Queue<(int r, int c)>();
        var atlanticQueue = new Queue<(int r, int c)>();


        for(int r = 0; r < rows ; r++)
        {
            pacific[r,0] = true;
            atlantic[r,cols-1] = true;
            pacificQueue.Enqueue((r,0));
            atlanticQueue.Enqueue((r,cols-1));
        }

        for(int c = 0; c < cols ; c++)
        {
            pacific[0,c] = true;
            atlantic[rows-1,c] = true;
            pacificQueue.Enqueue((0,c));
            atlanticQueue.Enqueue((rows-1,c));
        }
        BFS(heights,pacificQueue,pacific,rows,cols);
        BFS(heights,atlanticQueue, atlantic,rows,cols);

        for(int i = 0 ; i < rows ; i++)
        {
            for(int j = 0; j< cols; j++)
            {
                if(pacific[i,j] && atlantic[i,j])
                result.Add(new List<int>{i,j});
            }
        }
        return result;


    }

    private void BFS(int[][] heights, Queue<(int r, int c)> queue, bool[,] visited, int rows, int cols)
    {
        while(queue.Count > 0)
        {
            var (r,c) = queue.Dequeue();
            var dirs = new (int Dr, int Dc)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
            foreach (var (dr, dc) in dirs)
            {
                int nr = r + dr, nc = c + dc;
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
                if (visited[nr, nc]) continue;
                if (heights[nr][nc] < heights[r][c]) continue;         // can't climb down
                visited[nr,nc] = true;
                queue.Enqueue((nr,nc ));
            }
        }
    }
}
