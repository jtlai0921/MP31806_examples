using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch06_02
{
    class TreeNode
    {
        public int value;
        public TreeNode left_Node;
        public TreeNode right_Node;
        // TreeNode建構子
        public TreeNode(int value)
        {
            this.value = value;
            this.left_Node = null;
            this.right_Node = null;
        }
    }
    //二元樹類別宣告
    class BinaryTree
    {
        public TreeNode rootNode; //二元樹的根節點
                                  //建構子:利用傳入一個陣列的參數來建立二元樹
        public BinaryTree(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
                Add_Node_To_Tree(data[i]);
        }
        //將指定的值加入到二元樹中適當的節點
        void Add_Node_To_Tree(int value)
        {
            TreeNode currentNode = rootNode;
            if (rootNode == null)
            { //建立樹根
                rootNode = new TreeNode(value);
                return;
            }
            //建立二元樹
            while (true)
            {
                if (value < currentNode.value)
                { //在左子樹
                    if (currentNode.left_Node == null)
                    {
                        currentNode.left_Node = new TreeNode(value);
                        return;
                    }
                    else currentNode = currentNode.left_Node;
                }
                else
                { //在右子樹
                    if (currentNode.right_Node == null)
                    {
                        currentNode.right_Node = new TreeNode(value);
                        return;
                    }
                    else currentNode = currentNode.right_Node;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int ArraySize = 10;
            int tempdata;
            int[] content = new int[ArraySize];
            WriteLine("請連續輸入" + ArraySize + "筆資料");
            for (int i = 0; i < ArraySize; i++)
            {
                Write("請輸入第" + (i + 1) + "筆資料: ");
                tempdata = int.Parse(ReadLine());
                content[i] = tempdata;
            }
            new BinaryTree(content);
            WriteLine("===以鏈結串列方式建立二元樹,成功!!!===");
            ReadKey();
        }
    }
}
