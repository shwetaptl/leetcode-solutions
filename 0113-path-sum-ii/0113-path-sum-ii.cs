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
        }

        DFS(node.left, remaining, path, result);//O(n)
        DFS(node.right, remaining, path, result);//O(n)

        // Backtracking
        path.RemoveAt(path.Count - 1);
    }
}