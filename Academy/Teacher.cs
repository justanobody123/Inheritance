using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Teacher : Program.Human
	{
		static readonly int SPECIALITY_WIDTH = 25;
		static readonly int EXPERIENCE_WIDTH = 5;
		string speciality;
		int experience;
		public string Speciality
		{
			get => speciality;
			set => speciality = value;
		}
		public int Experience
		{
			get => experience;
			set => experience = value;
		}
		public Teacher(
			string lastName, string firstName, int age,
			string speciality, int experience
			) : base(lastName, firstName, age)
		{
			Speciality = speciality;
			Experience = experience;
            Console.WriteLine($"TCtor {this.GetHashCode()}");
        }
		public Teacher(Program.Human human, string speciality, int experience):base(human)
		{
			this.Speciality = speciality;
			this.Experience = experience;
			Console.WriteLine($"TCtor {this.GetHashCode()}");
		}
		~Teacher()
		{
			Console.WriteLine($"TDtor {this.GetHashCode()}");
		}
		public override string ToString()
		{
			return base.ToString() + $" {Speciality.PadRight(SPECIALITY_WIDTH)} {Experience.ToString().PadRight(EXPERIENCE_WIDTH)}";
		}
		public override string ToStringFile()
		{
			return base.ToStringFile().Replace(';', ',') + $"{speciality},{experience};";
		}
	}
}
