namespace SkipList
{
    public class Node
    {
        public int? data;
        public Node[] forward;
        public Node(int data, int forward)
        {
            this.data = data;
            this.forward = new Node[forward + 1];       // levelSpace = level + 1;
                                                        // ex: level_0 has 1 indice (0) - level_1 has 2 indices (0,1)
        }
    }
}
