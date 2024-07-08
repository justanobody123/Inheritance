﻿//#define INHERITANCE_1
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
			//Print(group);
			string cmd = "group.txt";
			//Save(cmd, group);
			Print(Load(cmd));
			//System.Diagnostics.Process.Start("notepad", cmd);
			//TODO:
			//1.Код, выводящий группу на экран вынести в метод ??? Print(???);
			//2.Код, сохраняющий группу в файл вынести в метод ??? Save(???);
			//3.Написать метод ??? Load(???), который загружает группу из файла, в такой же массив, как создан в методе Main();
		}
		static void Print(Human[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Console.WriteLine(array[i].ToString());
				Console.WriteLine(delimeter);
			}
		}
		static void Save(string fileName, Human[] array)
		{
			if (!fileName.EndsWith(".txt"))
			{
				fileName += ".txt";
			}
			StreamWriter writer = new StreamWriter(fileName); //Создаем и открываем поток
			for (int i = 0; i < array.Length; i++)
			{
				writer.WriteLine(array[i]);
			}
			writer.Close();
		}
		static Human[] Load(string fileName)
		{
            Console.WriteLine("-----LOAD-----");
            if (File.Exists(fileName))
			{
				StreamReader reader = new StreamReader(fileName);
				string[] fileContents = File.ReadAllLines(fileName);
				Human[] group = new Human[fileContents.Length];
				string substring;
				for (int i = 0; i < fileContents.Length; i++)
				{
					substring = String.Join(" ", fileContents[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
					string[] subarr = substring.Split(' ');

					if (subarr[0] == "Academy.Student:")
					{
						group[i] = new Student(subarr[1], subarr[2], Convert.ToInt32(subarr[3]), subarr[4], subarr[5], Convert.ToDouble(subarr[6]), Convert.ToDouble(subarr[7]));
					}
					else if (subarr[0] == "Academy.Teacher:")
					{
						string name = subarr[1];
						string surname = subarr[2];
						int age = Convert.ToInt32(subarr[3]);

						int index = 4;
						string speciality = "";
						while (!int.TryParse(subarr[index], out _))//out _ потому что мы не сохраняем результат парсинга.
						{
							speciality += subarr[index] + " ";
							index++;
						}
						speciality = speciality.Trim();
						int experience = Convert.ToInt32(subarr[index]);
						group[i] = new Teacher(name, surname, age, speciality, experience);
					}
					else if (subarr[0] == "Academy.Graduate:")
					{
						string name = subarr[1];
						string surname = subarr[2];
						int age = Convert.ToInt32(subarr[3]);
						string speciality = subarr[4];
						string studyGroup = subarr[5];
						double rating = Convert.ToDouble(subarr[6]);
						double attendance = Convert.ToDouble(subarr[7]);

						int index = 8;
						string subject = "";
						while (index < subarr.Length)
						{
							subject += subarr[index] + " ";
							index++;
						}
						subject = subject.Trim();
						group[i] = new Graduate(name, surname, age, speciality, studyGroup, rating, attendance, subject);
					}
				}
				reader.Close();
				Console.WriteLine("-----LOAD DONE-----");
				return group;

			}
			else 
			{
                Console.WriteLine("Такого файла не существует.");
				Console.WriteLine("-----LOAD DONE-----");
				return null;
            }
			
		}
	}
}
