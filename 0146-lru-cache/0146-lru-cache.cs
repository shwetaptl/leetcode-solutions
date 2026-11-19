public class LRUCache {

    public class DLinkedList
    {
        public int val;
        public DLinkedList next;
        public DLinkedList prev; 

        public DLinkedList(int val= 0 ,DLinkedList prev = null, DLinkedList next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }
    }

    Dictionary<int,int> cache;
    DLinkedList head;
    DLinkedList tail;
    int capacity;

    public LRUCache(int capacity) {
        cache = new Dictionary<int,int>();
        this.capacity = capacity;
        head = new DLinkedList(-1);
        tail = new DLinkedList(-1);
        head.next = tail;
        tail.prev = head;
    }
    

    public int Get(int key) {
        if(!cache.ContainsKey(key))
        {
            return -1;
        }
        else
        {
            RemoveNode(key);
            AddNode(key);
            return cache[key];
        }
    }
    
    public void Put(int key, int value) {
        if(!cache.ContainsKey(key))
        {
            cache[key] = value;
            AddNode(key);

            if(cache.Count > capacity)
            {
                DeleteNode();
            }
        }
        else
        {
            cache[key] = value;
            RemoveNode(key);
            AddNode(key);
        }
    }

    public void RemoveNode(int val)
    {
        DLinkedList curr = head;
        while(curr.val != val)
        {
            curr = curr.next;
        }
        DLinkedList next = curr.next;
        curr.next.prev = curr.prev;
        curr.prev.next = next;
    }

    public void DeleteNode()
    {
        cache.Remove(tail.prev.val);
        DLinkedList node = tail.prev.prev;
        tail.prev = node;
        node.next = tail;


    }

    public void AddNode(int val)
    {
        DLinkedList node = new DLinkedList(val);
        DLinkedList next = head.next;
        head.next = node;
        node.prev = head;
        node.next = next;
        next.prev = node;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */