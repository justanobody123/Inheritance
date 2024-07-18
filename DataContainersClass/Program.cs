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
				tree.Insert(rand.Next(100));
			}
			tree.Print();
            Console.WriteLine();
            Console.WriteLine($"Min: {tree.MinValue()}");
            Console.WriteLine($"Max: {tree.MaxValue()}");
			Console.WriteLine($"Counter: {tree.Count()}");
			Console.WriteLine($"Sum: {tree.Sum()}");
			Console.WriteLine($"Avg: {tree.Avg()}");
		}
	}
}
