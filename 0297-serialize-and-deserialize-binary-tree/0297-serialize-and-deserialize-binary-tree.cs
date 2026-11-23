/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // 🔹 Serialize: Convert tree → string using preorder DFS
    public string serialize(TreeNode root) {
        StringBuilder sb = new StringBuilder();
        SerializeTree(root,sb);
        // if (root == null) return "null,";
        // string left = serialize(root.left);
        // string right = serialize(root.right);
        // return root.val + "," + left + right;
        return sb.ToString();
    }

    private void SerializeTree(TreeNode node , StringBuilder sb)
    {
        if (node == null) {
            sb.Append("null,");
            return;
        }
        // Preorder: Root -> Left -> Right
        sb.Append(node.val);
        sb.Append(',');
        SerializeTree(node.left, sb);
        SerializeTree(node.right, sb);

    }
    // 🔹 Deserialize: Convert string → tree using preorder reconstruction
    public TreeNode deserialize(string data) {
        Queue<string> nodes = new Queue<string>(data.Split(',', System.StringSplitOptions.RemoveEmptyEntries));
        return BuildTree(nodes);
    }

    private TreeNode BuildTree(Queue<string> nodes) {
        if (nodes.Count == 0) return null;

        string val = nodes.Dequeue();
        if (val == "null") return null;

        TreeNode node = new TreeNode(int.Parse(val));
        node.left = BuildTree(nodes);
        node.right = BuildTree(nodes);
        return node;
    }
}