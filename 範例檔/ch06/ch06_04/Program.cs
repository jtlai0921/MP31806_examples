using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch06_04
{
    // 以鏈結串列實作二元運算樹

    //節點類別的宣告
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
    //二元搜尋樹類別宣告
    class Binary_Search_Tree
    {
        public TreeNode rootNode; //二元樹的根節點
                                  //建構子:建立空的二元搜尋樹
        public Binary_Search_Tree() { rootNode = null; }
        //建構子:利用傳入一個陣列的參數來建立二元樹
        public Binary_Search_Tree(int[] data)
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
                { //符合這個判斷表示此節點在左子樹
                    if (currentNode.left_Node == null)
                    {
                        currentNode.left_Node = new TreeNode(value);
                        return;
                    }
                    else currentNode = currentNode.left_Node;
                }
                else
                { //符合這個判斷表示此節點在右子樹
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

    class Expression_Tree:Binary_Search_Tree
    {
   // 建構子
   public Expression_Tree(char[] information, int index)
    {
        // Create方法可以將二元樹的陣列表示法轉換成鏈結表示法
        rootNode = Create(information, index);
    }
    // Create方法的程式內容
    public TreeNode Create(char[] sequence, int index)
    {
        TreeNode tempNode;
        if (index >= sequence.Length)   // 作為遞迴呼叫的出口條件
            return null;
        else
        {
            tempNode = new TreeNode((int)sequence[index]);
            // 建立左子樹
            tempNode.left_Node = Create(sequence, 2 * index);
            // 建立右子樹
            tempNode.right_Node = Create(sequence, 2 * index + 1);
            return tempNode;
        }
    }
    // PreOrder(前序走訪)方法的程式內容
    public void PreOrder(TreeNode node)
    {
        if (node != null)
        {
           Write((char)node.value);
            PreOrder(node.left_Node);
            PreOrder(node.right_Node);
        }
    }
    // InOrder(中序走訪)方法的程式內容
    public void InOrder(TreeNode node)
    {
        if (node != null)
        {
            InOrder(node.left_Node);
               Write((char)node.value);
            InOrder(node.right_Node);
        }
    }
    // PostOrder(後序走訪)方法的程式內容
    public void PostOrder(TreeNode node)
    {
        if (node != null)
        {
            PostOrder(node.left_Node);
            PostOrder(node.right_Node);
               Write((char)node.value);
        }
    }
    // 判斷運算式如何運算的方法宣告內容
    public int Condition(char oprator, int num1, int num2)
    {
        switch (oprator)
        {
            case '*': return (num1 * num2); // 乘法請回傳num1 * num2
            case '/': return (num1 / num2); // 除法請回傳num1 / num2
            case '+': return (num1 + num2); // 加法請回傳num1 + num2
            case '-': return (num1 - num2); // 減法請回傳num1 - num2
            case '%': return (num1 % num2); // 取餘數法請回傳num1 % num2
        }
        return -1;
    }
    // 傳入根節點,用來計算此二元運算樹的值
    public int Answer(TreeNode node)
    {
        int firstnumber = 0;
        int secondnumber = 0;
            // 遞迴呼叫的出口條件
            if (node.left_Node == null && node.right_Node == null)
                // 將節點的值轉換成數值後傳回
                return Convert.ToInt32((char)node.value)-48;
            else
            {
                firstnumber = Answer(node.left_Node);  // 計算左子樹運算式的值
                secondnumber = Answer(node.right_Node); // 計算右子樹運算式的值
                return Condition((char)node.value, firstnumber, secondnumber);
            }
    }
}
class Program
    {
        static void Main(string[] args)
        {
            // 將二元運算樹以陣列的方式來宣告
            // 第一筆運算式
            char[] information1 = { ' ', '+', '*', '%', '6', '3', '9', '5' };
            // 第二筆運算式
            char[] information2 = {' ','+','+','+','*','%','/','*',
                            '1','2','3','2','6','3','2','2' };
            Expression_Tree exp1 = new Expression_Tree(information1, 1);
            WriteLine("====二元運算樹數值運算範例 1: ====");
            WriteLine("=================================");
            Write("===轉換成中序運算式===:  ");
            exp1.InOrder(exp1.rootNode);
            Write("\n===轉換成前序運算式===:  ");
            exp1.PreOrder(exp1.rootNode);
            Write("\n===轉換成後序運算式===:  ");
            exp1.PostOrder(exp1.rootNode);
            // 計算二元樹運算式的運算結果
            Write("\n此二元運算樹,經過計算後所得到的結果值: ");
            WriteLine(exp1.Answer(exp1.rootNode));
            // 建立第二棵二元搜尋樹物件
            Expression_Tree exp2 = new Expression_Tree(information2, 1);
            WriteLine();
            WriteLine("====二元運算樹數值運算範例 2: ====");
            WriteLine("=================================");
            Write("===轉換成中序運算式===:  ");
            exp2.InOrder(exp2.rootNode);
            Write("\n===轉換成前序運算式===:  ");
            exp2.PreOrder(exp2.rootNode);
            Write("\n===轉換成後序運算式===:  ");
            exp2.PostOrder(exp2.rootNode);
            // 計算二元樹運算式的運算結果
            Write("\n此二元運算樹,經過計算後所得到的結果值: ");
            WriteLine(exp2.Answer(exp2.rootNode));
            ReadKey();
        }
    }
}
