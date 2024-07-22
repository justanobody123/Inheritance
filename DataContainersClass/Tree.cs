#undef DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataContainersClass
{
	internal class Tree : IDisposable
	{
		public class Element
		{
			public int Data;
			public int hash;
			public Element pleft;
			public Element pright;
			public Element(int Data, Element pleft = null, Element pright = null)
			{
				this.hash = GetHashCode();
				this.Data = Data;
				this.pleft = pleft;
				this.pright = pright;
#if DEBUG
				Console.WriteLine($"ECtor:\t{GetHashCode()}");
#endif
			}
			~Element()
			{
#if DEBUG
				Console.WriteLine($"EDtor:\t{GetHashCode()}");
#endif
			}
		}
		public Element Root;
		public Tree()
		{
			Console.WriteLine($"TCtor:\t{GetHashCode()}");
		}
		~Tree()
		{
			Dispose();
			//Clear();
			//Root = null;
			//System.GC.Collect();
			//System.GC.WaitForPendingFinalizers();
			Console.WriteLine($"TDtor:\t{GetHashCode()}");
		}
		public void Clear()
		{
			Clear(ref Root);
		}
		void Clear(ref Element Root)
		{
			if (Root == null) return;
			Clear(ref Root.pleft);
			Clear(ref Root.pright);
			//System.GC.SuppressFinalize(Root);
			Root = null;
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
		}
		public void Dispose()
		{
			System.GC.SuppressFinalize(this);
		}
		public void Insert(int Data)
		{
			Insert(Data, this.Root);
		}
		void Insert(int Data, Element Root)
		{
			if (this.Root == null) this.Root = new Element(Data);
			if (Root == null) return;
			if (Data < Root.Data)
			{
				if (Root.pleft == null)
				{
					Root.pleft = new Element(Data);
				}
				else
				{
					Insert(Data, Root.pleft);
				}
			}
			else if (Data > Root.Data)
			{
				if (Root.pright == null)
				{
					Root.pright = new Element(Data);
				}
				else
				{
					Insert(Data, Root.pright);
				}
			}
		}
		public void Print()
		{
			Print(this.Root);
			Console.WriteLine();
		}
		void Print(Element Root)
		{
			if (Root == null)
			{
				return;
			}
			Print(Root.pleft);
			Console.Write($"{Root.Data}\t");
			Print(Root.pright);
		}
		public void PrintTree()
		{
			PrintTree(Root, "", true);
		}

		private void PrintTree(Element Root, string padding, bool right)
		{
			if (Root != null)
			{
				Console.Write(padding);
				if (Root == this.Root)
				{
					Console.Write("Root->");
					padding += "      ";
				}
				else if (right)
				{
					Console.Write("R->");
					padding += "   ";
				}
				else
				{
					Console.Write("L->");
					padding += "|  ";
				}
				Console.WriteLine(Root.Data);
				PrintTree(Root.pleft, padding, false);
				PrintTree(Root.pright, padding, true);
			}
		}

		public int MinValue()
		{
			if (Root == null)
			{
				throw new Exception("Tree is empty");
			}
			return MinValue(this.Root);
		}
		int MinValue(Element Root)
		{
			//if (Root.pleft == null)
			//{
			//	return Root.Data;
			//}
			//else
			//{
			//	return MinValue(Root.pleft);
			//}
			return Root.pleft == null ? Root.Data : MinValue(Root.pleft);
		}
		public int MaxValue()
		{
			if (Root == null)
			{
				throw new Exception("Tree is empty");
			}
			return MaxValue(this.Root);
		}
		int MaxValue(Element Root)
		{
			//if (Root.pright == null)
			//{
			//	return Root.Data;
			//}
			//else
			//{
			//	return MaxValue(Root.pright);
			//}
			return Root.pright == null ? Root.Data : MaxValue(Root.pright);
		}
		public int Count()
		{
			//int counter = 0;
			//Count(this.Root, ref counter);
			//return counter;
			return Count(this.Root);
		}
		//void Count(Element Root, ref int counter)
		//{
		//	if (Root == null) 
		//	{
		//		return;
		//	}
		//	counter++;
		//	Count(Root.pleft, ref counter);
		//	Count(Root.pright, ref counter);
		//}
		int Count(Element Root)
		{
			return Root == null ? 0 : Count(Root.pleft) + Count(Root.pright) + 1;
		}
		public int Sum()
		{
			//int sum = 0;
			//Sum(this.Root, ref sum);
			//return sum;
			return Sum(this.Root);
		}
		//void Sum(Element Root, ref int sum)
		//{
		//	if (Root == null)
		//	{
		//		return;
		//	}
		//	sum += Root.Data;
		//	Sum(Root.pleft, ref sum);
		//	Sum(Root.pright, ref sum);
		//}
		int Sum(Element Root)
		{
			return Root == null ? 0 : Sum(Root.pleft) + Sum(Root.pright) + Root.Data;
		}
		public double Avg()
		{
			return (double)Sum() / Count();
		}
		public int Depth()
		{
			return Depth(this.Root);
		}
		private int Depth(Element Root)
		{
			if (Root == null)
			{
				return 0;
			}
			int leftDepth = Depth(Root.pleft);
			int rightDepth = Depth(Root.pright);
			return Math.Max(leftDepth, rightDepth) + 1;
		}
		public List<int> TreeToList()
		{
			List<int> list = new List<int>();
			FillList(ref list, this.Root);
			return list;
		}
		void FillList(ref List<int> list, Element Root)
		{
			if (Root == null)
			{
				return;
			}
			FillList(ref list, Root.pleft);
			list.Add(Root.Data);
			FillList(ref list, Root.pright);

		}
		public void Balance()
		{
			List<int> tree = this.TreeToList();
			Clear();
			this.Root = Balance(tree, 0 , tree.Count() - 1);
		}
		Element Balance(List<int> list, int startIndex, int endIndex)
		{
			if (startIndex > endIndex) return null;
			int middle = (startIndex + endIndex) / 2;
			Element newRoot = new Element(list[middle]);
			newRoot.pleft = Balance(list, startIndex, middle - 1);//Игнорируем середину списка
			newRoot.pright = Balance(list, middle + 1, endIndex);
			return newRoot;
		}
		public void Erase(int Data)
		{
			Erase(this.Root, Data);
		}
		Element Erase(Element Root, int Data)
		{
			//Если у элемента нет потомков, просто его удаляем.
			//Если у элемента один левый потомок, удаляем родителя, а потомка ставим на его место.
			//Аналогично с одним правым потомком.
			//Если у родителя два потомка, то какие бы деревья я не рисовала и какие бы ветки не отсекала,
			//Всегда оптимальной заменой был минимальный элемент из поддерева правой ветви родителя.
			if (Root == null)
			{
				return null;
			}
			if (Data < Root.Data)
			{
				//Идем налево.
				Root.pleft = Erase(Root.pleft, Data);
			}
			else if (Data > Root.Data)
			{
				//Идем направо.
				Root.pright = Erase(Root.pright, Data);
			}
			else
			{
				//нашли
				if (Root.pleft == null && Root.pright == null)
				{
					//Если потомков нет
					//Не пойдет. Мы не сможем вернуться обратно.
					//Менять не сам рут, а ссылку на потомка?
					//Тогда нужно возвращать узел
					return null;
				}
				else if (Root.pleft == null && Root.pright != null)
				{ 
					return Root.pright;
				}
				else if (Root.pright  == null && Root.pleft != null)
				{
					return Root.pleft;
				}
				else 
				{
					Root.Data = MinValue(Root.pright);
					Root.pright = Erase(Root.pright, Root.Data);
				}
			}
			return Root;
		}
	}
}
