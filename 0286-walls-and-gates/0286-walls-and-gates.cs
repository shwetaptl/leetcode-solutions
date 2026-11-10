using System;
using System.Collections.Generic;

public class Solution
{
    public void WallsAndGates(int[][] rooms)
    {
        const int INF = int.MaxValue;
        int rows = rooms.Length, cols = rooms[0].Length;
        var queue = new Queue<(int R, int C)>();

        // 1. EVERY gate goes in the queue first (all at distance 0)
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                if (rooms[r][c] == 0)
                    queue.Enqueue((r, c));

        var dirs = new (int Dr, int Dc)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        // 2. Normal BFS: all ripples spread together
        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
            foreach (var (dr, dc) in dirs)
            {
                int nr = r + dr, nc = c + dc;
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
                if (rooms[nr][nc] != INF) continue;       // wall, gate, or already has a distance

                rooms[nr][nc] = rooms[r][c] + 1;          // one step farther (also marks visited)
                queue.Enqueue((nr, nc));
            }
        }
    }
}