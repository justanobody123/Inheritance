using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainers
{
	internal class MyStack<X>
	{
		Node<X> Head;
        public MyStack()
        {
            Head = null;
        }
        public void Push(X item)
        {
            Node<X> newNode = new Node<X>(item);
            newNode.Next = Head;
            Head = newNode;
        }
        public X Pop() 
        {
			X toReturn = Head.Data;
			Head = Head.Next;
			return toReturn;
		}
        public X Peek()
        {
            return Head.Data;
        }
        public void Clear()
        {
            Head = null;
            Head.Next = null;//Опционально, поскольку связь будет прервана и после объявления хэд = нул.
        }
    }
}
