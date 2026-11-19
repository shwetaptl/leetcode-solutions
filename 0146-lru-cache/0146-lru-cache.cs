public class Node {
    public int key { get; set; }
    public int value { get; set; }
    public Node next { get; set; }
    public Node prev { get; set; }

    public Node(int key, int value) {
        this.key = key;
        this.value = value;
    }
}

public class LRUCache {
    private int capacity;
    private Dictionary<int, Node> dic;
    private Node head;
    private Node tail;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        dic = new Dictionary<int, Node>();
        head = new Node(-1, -1);
        tail = new Node(-1, -1);
        head.next = tail;
        tail.prev = head;
    }

    public int Get(int key) {
        if (!dic.ContainsKey(key)) {
            return -1;
        }

        Node node = dic[key];
        Remove(node);
        Add(node);
        return node.value;
    }

    public void Put(int key, int value) {
        if (dic.ContainsKey(key)) {
            Node oldNode = dic[key];
            Remove(oldNode);
        }

        Node node = new Node(key, value);
        dic[key] = node;
        Add(node);
        if (dic.Count > capacity) {
            Node nodeToDelete = head.next;
            Remove(nodeToDelete);
            dic.Remove(nodeToDelete.key);
        }
    }

    private void Add(Node node) {
        Node previousEnd = tail.prev;
        previousEnd.next = node;
        node.prev = previousEnd;
        node.next = tail;
        tail.prev = node;
    }

    private void Remove(Node node) {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }
}
// For initiating and calling
// LRUCache obj = new LRUCache(capacity);
// int param_1 = obj.Get(key);
// obj.Put(key,value);