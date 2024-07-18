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
                Console.WriteLine($"ECtor:\t{GetHashCode()}");
            }
			~Element()
			{
                Console.WriteLine($"EDtor:\t{GetHashCode()}");
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
			return MinValue(this.Root);
		}
		int MinValue(Element Root)
		{
			if (Root.pleft == null)
			{
				return Root.Data;
			}
			else
			{
				return MinValue(Root.pleft);
			}
		}
		public int MaxValue()
		{
			return MaxValue(this.Root);
		}
		int MaxValue(Element Root)
		{
			if (Root.pright == null)
			{
				return Root.Data;
			}
			else
			{
				return MaxValue(Root.pright);
			}
		}
		public int Count()
		{
			int counter = 0;
			Count(this.Root, ref counter);
			return counter;
		}
		void Count(Element Root, ref int counter)
		{
			if (Root == null) 
			{
				return;
			}
			counter++;
			Count(Root.pleft, ref counter);
			Count(Root.pright, ref counter);
		}
		public int Sum()
		{
			int sum = 0;
			Sum(this.Root, ref sum);
			return sum;
		}
		void Sum(Element Root, ref int sum)
		{
			if (Root == null)
			{
				return;
			}
			sum += Root.Data;
			Sum(Root.pleft, ref sum);
			Sum(Root.pright, ref sum);
		}
		public int Avg()
		{
			return Sum() / Count();
		}
	}
}
