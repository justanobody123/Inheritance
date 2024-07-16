//#define STACK
#define QUEUE
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
#if STACK
				MyStack<int> stack = new MyStack<int>();
				for (int i = 1; i <= 5; i++)
				{
					stack.Push(i * 10);
				}
				Console.WriteLine(stack.Pop());//50
				Console.WriteLine(stack.Pop());//40
				Console.WriteLine(stack.Pop());//30
				Console.WriteLine(stack.Peek());//20
				Console.WriteLine(stack.Pop());//20
				stack.Clear();
				Console.WriteLine(stack.Peek());//Эксепшен  

#endif
#if QUEUE
				MyQueue<int> queue = new MyQueue<int>();
				for (int i = 1; i <= 5; i++)
				{
					queue.Push(i * 10);
				}
				Console.WriteLine(queue.Pop());//10
				Console.WriteLine(queue.Pop());//20
				Console.WriteLine(queue.Pop());//30
				Console.WriteLine(queue.Peek());//40
				Console.WriteLine(queue.Pop());//40
				queue.Clear();
                Console.WriteLine(queue.Pop());//Эксепшен
#endif
            }
			catch (InvalidOperationException e)
			{

                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Тест после эксепшена.");
        }
	}
}
