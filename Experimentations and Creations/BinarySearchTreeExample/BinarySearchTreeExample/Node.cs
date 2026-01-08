using System;
using System.Collections.Generic;
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
            else if (root.label == null)
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
    }
}
