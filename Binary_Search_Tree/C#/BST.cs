using System;
using System.Collections.Generic;

// Node class to define the structure of the node
public class Node
{
    public int data;
    public Node left, right;

    // Parameterized Constructor
    public Node(int val)
    {
        data = val;
        left = right = null;
    }
}

public class Program
{
    // Function to insert nodes
    public static Node Insert(Node root, int data)
    {
        // If tree is empty, new node becomes the root
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        // Queue to traverse the tree and find the position to insert the node
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            Node temp = q.Dequeue();
            // Insert node as the left child of the parent node
            if (temp.left == null)
            {
                temp.left = new Node(data);
                break;
            }
            // If the left child is not null, push it to the queue
            else
                q.Enqueue(temp.left);

            // Insert node as the right child of parent node
            if (temp.right == null)
            {
                temp.right = new Node(data);
                break;
            }
            // If the right child is not null, push it to the queue
            else
                q.Enqueue(temp.right);
        }
        return root;
    }

    /* function to delete the given deepest node (d_node) in binary tree */
    public static void DeleteDeepest(Node root, Node d_node)
    {
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        // Do level order traversal until last node
        Node temp;
        while (q.Count != 0)
        {
            temp = q.Dequeue();
            if (temp == d_node)
            {
                temp = null;
                d_node = null;
                return;
            }
            if (temp.right != null)
            {
                if (temp.right == d_node)
                {
                    temp.right = null;
                    d_node = null;
                    return;
                }
                else
                    q.Enqueue(temp.right);
            }
            if (temp.left != null)
            {
                if (temp.left == d_node)
                {
                    temp.left = null;
                    d_node = null;
                    return;
                }
                else
                    q.Enqueue(temp.left);
            }
        }
    }

    /* function to delete element in binary tree */
    public static Node Deletion(Node root, int key)
    {
        if (root == null)
            return null;
        if (root.left == null && root.right == null)
        {
            if (root.data == key)
                return null;
            else
                return root;
        }

        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        Node temp = new Node(0);
        Node key_node = null;
        // Do level order traversal to find deepest node (temp) and node to be deleted (key_node)
        while (q.Count != 0)
        {
            temp = q.Dequeue();
            if (temp.data == key)
                key_node = temp;
            if (temp.left != null)
                q.Enqueue(temp.left);
            if (temp.right != null)
                q.Enqueue(temp.right);
        }

        if (key_node != null)
        {
            int x = temp.data;
            key_node.data = x;
            DeleteDeepest(root, temp);
        }
        return root;
    }

    // Inorder tree traversal (Left - Root - Right)
    public static void InorderTraversal(Node root)
    {
        if (root == null)
            return;
        InorderTraversal(root.left);
        Console.Write(root.data + " ");
        InorderTraversal(root.right);
    }

    // Preorder tree traversal (Root - Left - Right)
    public static void PreorderTraversal(Node root)
    {
        if (root == null)
            return;
        Console.Write(root.data + " ");
        PreorderTraversal(root.left);
        PreorderTraversal(root.right);
    }

    // Postorder tree traversal (Left - Right - Root)
    public static void PostorderTraversal(Node root)
    {
        if (root == null)
            return;
        PostorderTraversal(root.left);
        PostorderTraversal(root.right);
        Console.Write(root.data + " ");
    }

    // Function for Level order tree traversal
    public static void LevelorderTraversal(Node root)
    {
        if (root == null)
            return;

        // Queue for level order traversal
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            Node temp = q.Dequeue();
            Console.Write(temp.data + " ");
            // Push left child in the queue
            if (temp.left != null)
                q.Enqueue(temp.left);
            // Push right child in the queue
            if (temp.right != null)
                q.Enqueue(temp.right);
        }
    }

    /* Driver function to check the above algorithm. */
    public static void Main(string[] args)
    {
        Node root = null;
        // Insertion of nodes
        root = Insert(root, 10);
        root = Insert(root, 20);
        root = Insert(root, 30);
        root = Insert(root, 40);

        Console.Write("Preorder traversal: ");
        PreorderTraversal(root);

        Console.Write("\nInorder traversal: ");
        InorderTraversal(root);

        Console.Write("\nPostorder traversal: ");
        PostorderTraversal(root);

        Console.Write("\nLevel order traversal: ");
        LevelorderTraversal(root);

        // Delete the node with data = 20
        root = Deletion(root, 20);

        Console.Write("\nInorder traversal after deletion: ");
        InorderTraversal(root);
    }
}
