public class Solution {
    public IList<string> LetterCombinations(string digits) {
        
        string[] keyPad = new string[]{"","","abc","def","ghi","jkl","mno","pqrs","tuv","wxyz"};

        var result = new List<string>();
        var path = new StringBuilder();
        Backtrack(0);
        return result;

        void Backtrack(int index)
        {
            if(index == digits.Length)
            {
                result.Add(path.ToString());
                return;
            }

            string letters =  keyPad[digits[index] - '0'];
            foreach(char letter in letters)
            {
                path.Append(letter);
                Backtrack(index+1);
                path.Length--;
            }
        }
    }
}