using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Graduate:Student
	{
		string subject;
		public string Subject
		{
			get => subject; 
			set => subject = value;
		}
		public Graduate
			(
			string lastName, string firstName, int age,
			string speciality, string group, double rating, double attendance,
			string subject
			) : base(lastName, firstName, age, speciality, group, rating, attendance)
		{
			Subject = subject;
            Console.WriteLine($"GCtor {this.GetHashCode()}");
        }
		public Graduate(Student student, string subject):base(student)
		{
			this.Subject = subject;
			Console.WriteLine($"GCopyCtor {this.GetHashCode()}");
		}
		~Graduate()
		{
            Console.WriteLine($"GDtor {this.GetHashCode()}");
		}
		public override string ToString()
		{
			return base.ToString() + $" {Subject}";
		}
		public override string ToStringFile()
		{
			return base.ToStringFile().Replace(';', ',') + $"{subject};";
		}
	}
}
