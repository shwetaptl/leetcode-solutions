public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
                
        HashSet<string> words = new HashSet<string>(wordList);

        if (!words.Contains(endWord))
            return 0;

        Queue<string> queue = new Queue<string>();
        queue.Enqueue(beginWord);

        words.Remove(beginWord);

        int steps = 1;

        while (queue.Count > 0) {
            int size = queue.Count;

            // Process one BFS level
            for (int i = 0; i < size; i++) {
                string word = queue.Dequeue();

                if (word == endWord)
                    return steps;

                char[] chars = word.ToCharArray();

                // Try changing each character
                for(int j = 0 ; j<chars.Length ; j++)
                {
                    var original = chars[j];
                    for(char c = 'a' ; c <= 'z' ; c++)
                    {
                        chars[j] = c;
                        var newWord = new string(chars);
                        if(words.Contains(newWord))
                        {
                            queue.Enqueue(newWord);
                            words.Remove(newWord);
                        }
                            
                    }
                    chars[j] = original;
                }
            }

            steps++;
        }

        return 0;
    }
}