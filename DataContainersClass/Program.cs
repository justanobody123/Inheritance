using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainersClass
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
            Tree tree = new Tree();
			Random rand = new Random();
			for (int i = 0; i < n; i++) 
			{
				tree.Insert(rand.Next(100), tree.Root);
			}
			tree.Print(tree.Root);
		}
	}
}
