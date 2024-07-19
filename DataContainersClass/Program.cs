#define TREE_BASE_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace DataContainersClass
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random rand = new Random();
#if TREE_BASE_CHECK
			Console.WriteLine("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
			try
			{
				Tree tree = new Tree();
				for (int i = 0; i < n; i++)
				{
					tree.Insert(rand.Next(100));
				}
				tree.Print();
				Console.WriteLine($"Min: {tree.MinValue()}");
				Console.WriteLine($"Max: {tree.MaxValue()}");
				Console.WriteLine($"Counter: {tree.Count()}");
				Console.WriteLine($"Sum: {tree.Sum()}");
				Console.WriteLine($"Avg: {tree.Avg()}");
				//UniqueTree uTree = new UniqueTree();
				//for (int i = 0; i < n; i++)
				//{
				//	uTree.Insert(rand.Next(100));
				//}
				//uTree.Print();
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
#endif
			//Tree tree = new Tree()
			//{
			//	3, 5, 8, 13, 21
			//};
		}
	}
}
