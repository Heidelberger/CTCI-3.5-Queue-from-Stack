using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_3._5_Queue_from_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeaderMsg(3, 5, "Queue from Two Stacks");

            SwapEveryTime();

            SwapWhenNeeded();

            Console.ReadLine();
        }

        private static void SwapWhenNeeded()
        {
            Console.WriteLine();
            Console.WriteLine("Swapping only when needed:");
            Console.WriteLine();

            myQueue_SwapWhenNeeded SWN = new myQueue_SwapWhenNeeded();
            Console.WriteLine("Enqueue: 1, 2, 3, 4, 5");
            SWN.Enqueue(1);
            SWN.Enqueue(2);
            SWN.Enqueue(3);
            SWN.Enqueue(4);
            SWN.Enqueue(5);

            Console.WriteLine("Peek:    " + SWN.Peek());

            Console.WriteLine("Dequeue: " + SWN.Dequeue());
            Console.WriteLine("Dequeue: " + SWN.Dequeue());
            Console.WriteLine("Dequeue: " + SWN.Dequeue());

            Console.WriteLine("Peek:    " + SWN.Peek());

            Console.WriteLine("Enqueue: 6, 7, 8");
            SWN.Enqueue(6);
            SWN.Enqueue(7);
            SWN.Enqueue(8);

            Console.WriteLine("Peek:    " + SWN.Peek());

            Console.WriteLine("Dequeue: " + SWN.Dequeue());
            Console.WriteLine("Dequeue: " + SWN.Dequeue());
            Console.WriteLine("Dequeue: " + SWN.Dequeue());

            Console.WriteLine("Dequeue: " + SWN.Dequeue());
            Console.WriteLine("Dequeue: " + SWN.Dequeue());

            Console.WriteLine();
            Console.WriteLine("SWAPCOUNT: " + SWN.GetSwapCount());
        }

        private static void SwapEveryTime()
        {
            Console.WriteLine();
            Console.WriteLine("Swapping on every enqueue" +
                ":");
            Console.WriteLine();

            myQueue_SwapEveryEnqueue SEE = new myQueue_SwapEveryEnqueue();
            Console.WriteLine("Enqueue: 1, 2, 3, 4, 5");
            SEE.Enqueue(1);
            SEE.Enqueue(2);
            SEE.Enqueue(3);
            SEE.Enqueue(4);
            SEE.Enqueue(5);

            Console.WriteLine("Peek:    " + SEE.Peek());

            Console.WriteLine("Dequeue: " + SEE.Dequeue());
            Console.WriteLine("Dequeue: " + SEE.Dequeue());
            Console.WriteLine("Dequeue: " + SEE.Dequeue());

            Console.WriteLine("Peek:    " + SEE.Peek());

            Console.WriteLine("Enqueue: 6, 7, 8");
            SEE.Enqueue(6);
            SEE.Enqueue(7);
            SEE.Enqueue(8);

            Console.WriteLine("Peek:    " + SEE.Peek());

            Console.WriteLine("Dequeue: " + SEE.Dequeue());
            Console.WriteLine("Dequeue: " + SEE.Dequeue());
            Console.WriteLine("Dequeue: " + SEE.Dequeue());

            Console.WriteLine("Dequeue: " + SEE.Dequeue());
            Console.WriteLine("Dequeue: " + SEE.Dequeue());



            Console.WriteLine();
            Console.WriteLine("SWAPCOUNT: " + SEE.GetSwapCount());
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }

    class myQueue_SwapEveryEnqueue
    {
        static int swapcount = 0;

        Stack<int> stackOld = new Stack<int>();
        Stack<int> stackNew = new Stack<int>();

        public void Enqueue(int passed_int)
        {
            while (stackOld.Count > 0)
                stackNew.Push(stackOld.Pop());

            stackNew.Push(passed_int);

            while (stackNew.Count > 0)
                stackOld.Push(stackNew.Pop());

            ++swapcount;
        }

        public int Peek()
        {
            return stackOld.Peek();           
        }

        public int Dequeue()
        {
            return stackOld.Pop();
        }

        public int GetSwapCount()
        {
            return swapcount;
        }
    }

    class myQueue_SwapWhenNeeded
    {
        static int swapcount = 0;

        Stack<int> stackOld = new Stack<int>();
        Stack<int> stackNew = new Stack<int>();

        public void Enqueue(int passed_int)
        {
            stackNew.Push(passed_int);            
        }

        public int Peek()
        {
            if (stackOld.Count == 0)
                SwapStacks();

            return stackOld.Peek();
        }

        public int Dequeue()
        {
            if (stackOld.Count == 0)
                SwapStacks();

            return stackOld.Pop();
        }

        private void SwapStacks()
        {
            while (stackOld.Count > 0)
                stackNew.Push(stackOld.Pop());

            while (stackNew.Count > 0)
                stackOld.Push(stackNew.Pop());

            ++swapcount;
        }

        public int GetSwapCount()
        {
            return swapcount;
        }
    }
}
