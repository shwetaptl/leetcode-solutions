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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        
        Dictionary<int,int> indexOf = new Dictionary<int,int>();
        for(int i=0; i < inorder.Length ; i++)
        {
            indexOf[inorder[i]] = i;
        }
        int preIndx = 0;

        TreeNode Build(int left , int right)
        {
            if(left > right) return null;
            int nodeVal = preorder[preIndx++];
            TreeNode node = new TreeNode(nodeVal);
            int mid = indexOf[nodeVal];
            node.left = Build(left, mid -1);
            node.right = Build(mid+1, right);
            return node;
        }
        
        return Build(0,inorder.Length -1);
    }  
}