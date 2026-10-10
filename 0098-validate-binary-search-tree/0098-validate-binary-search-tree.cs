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
    public bool IsValidBST(TreeNode root) {
        return ValidBST(root, long.MinValue, long.MaxValue);
    }

    private bool ValidBST(TreeNode root, long min, long max)
    {
        if(root == null) return true;

        if(root.val >= max || root.val <= min) return false;

        return (ValidBST(root.left, min , root.val) && ValidBST(root.right, root.val , max));
    }
}