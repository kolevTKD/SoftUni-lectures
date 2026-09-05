using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BinarySearchTreeExample
{
    class Node // This class represents a node in a binary search tree
    {
        public int label; // This represents the value of the node
        public Node left; // This represents the left branch
        public Node right; // This represents the right branch

        public Node(int data) // We call this constructor when we want to create a new node and pass the value we want to give it
        {
            label = data;
            left = null;
            right = null;
        }

        public void AddNode(Node root)
        {
            if (root == null)
            {
                Console.WriteLine("Could not call 'AddNode' because the root was null");
                return;
            }
            else if (root.label == label)
            {
                Console.WriteLine("Duplicate values are not alowed");
                return;
            }
            else if (label < root.label)
            {
                //go left
                if (root.left != null)
                {
                    AddNode(root.left);
                }
                else
                {
                    root.left = this;
                    Console.WriteLine($"Added {label} to the left of {root.label}");
                }
            }
            else if (label > root.label)
            {
                //go right
                if (root.right != null)
                {
                    AddNode(root.right);
                }
                else
                {
                    root.right = this;

                    Console.WriteLine($"Added {label} to the right of {root.label}");
                }

            }

        }

        public void DeleteNode(Node root)
        {
            Node parent = this.FindParent(root);

            if (left == null && right == null) //No children
            {
                if (parent.left == this)
                    parent.left = null;

                else if (parent.right == this)
                    parent.right = null;
            }

            else if (left == null || right == null) //One child
            {
                if (parent.left == this)
                {
                    if (left != null)
                        parent.left = left;
                    else
                        parent.left = right;
                }

                else if (parent.right == this)
                {
                    if (left != null)
                        parent.right = left;
                    else
                        parent.right = right;
                }
            }
            else //Two children
            {
                var child = this.right;

                while (child.left != null)
                {
                    child = child.left;
                }

                var temp = this.label;
                this.label = child.label;
                child.label = temp;
                child.DeleteNode(root);
            }
        }
        public Node FindParent(Node root)
        {
            if (root.left == this || root.right == this)
                return root;

            else if (this.label > root.label)
                return this.FindParent(root.left);

            else
                return this.FindParent(root.right);
        }

        public string LevelOrderTraversal()
        {
            Queue<Node> queue = new Queue<Node>();
            List<int> result = new List<int>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                result.Add(current.label);

                if (current.left != null)
                    queue.Enqueue(current.left);

                if (current.right != null)
                    queue.Enqueue(current.right);
            }

            return string.Join(", ", result);
        }
    }
}
