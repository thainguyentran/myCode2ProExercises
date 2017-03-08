using System;
using System.Collections.Generic;

namespace ShadyProgramming
{
    class Program
    {
        static void Main(String[] args)
        {
            Node root = null;
            try
            {
                ConstructBT(ref root);
                PrintBTUpsideDown(root);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("The program cannot run due to this error: {0}", e.Message);
            }
            
        }
        private static void ConstructBT(ref Node root)
        {
            root = new Node(1);
            root.left = new Node(5);
            root.right = new Node(2);
            root.left.left = new Node(7);
            root.left.right = new Node(6);
            root.right.left = new Node(8);
            root.right.right = new Node(3);
            root.right.right.right = new Node (4);
        }
        public static void PrintBTUpsideDown(Node root)
        {
            Console.WriteLine("Binary Tree up side down: ");
            Queue<Node> traverse = new Queue<Node>();
            List<string> BST = new List<string>();
            string line = "";
            if (root != null)
            {
                traverse.Enqueue(root);
                int count = traverse.Count;

                while (count > 0)
                {
                    line += traverse.Peek().data.ToString() + " ";
                    if (traverse.Peek().left != null) traverse.Enqueue(traverse.Peek().left);
                    if (traverse.Peek().right != null) traverse.Enqueue(traverse.Peek().right);
                    traverse.Dequeue();
                    count = count - 1;
                    if (count == 0)
                    {
                        BST.Add(line);
                        line = "";
                        count = traverse.Count;
                    }
                }

                for (int i = BST.Count - 1; i >= 0; i--)
                    Console.WriteLine(BST[i].TrimEnd(' '));
            }
        }
    }

    class Node
    {
        public Node left, right;
        public int data;

        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }  
}
