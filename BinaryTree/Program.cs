namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new binary tree
            BinaryTree tree = new BinaryTree();

            // Insert nodes into the tree
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);

            // Remove a node (value 2)
            tree.Remove(2);
        }
    }
}
