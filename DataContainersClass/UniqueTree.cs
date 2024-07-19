using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainersClass
{
	internal class UniqueTree:Tree
	{
		public void Insert(int Data)
		{
			this.Insert(Data, this.Root);
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
	}
}
