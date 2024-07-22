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
		static readonly string delimiter = "\n------------------------------------------------------\n";
		static void Main(string[] args)
		{
			Random rand = new Random();
#if TREE_BASE_CHECK
			Console.Write("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
			try
			{
				Tree tree = new Tree();
				for (int i = 0; i < n; i++)
				{
					tree.Insert(rand.Next(100));
				}
				tree.Print();
				Console.WriteLine($"Минимальное значение в дереве: {tree.MinValue()}");
				Console.WriteLine($"Максимальное значение в дереве: {tree.MaxValue()}");
				Console.WriteLine($"Количество элементов дерева: {tree.Count()}");
				Console.WriteLine($"Сумма элементов дерева: {tree.Sum()}");
				Console.WriteLine($"Среднее-арифметическое элементов дерева: {tree.Avg()}");
				//tree.Clear();
                tree.PrintTree();
				tree.Erase(1);
                Console.WriteLine("Удаляем единицу");
				tree.PrintTree();
                Console.WriteLine(tree.Depth());
                tree.Balance();
				tree.PrintTree();
				Console.WriteLine(tree.Depth());
				
				//List<int> list = tree.TreeToList();
				//for (int i = 0;i < list.Count;i++) 
				//{
				//	Console.WriteLine(list[i] + " ");
				//}
				//UniqueTree unique_tree = new UniqueTree();
				//for (int i = 0; i < n; i++)
				//{
				//	unique_tree.Insert(rand.Next(100));
				//}
				//unique_tree.Print();
				//Console.WriteLine($"Минимальное значение в дереве: {unique_tree.MinValue()}");
				//Console.WriteLine($"Максимальное значение в дереве: {unique_tree.MaxValue()}");
				//Console.WriteLine($"Количество элементов дерева: {unique_tree.Count()}");
				//Console.WriteLine($"Сумма элементов дерева: {unique_tree.Sum()}");
				//Console.WriteLine($"Среднее-арифметическое элементов дерева: {unique_tree.Avg()}");

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
