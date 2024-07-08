using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy
{
	class Student:Program.Human
	{
		static readonly int SPECIALITY_WIDTH = 25;
		static readonly int GROUP_WIDTH = 8;
		static readonly int RATING_WIDTH = 8;
		static readonly int ATTENDANCE_WIDTH = 8;
		private string speciality;
		private string group;
		double rating;
		double attendance;
		public string Speciality
		{
			get => speciality;
			set { speciality = value;}
		}
		public string Group
		{
			get => group;
			set { group = value;  }
		}
		public double Rating
		{
			get => rating;
			set => rating = value; 
		}
		public double Attendance
		{
			get => attendance;
			set => attendance = value;
		}
		public Student
			(string lastName, string firstName, int age,
			string speciality, string group, double rating, double attendance
			) : base(lastName, firstName, age)
		{
			Speciality = speciality;
			Group = group;
			Rating = rating;
			Attendance = attendance;
            Console.WriteLine($"SConstructor {this.GetHashCode()}");
        }
		public Student(Program.Human human, string speciality, string group, double rating, double attendance):base(human)
		{
			Speciality = speciality;
			Group = group;
			Rating = rating;
			Attendance = attendance;
			Console.WriteLine($"SConstructor {this.GetHashCode()}");
		}
		public Student(Student other):base(other)
		{
			this.Speciality = other.Speciality;
			this.Group = other.Group;
			this.Rating = other.Rating;
			this.Attendance = other.Attendance;
			Console.WriteLine($"SCopyConstructor {this.GetHashCode()}");
		}
		~Student()
		{
			Console.WriteLine($"SDtor {this.GetHashCode()}");
		}
		public override string ToString()
		{
			return base.ToString() + $" {Speciality.PadRight(SPECIALITY_WIDTH)} {Group.PadRight(GROUP_WIDTH)} {Rating.ToString().PadRight(RATING_WIDTH)} {Attendance.ToString().PadRight(ATTENDANCE_WIDTH)}";
		}
		public override string ToStringFile()
		{
			return base.ToStringFile().Replace(';', ',')+$"{speciality},{group},{rating},{attendance};";
		}
	}
}
