public class LinkedList
{
    private Node? head;  

    public void Display()
    {
        Node? current = head;
        while (current != null)
        {
            Console.Write("["+current.data+"] ");
            current = current.next;
        }
        Console.WriteLine();
    }

    // == OFFER ==
    public void Offer(int data)
    {
        Node? newNode = new Node(data);

        // empty list
        if (head == null)   head = newNode;

        newNode.next = head;
        head = newNode;    
    }

    // == PUSH == 
    public void Push(int data)
    {
        Node newNode = new Node(data);
        
        // list EMPTY -> become HEAD
        if (head == null)
        {
            head = newNode;
            return;
        }

        // add at the END
        Node current = head;
        while (current.next != null)    // move to before last node
        {
            current = current.next;
        }
        current.next = newNode;
    }

    // == DELETE head - POP ==
    public int? Pop()   // '?' indicate that the return value can be NULL
    {
        // nothing to POP
        if (head == null) return null;

        int value = head.data;
        Console.WriteLine($"Pop: [{value}]");
        head = head.next;

        return value;
    }

    // == DELETE tail - POLL ==
    public int? Poll()
    {   
        // = safety check =
        // empty list
        if (head == null)   return null;
        // ONLY 1 item
        if (head.next == null)
        {
            head = null;    // remove head;
            return null;
        }

        Node? current = head;
        while (current.next.next != null)
        {
            current = current.next;
        }

        int value = current.next.data;  
        current.next = null;    // remove last node
        Console.WriteLine($"Poll: [{value}]");
        return value;
    }

    // == SEARCH ==
    public int? Search(int data)
    {
        // empty list
        if (head == null)   return null;
        
        int index = 0;
        Node? current = head;
        while (current != null) // move to last node
        {
            if (current.data == data)
            {
                Console.WriteLine($"Found: [{data}] - index: {index}");
                return index;
            }
            
            current = current.next;
            index++;
        }

        Console.WriteLine($"NOT FOUND {data}");
        return null;
    }
}