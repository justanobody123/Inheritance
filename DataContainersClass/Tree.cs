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
		public void Insert(int Data, Element Root)
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
		public void Print(Element Root)
		{
			if (Root == null)
			{
				return;
			}
			Print(Root.pleft);
            Console.Write($"{Root.Data}\t");
			Print(Root.pright);
        }
		
	}
}
