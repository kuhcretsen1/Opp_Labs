namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(10);
            Console.WriteLine(list.Contains(23)); 
            Console.WriteLine("Elements from list:");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.RemoveLast();
            Console.WriteLine("Elements from list:");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}
