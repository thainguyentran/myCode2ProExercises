using System;
using System.Collections.Generic;

namespace ShadyProgramming
{
    class Program
    {
        static void Main(String[] args)
        {
            BSTUltil bstUtil = new BSTUltil();
            TestCases tc = new TestCases();
            Node firstTree = null;
            Node secondTree = null;
            Node thirdTree = null;
            Node forthTree = null;
            int[] elements = { 27, 10, 30, 4, 16, 49, 4, 1, 7 };
            int count = 0;

            while (count < elements.Length)
            {
                firstTree = tc.correctInsert(firstTree, elements[count]);
                secondTree = tc.incorrectInsert(secondTree, elements[count]);
                count++;
            }

            tc.CustomInsert(ref thirdTree);
            forthTree = tc.CustomInsert(forthTree);

            printBST(firstTree);
            Console.WriteLine(bstUtil.isBST(firstTree) + "\n");

            printBST(secondTree);
            Console.WriteLine(bstUtil.isBST(secondTree) + "\n");

            printBST(thirdTree);
            Console.WriteLine(bstUtil.isBST(thirdTree) + "\n");

            printBST(forthTree);
            Console.WriteLine(bstUtil.isBST(forthTree) + "\n");
        }
        public static void printBST(Node root)
        {
            Console.WriteLine("The BST: ");
            Queue<Node> traverse = new Queue<Node>();

            if (root != null)
            {
                traverse.Enqueue(root);
                int count = traverse.Count;

                while (count > 0)
                {
                    Console.Write(traverse.Peek().data.ToString() + " ");
                    if (traverse.Peek().left != null)
                        traverse.Enqueue(traverse.Peek().left);
                    if (traverse.Peek().right != null)
                        traverse.Enqueue(traverse.Peek().right);
                    traverse.Dequeue();
                    count = count - 1;
                    if (count == 0)
                    {
                        Console.WriteLine("");
                        count = traverse.Count;
                    }
                }
            }
        }
    }
    class TestCases
    {
        public Node correctInsert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = correctInsert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = correctInsert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        public Node incorrectInsert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data >= root.data)
                {
                    cur = incorrectInsert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = incorrectInsert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        public Node CustomInsert(ref Node root)
        {
            root = new Node(3);
            root.left = new Node(2);
            root.left.left = new Node(1);
            root.left.right = new Node(4);
            return root;
        }

        public Node CustomInsert(Node root)
        {
            root = new Node(3);
            root.left = new Node(2);
            root.left.left = new Node(2);
            root.left.right = new Node(4);
            root.left.right.right = new Node(4);
            return root;
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

    class BSTUltil
    {
        const bool IS_BST = true;
        const bool IS_NOT_BST = false;
        
        public bool isBST(Node root)
        {
            if (root == null)
                return IS_NOT_BST;
            else
            {
                Queue<Node> bSTQ = new Queue<Node>();

                bSTQ.Enqueue(root);
                while (bSTQ.Count > 0)
                {
                    Node curr = bSTQ.Dequeue();
                    if (curr.left != null)
                    {
                        if (curr.data < curr.left.data)
                            return IS_NOT_BST;
                        else 
                            bSTQ.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        if (curr.data >= curr.right.data)
                            return IS_NOT_BST;
                        else 
                            bSTQ.Enqueue(curr.right);
                    }
                }
                return IS_BST;
            }
        }
    }
}
