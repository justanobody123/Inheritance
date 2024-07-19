#undef DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainersClass
{
	internal class Tree
	{
		public class Element
		{
			public int Data;
			public Element pleft;
			public Element pright;
			public Element(int Data, Element pleft = null, Element pright = null)
			{
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
            Console.WriteLine($"TDtor:\t{GetHashCode()}");
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
				if(Root.pleft == null)
				{
					Root.pleft = new Element(Data);
				}
				else
				{
					Insert(Data, Root.pleft);
				}
			}
			else
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
	}
}
