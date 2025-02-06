namespace BinaryTree
{
    // Represents a single node in the binary tree
    public class Node
    {
        public int Value { get; set; } // The value stored in the node
        public Node left, right;       // Left and right child nodes
        public Node(int value)
        {
            Value = value;
            left = null;
            right = null;
        }
    }
    public class BinaryTree
    {
        public Node Root { get; set; } // Root node of the tree
        public BinaryTree()
        {
            Root = null;
        }
        // Inserts a new node into the tree (level-order insertion)
        public void Insert(int value)
        {
            Node node = new Node(value);
            if (Root == null)
            {
                Root = node;
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                // If left child is missing, insert new node here
                if (current.left == null)
                {
                    current.left = node;
                    return;
                }
                else
                {
                    queue.Enqueue(current.left);
                }

                // If right child is missing, insert new node here
                if (current.right == null)
                {
                    current.right = node;
                    return;
                }
                else
                {
                    queue.Enqueue(current.right);
                }
            }
        }
        // Removes a node with the given value
        public void Remove(int value)
        {
            if (Root == null) return;

            // If root needs to be removed, replace it with merged subtrees
            if (Root.Value == value)
            {
                Root = MergeSubtrees(Root.left, Root.right);
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                // Check if left child is the target node
                if (current.left != null)
                {
                    if (current.left.Value == value)
                    {
                        current.left = MergeSubtrees(current.left.left, current.left.right);
                        return;
                    }
                    queue.Enqueue(current.left);
                }

                // Check if right child is the target node
                if (current.right != null)
                {
                    if (current.right.Value == value)
                    {
                        current.right = MergeSubtrees(current.right.left, current.right.right);
                        return;
                    }
                    queue.Enqueue(current.right);
                }
            }
        }
        // Merges two subtrees into one by attaching the right subtree
        // to the rightmost node of the left subtree
        private Node MergeSubtrees(Node left, Node right)
        {
            if (left == null) return right; // If there's no left subtree, return right
            if (right == null) return left; // If there's no right subtree, return left

            Node temp = left;
            while (temp.right != null)
            {
                temp = temp.right; // Find the rightmost node in the left subtree
            }
            temp.right = right; // Attach right subtree to the rightmost node of the left subtree
            return left;
        }
    }
}