using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    //Author: Sebastian Arroyo
    //Purpose: Queue without Queue
    //Restrictions: None
    class MyQueue
    {
        private List<int> queueList = new List<int>();

        //Purpose: Enqueue
        //Restrictions:None
        public void Enqueue(int n)
        {
            queueList.Add(n);
        }

        //Purpose: Dequeue
        //Restrictions: Can't dequeue when stack is empty
        public int Dequeue()
        {
            if (queueList.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty. Cannot Dequeue.");
            }

            int dequeuedValue = queueList[0];
            queueList.RemoveAt(0);
            return dequeuedValue;
        }

        //Purpose: Peek
        //Restrictions: Can't peek when stack is empty
        public int Peek()
        {
            if (queueList.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty. Cannot Peek.");
            }

            return queueList[0];
        }
    }
}
