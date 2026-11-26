/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null) return null;
        var clone = new Dictionary<Node,Node>();
        CloneNode(node);
        return clone[node];

        void CloneNode(Node node)
        {
            Node cloneNode = new Node(node.val);
            clone[node] = cloneNode;
            foreach(var neighbor in node.neighbors)
            {
                if(!clone.ContainsKey(neighbor))
                {
                    CloneNode(neighbor);
                }
                cloneNode.neighbors.Add(clone[neighbor]);
            }     
        }
    }
}