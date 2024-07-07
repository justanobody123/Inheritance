//#define INHERITANCE_1
//#define INHERITANCE_2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Academy
{
	internal class Program
	{
		static readonly string delimeter = "\n----------------------------------------\n";
		internal class Human
		{
			static readonly int LAST_NAME_WIDTH = 15;
			static readonly int FIRST_NAME_WIDTH = 15;
			static readonly int AGE_WIDTH = 5;
			string lastName;
			string firstName;
			int age;
			public string LastName
			{
				get => lastName;
				set { lastName = value; }
			}
			public string FirstName
			{
				get => firstName;
				set { firstName = value; }
			}
			public int Age
			{
				get => age;
				set { age = value; }
			}
			public Human(string lastName, string firstName, int age)
			{
				LastName = lastName;
				FirstName = firstName;
				Age = age;
				Console.WriteLine($"HConstructor {this.GetHashCode()}");
			}
			public Human(Human other)
			{
				this.LastName = other.LastName;
				this.FirstName = other.FirstName;
				this.Age = other.Age;
				Console.WriteLine($"HCopyConstructor {this.GetHashCode()}");
			}
			~Human()
			{
				Console.WriteLine($"HDtor {this.GetHashCode()}");
			}
			public override string ToString()
			{
				string result = $"{GetType()}: ".PadRight(18) + $"{LastName.PadRight(LAST_NAME_WIDTH)} {FirstName.PadRight(FIRST_NAME_WIDTH)} {Age.ToString().PadRight(AGE_WIDTH)}";
				//return base.ToString() + $" {LastName} {FirstName} {Age} y/o";
				return result;
			}
		}
		static void Main(string[] args)
		{
#if INHERITANCE_1
Human human = new Human("Vercetti", "Tommy", 30);
            Console.WriteLine(human);
			Student student = new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 97);
            Console.WriteLine(student);
			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
            Console.WriteLine(teacher);
			Graduate graduate = new Graduate("Schrader", "Hank", 40, "Criminalistic", "OBN", 80, 70, "How to catch Heizenberg");
            Console.WriteLine(graduate);
#endif
#if INHERITANCE_2
			Human human = new Human("Vercetti", "Tommy", 30);
			Human human2 = new Human("Diaz", "Ricardo", 50);
            Console.WriteLine(delimeter);
            Student student = new Student(human, "Theft", "Vice", 95, 98);
            Console.WriteLine(student);
			Console.WriteLine(delimeter);
			Graduate graduate = new Graduate(student, "How to make money");
            Console.WriteLine(graduate);
			Console.WriteLine(delimeter);
			Teacher teacher = new Teacher(human2, "Weapons distribution", 20);
            Console.WriteLine(teacher);
			Console.WriteLine(delimeter);
#endif
			//Generalization
			Human[] group = new Human[]
			{
				new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 97),
				new Teacher("White", "Walter", 50, "Chemistry", 25),
				new Graduate("Schrader", "Hank", 40, "Criminalistic", "OBN", 80, 70, "How to catch Heizenberg"),
				new Student("Vercetti", "Tommy", 30, "Theft", "Vice", 95, 98),
				new Teacher("Diaz", "Ricardo", 50, "Weapons distribution", 20)
			};
			//Specialization
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i].ToString());
				Console.WriteLine(delimeter);
			}
			StreamWriter writer = new StreamWriter("group.txt"); //Создаем и открываем поток
			for (int i = 0; i < group.Length; i++)
			{
				writer.WriteLine(group[i]);
			}
			writer.Close();
			string cmd = "group.txt";
			System.Diagnostics.Process.Start("notepad", cmd);
			
		}
	}
}
