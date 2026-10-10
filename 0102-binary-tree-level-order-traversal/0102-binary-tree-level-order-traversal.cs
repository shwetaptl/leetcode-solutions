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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();

        if(root == null) return result;

        Queue<TreeNode> level = new Queue<TreeNode>();
        level.Enqueue(root);
        while(level.Count > 0)
        {
            int levelCount = level.Count;
            List<int> levelItems = new List<int>();
            for(int i =0; i<levelCount ; i++)
            {
                var node = level.Dequeue();
                levelItems.Add(node.val);
                if(node.left != null) level.Enqueue(node.left);
                if(node.right != null) level.Enqueue(node.right);
            }
            result.Add(levelItems);
        }
        return result; 
    }
}