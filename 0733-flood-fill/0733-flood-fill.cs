public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        
        int original = image[sr][sc];
        if(original == color) return image;

        int rows = image.Length ; 
        int cols = image[0].Length;

        var dirs = new (int dr, int dc)[] {(1,0),(-1,0),(0,1),(0,-1)};
        var queue = new Queue<(int r, int c)>();
        image[sr][sc] = color;
        queue.Enqueue((sr,sc));

        while(queue.Count > 0)
        {
            int queueSize = queue.Count;

            for(int i = 0 ; i< queueSize ; i++)
            {
                var (r,c) = queue.Dequeue(); 

                foreach(var (dr,dc) in dirs)
                {
                    int nr = r + dr , nc = c + dc;
                    if(nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue; 
                    if(image[nr][nc] != original) continue;

                    image[nr][nc] = color;
                    queue.Enqueue((nr,nc));
                }
            }
        }
        return image;
    }
}