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
    int MaxLength = 0;

    public int DiameterOfBinaryTree(TreeNode root) {
        Diameter(root);
        return MaxLength;
    }

    private int Diameter(TreeNode root)
    {
        if(root == null) return 0;
        int left = Diameter(root.left);
        int right = Diameter(root.right);
        MaxLength = Math.Max(MaxLength, left+right);
        return 1 + Math.Max(left,right);
    }
}