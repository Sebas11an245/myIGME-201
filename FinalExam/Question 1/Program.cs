using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    //Author: Sebastian Arroyo
    //Purpose:Stack without Stack
    //Restrictions: None
    class MyStack
    {
        private List<int> stackList = new List<int>();

        //Purpose: Push
        //Restrictions:None
        public void Push(int n)
        {
            stackList.Add(n);
        }
        
        //Purpose: Pop
        //Restrictions: Can't pop when stack is empty
        public int Pop()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty. Cannot Pop.");
            }

            int poppedValue = stackList[stackList.Count - 1];
            stackList.RemoveAt(stackList.Count - 1);
            return poppedValue;
        }

        //Purpose: Peek
        //Restrictions: Can't peek when stack is empty
        public int Peek()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty. Cannot Peek.");
            }

            return stackList[stackList.Count - 1];
        }
    }
}
