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
    int MaxGoodNodes = 0;
    
    public int GoodNodes(TreeNode root) {
        IsGoodNodes(root,root.val);
        return MaxGoodNodes;
    }

    private void IsGoodNodes(TreeNode root,int MaxVal)
    {
        if(root == null) return;
        if(root.val >= MaxVal) MaxGoodNodes++;
        MaxVal = Math.Max(root.val, MaxVal);
        IsGoodNodes(root.left,MaxVal);
        IsGoodNodes(root.right,MaxVal);
    }
}