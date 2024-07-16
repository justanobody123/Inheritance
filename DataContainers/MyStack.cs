using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainers
{
	internal class MyStack<X>
	{
		Node<X> Top;
		public MyStack()
		{
			Top = null;
		}
		public void Push(X item)
		{
			Node<X> newNode = new Node<X>(item);
			newNode.Next = Top;
			Top = newNode;
		}
		public X Pop()
		{
			if (Top == null)
			{
				throw new InvalidOperationException("Стек пуст.");
			}
			X toReturn = Top.Data;
			Top = Top.Next;
			return toReturn;

		}
		public X Peek()
		{
			if (Top == null)
			{
				throw new InvalidOperationException("Стек пуст.");
			}
			return Top.Data;
		}
		public void Clear()
		{
			Top = null;
		}
		public bool IsEmpty()
		{
			return Top == null;
		}
	}
}
