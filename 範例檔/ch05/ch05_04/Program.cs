using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch05_04
{
    class QueueNode    // 佇列節點類別
    {
        public int data;        // 節點資料
        public QueueNode next;  // 指向下一個節點
                                //建構子
        public QueueNode(int data)
        {
            this.data = data;
            next = null;
        }
    };
    class Linked_List_Queue
    { //佇列類別
        public QueueNode front; //佇列的前端指標
        public QueueNode rear;  //佇列的尾端指標

        //建構子
        public Linked_List_Queue() { front = null; rear = null; }

        //方法enqueue:佇列資料的存入                          
        public bool Enqueue(int value)
        {
            QueueNode node = new QueueNode(value); //建立節點
                                                   //檢查是否為空佇列
            if (rear == null)
                front = node; //新建立的節點成為第1個節點
            else
                rear.next = node; //將節點加入到佇列的尾端
            rear = node; //將佇列的尾端指標指向新加入的節點
            return true;
        }

        //方法dequeue:佇列資料的取出
        public int Dequeue(int action)
        {
            int value;
            QueueNode tempNode, startNode;
            //從前端取出資料
            if (!(front == null) && action == 1)
            {
                if (front == rear) rear = null;
                value = front.data; //將佇列資料從前端取出
                front = front.next; //將佇列的前端指標指向下一個
                return value;
            }
            //從尾端取出資料   
            else if (!(rear == null) && action == 2)
            {
                startNode = front;  //先記下前端的指標值
                value = rear.data;  //取出目前尾端的資料
                                    //找尋最尾端節點的前一個節點
                tempNode = front;
                while (front.next != rear && front.next != null) { front = front.next; tempNode = front; }
                front = startNode;  //記錄從尾端取出資料後的佇列前端指標
                rear = tempNode;    //記錄從尾端取出資料後的佇列尾端指標
                                    //下一行程式是指當佇列中僅剩下最節點時,取出資料後便將front及rear指向null
                if ((front.next == null) || (rear.next == null)) { front = null; rear = null; }
                return value;
            }
            else return -1;
        }
    } //佇列類別宣告結束
    class Program
    {
        static void Main(string[] args)
        {
            Linked_List_Queue queue = new Linked_List_Queue(); //建立佇列物件
            int temp;
            WriteLine("以鏈結串列來實作雙向佇列");
            WriteLine("====================================");
            WriteLine("在雙向佇列前端加入第1筆資料，此資料值為1");
            queue.Enqueue(1);
            WriteLine("在雙向佇列前端加入第2筆資料，此資料值為3");
            queue.Enqueue(3);
            WriteLine("在雙向佇列前端加入第3筆資料，此資料值為5");
            queue.Enqueue(5);
            WriteLine("在雙向佇列前端加入第4筆資料，此資料值為7");
            queue.Enqueue(7);
            WriteLine("在雙向佇列前端加入第5筆資料，此資料值為9");
            queue.Enqueue(9);
            WriteLine("====================================");
            temp = queue.Dequeue(1);
            WriteLine("從雙向佇列前端依序取出的元素資料值為：" + temp);
            temp = queue.Dequeue(2);
            WriteLine("從雙向佇列尾端依序取出的元素資料值為：" + temp);
            temp = queue.Dequeue(1);
            WriteLine("從雙向佇列前端依序取出的元素資料值為：" + temp);
            temp = queue.Dequeue(2);
            WriteLine("從雙向佇列尾端依序取出的元素資料值為：" + temp);
            temp = queue.Dequeue(1);
            WriteLine("從雙向佇列前端依序取出的元素資料值為：" + temp);
            WriteLine();
            ReadKey();
        }
    }
}
