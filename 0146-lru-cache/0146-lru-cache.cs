public class LRUCache {

    public class Node
    {
        public int val;
        public int key;
        public Node prev;
        public Node next;

        public Node(int key = 0, int val=0 ,Node prev = null, Node next = null)
        {
            this.val = val;
            this.key = key;
            this.prev = prev;
            this.next = next;
        }

    }
    Node head;
    Node tail;
    int _capacity;
    Dictionary<int, Node> map;

    public LRUCache(int capacity) {
        _capacity = capacity;
        map = new Dictionary<int,Node>();
        head = new Node();
        tail = new Node();
        head.next = tail;
        tail.prev = head;
    }

    public int Get(int key) {
        if(!map.ContainsKey(key))
        {
            return -1;
        }
        else
        {
            Node node = map[key];
            RemoveNode(node);
            AddNode(node);
            return node.val;
        }
    }
    
    public void Put(int key, int value) {
        if(map.ContainsKey(key))
        {
            var node = map[key];
            node.val = value;
            RemoveNode(node);
            AddNode(node);
        }
        else
        {
            var node = new Node(key,value);
            AddNode(node);
            map[key] = node;
            
            if(_capacity < map.Count)
            {
                var deletedNode = DeleteNode();
                map.Remove(deletedNode.key);
            }
        }
    }

    private void RemoveNode(Node node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }

    private void AddNode(Node node)
    {
        node.next = head.next;
        node.prev = head;
        head.next = node;
        node.next.prev = node;
    }

    private Node DeleteNode()
    {
        Node node = tail.prev;
        node.prev.next = tail;
        tail.prev = node.prev;
        return node;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */