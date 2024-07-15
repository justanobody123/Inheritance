using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				MyStack<int> stack = new MyStack<int>();
				for (int i = 1; i <= 5; i++)
				{
					stack.Push(i * 10);
				}
				Console.WriteLine(stack.Pop());//50
				Console.WriteLine(stack.Pop());//40
				Console.WriteLine(stack.Pop());//30
				Console.WriteLine(stack.Peek());//50
				Console.WriteLine(stack.Pop());//20
				stack.Clear();
				Console.WriteLine(stack.Peek());//Эксепшен
			}
			catch (Exception e)
			{

                Console.WriteLine(e.Message);
            }
			
        }
	}
}
