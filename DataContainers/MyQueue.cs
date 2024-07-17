using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainers
{
	internal class MyQueue<X>
	{
		Node<X> Head;
		Node<X> Tail;
		public MyQueue()
		{
			Head = Tail = null;
            Console.WriteLine($"QueueConstructor:\t{GetHashCode()}");
        }
		public MyQueue(MyQueue<X> other)
		{
			for (Node<X> it = other.Head; it != null; it = it.Next)
			{
				Push(it.Data);
			}
            Console.WriteLine($"QCopyConstructor:{this.GetHashCode()}");
        }
		~MyQueue()
		{
			Clear();
			System.GC.Collect();
            Console.WriteLine($"QueueDestructor:\t{GetHashCode()}");
		}
		public void Push(X item)
		{
			Node<X> newNode = new Node<X>(item);
			if (Head == null)
			{
				Head = Tail = newNode;
			}
			else
			{
				newNode.Previous = Tail;
				Tail.Next = newNode;
				Tail = newNode;
			}
		}
		public X Pop()
		{
			if (Head == null)
			{
				throw new InvalidOperationException("Очередь пуста.");
			}
			X toReturn = Head.Data;
			Head = Head.Next;
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
			if (Head != null)
			{
				Head.Previous = null;
			}
			else
			{
				Tail = null;
			}
			return toReturn;
		}
		public X Peek()
		{
			if (Head == null)
			{
				throw new InvalidOperationException("Очередь пуста");
			}
			return Head.Data;
		}
		public void Clear()
		{
			while(Head!=null)Pop();
			Head = Tail = null;
		}
		public bool IsEmpty()
		{
			return Head == null;
		}
	}
}
