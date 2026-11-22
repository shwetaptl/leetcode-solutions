public class Solution {
    public bool Exist(char[][] board, string word) {
        int row = board.Length, col = board[0].Length;

        for(int i = 0 ; i< row; i++)
        {
            for(int j = 0 ; j < col ; j++)
            {
                if(Search(i,j,0)) return true;
                
            }
        }
        return false;

        bool Search(int r , int c, int index)
        {
            if(r < 0 || r >= row || c < 0 || c >= col) return false;

            if(board[r][c] != word[index]) return false;

            if(index == word.Length - 1) return true;

            var saved = board[r][c];
            board[r][c] = '#';

            bool found = Search(r+1,c,index+1) || Search(r-1,c,index+1) || Search(r,c+1,index+1) || Search(r,c-1,index+1) ;
            
            board[r][c] = saved;
            return found;
        }
    }
}