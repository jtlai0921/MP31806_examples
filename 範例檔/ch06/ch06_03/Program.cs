using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch06_03
{
    class TreeNode
    {
        public int value;
        public TreeNode left_Node;
        public TreeNode right_Node;

        public TreeNode(int value)
        {
            this.value = value;
            this.left_Node = null;
            this.right_Node = null;
        }
    }
    class BinaryTree
    {
        public TreeNode rootNode;

        public void Add_Node_To_Tree(int value)
        {
            if (rootNode == null)
            {
                rootNode = new TreeNode(value);
                return;
            }
            TreeNode currentNode = rootNode;
            while (true)
            {
                if (value < currentNode.value)
                {
                    if (currentNode.left_Node == null)
                    {
                        currentNode.left_Node = new TreeNode(value);
                        return;
                    }
                    else
                        currentNode = currentNode.left_Node;
                }
                else
                {
                    if (currentNode.right_Node == null)
                    {
                        currentNode.right_Node = new TreeNode(value);
                        return;
                    }
                    else
                        currentNode = currentNode.right_Node;
                }
            }
        }
        public void InOrder(TreeNode node)
        {
            if (node != null)
            {
                InOrder(node.left_Node);
                Write("[" + node.value + "] ");
                InOrder(node.right_Node);
            }
        }

        public void PreOrder(TreeNode node)
        {
            if (node != null)
            {
                Write("[" + node.value + "] ");
                PreOrder(node.left_Node);
                PreOrder(node.right_Node);
            }
        }

        public void PostOrder(TreeNode node)
        {
            if (node != null)
            {
                PostOrder(node.left_Node);
                PostOrder(node.right_Node);
                Write("[" + node.value + "] ");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int[] arr = { 7, 4, 1, 5, 16, 8, 11, 12, 15, 9, 2 }; /*原始陣列*/
            BinaryTree tree = new BinaryTree();
            Write("原始陣列內容: \n");
            for (i = 0; i < 11; i++)
                Write("[" + arr[i] + "] ");
            WriteLine();
            for (i = 0; i < arr.Length; i++) tree.Add_Node_To_Tree(arr[i]);
            Write("[二元樹的內容]\n");
            Write("前序走訪結果：\n");  /*列印前、中、後序走訪結果*/
            tree.PreOrder(tree.rootNode);
            WriteLine();
            Write("中序走訪結果：\n");
            tree.InOrder(tree.rootNode);
            WriteLine();
            Write("後序走訪結果：\n");
            tree.PostOrder(tree.rootNode);
            ReadKey();
        }
    }
}
