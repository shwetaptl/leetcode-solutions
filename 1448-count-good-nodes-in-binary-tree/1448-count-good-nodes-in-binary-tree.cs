/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int GoodNodes(TreeNode root) => Count(root, root.val);

private int Count(TreeNode node, int maxSoFar)
{
    if (node == null) return 0;

    int good = node.val >= maxSoFar ? 1 : 0;        // >= : equal is still good
    int newMax = Math.Max(maxSoFar, node.val);      // what the children will see

    return good + Count(node.left, newMax) + Count(node.right, newMax);
}
}