using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch06_06
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
    class BinarySearch
    {
        public TreeNode rootNode;
        public static int count = 1;
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

        public bool FindTree(TreeNode node, int value)
        {
            if (node == null)
            {
                return false;
            }
            else if (node.value == value)
            {
               Write("共搜尋" + count + "次\n");
                return true;
            }
            else if (value < node.value)
            {
                count += 1;
                return FindTree(node.left_Node, value);
            }
            else
            {
                count += 1;
                return FindTree(node.right_Node, value);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int i, value;
            int[] arr = { 7, 4, 1, 5, 13, 8, 11, 12, 15, 9, 2 };
            Write("原始陣列內容: \n");
            for (i = 0; i < 11; i++)
               Write("[" + arr[i] + "] ");
            WriteLine();
            BinarySearch tree = new BinarySearch();
            for (i = 0; i < 11; i++) tree.Add_Node_To_Tree(arr[i]);
            Write("請輸入搜尋值： ");
            value = int.Parse(ReadLine());
            if (tree.FindTree(tree.rootNode, value))
               Write("您要找的值 [" + value + "] 有找到!!\n");
	        else
               Write("抱歉，沒有找到 \n");

            ReadKey();
        }
    }
}
