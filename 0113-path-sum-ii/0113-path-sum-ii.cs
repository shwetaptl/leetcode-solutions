public class Solution
{
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        var result = new List<IList<int>>();
        var path = new List<int>();

        DFS(root, targetSum, path, result);

        return result;
    }

    private void DFS(TreeNode node, int remaining,
                     List<int> path, IList<IList<int>> result)
    {
        if (node == null)
            return;

        path.Add(node.val);
        remaining -= node.val;

        // Check if current node is a leaf
        if (node.left == null && node.right == null && remaining == 0)
        {
            result.Add(new List<int>(path));
            //O(k*h) Number of valid paths = K Maximum length of each path = O(h)
            //Worst case k = O(n) h = O(n) like target = 0 and all path value = 0 
        }

        DFS(node.left, remaining, path, result);//O(n)
        DFS(node.right, remaining, path, result);//O(n)

        // Backtracking
        path.RemoveAt(path.Count - 1);
    }
}
//time = O(n + k*h) but worst case = O(n^2) 
//result space = O(K × h)
//Auxiliary space = o(h)