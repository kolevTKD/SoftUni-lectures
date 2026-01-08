namespace BinarySearchTreeExample
{
    public class Program
    {
        static void Main()
        {
            Node root = null;
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                int x = rnd.Next(0, 100);
                Node n = new Node(x);

                if (root == null)
                {
                    Console.WriteLine($"Setting {n.label} to the root");
                    root = n;
                }
                else
                {
                    n.AddNode(root);
                }
            }
        }
    }
}
