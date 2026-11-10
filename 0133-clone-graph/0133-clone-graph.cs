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
        if(node == null) return null;
        
        var copies = new Dictionary<Node,Node>();
        copies[node] = new Node(node.val);
        
        var queue = new Queue<Node>();
        queue.Enqueue(node);

        while(queue.Count > 0)
        {
            var current = queue.Dequeue();
            foreach(var neighbor in current.neighbors)
            {
                if(!copies.ContainsKey(neighbor))
                {
                    copies[neighbor] = new Node(neighbor.val);
                    queue.Enqueue(neighbor);
                }
                copies[current].neighbors.Add(copies[neighbor]);
            }
        }
        return copies[node];

    }
}