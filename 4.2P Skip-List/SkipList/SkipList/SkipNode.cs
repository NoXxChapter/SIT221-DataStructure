namespace SkipList
{
    public class SkipNode
    {
        private int maxLevel;   // celling of level
        private Node? head;
        private int currentLevel;
        private Random random = new Random();
        
        public SkipNode(int maxLevel)
        {
            this.maxLevel = maxLevel;
            head = new Node(-1, maxLevel);    // head Node created with MAXIMUM height immediately
            currentLevel = 0;   // list start with ground level (empty)
        }

        // == GENERATE random level HEIGHT ==
        private int getRandomLevel()
        {
            int lvl = 0;
            while (random.NextDouble() < 0.5 && lvl < maxLevel)
            {
                lvl++;
            }
            return lvl;
        }

        // == DISPLAY ==
        public void Display()
        {
            Node current = head.forward[0];
            Console.Write("[ ");
            while (current.forward[0] != null)
            {
                Console.Write($"{current.data} ");
                current = current.forward[0];
            }
            Console.WriteLine("]");
        }

        // == ADD ==
        public void Update(int data)
        {
            // Store the node at each level that will be right BEFORE the new node
            Node[] lastNode = new Node[maxLevel + 1];
            Node? current = head;

            // search for last Node of each level
            for (int i=currentLevel; i >=0; i--)
            {
                while (current.forward[i] != null && current.forward[i].data < data) // headNode NOT null OR last NODE's value less than insert data
                {
                    current = current.forward[i]; 
                }
                lastNode[i] = current;  // record the "last node" of this level
            }

            // move back to level 0
            current = current.forward[0];

            if (current == null || current.data != data)    // if insert data not exist in the list
            {
                int newLevel = getRandomLevel();    // generate height level for new Node

                // if the generated height higher than our current recorded height
                // we need to process "head" as the predecessor for those new levels
                if (newLevel > currentLevel)
                {
                    for (int i=currentLevel + 1; i <= newLevel; i++)
                    {
                        lastNode[i] = head;
                    }
                    currentLevel = newLevel;    // set as new height record
                }

                // create new node and stitch it in
                Node newNode = new Node(data, newLevel);
                for (int i=0; i <= newLevel;i++)
                {
                    newNode.forward[i] = lastNode[i].forward[i];
                    lastNode[i].forward[i] = newNode;
                }
            }

            
        }
    }
}
