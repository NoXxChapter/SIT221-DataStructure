namespace SkipList
{
    public class Program
    {
        public static void Main()
        {
            SkipNode list = new SkipNode(4);
            for (int i=0; i<10;i++)
            {
                list.Update(i);
            }
            list.Display();
        }
    }
}
