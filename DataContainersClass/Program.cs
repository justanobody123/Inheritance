//#define TREE_BASE_CHECK
//#define TREE_INITIALIZER_LIST_CHECK
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
			Random rand = new Random(0);


#if TREE_BASE_CHECK
			
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
                tree.Erase(72);
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
				

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
#endif
#if TREE_INITIALIZER_LIST_CHECK
			try
			{
				Tree tree = new Tree() { 50, 25, 75, 16, 32, 64, 91, 98, 2000 };
				
				tree.Print();
				Console.WriteLine($"Минимальное значение в дереве: {tree.MinValue()}");
				Console.WriteLine($"Максимальное значение в дереве: {tree.MaxValue()}");
				Console.WriteLine($"Количество элементов дерева: {tree.Count()}");
				Console.WriteLine($"Сумма элементов дерева: {tree.Sum()}");
				Console.WriteLine($"Среднее-арифметическое элементов дерева: {tree.Avg()}");
				Console.WriteLine($"Глубина дерева: {tree.Depth()}");
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message); ;
			} 
#endif
			Console.WriteLine("Введите размер дерева");
			int n = Convert.ToInt32(Console.ReadLine());
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
			Console.WriteLine($"Глубина дерева: {tree.Depth()}");
		}
	}
}
