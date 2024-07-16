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
			Head = Tail = null;
		}
	}
}
