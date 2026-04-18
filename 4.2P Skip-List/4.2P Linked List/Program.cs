public class Program
{
   public static void Main(String[] args)
    {
        LinkedList list = new LinkedList(); 

        for (int i=0; i<10;i++)
        {
            list.Push(i);
        }
        list.Display();

        list.Pop();
        list.Display();

        list.Poll();
        list.Display();

        list.Offer(999);
        list.Display();

        list.Search(7);
    }
}