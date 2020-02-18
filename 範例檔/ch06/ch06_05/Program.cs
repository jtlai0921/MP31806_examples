using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch06_05
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
            int value;
            BinaryTree tree = new BinaryTree();
            Write("請輸入資料，結束請輸入-1： \n");
            while (true)
            {
                value = int.Parse(ReadLine());
                if (value == -1)
                    break;
                tree.Add_Node_To_Tree(value);
            }
            Write("====================: \n");
            Write("排序完成結果: \n");
            tree.InOrder(tree.rootNode);
            WriteLine();
            ReadKey();
        }
    }
}
