using System;
namespace Models.Entities
{
	public class School
	{
		public int SchoolId { get; set; }

		public string? Name { get; set; }

		
		public string? Address { get; set; }


		public ICollection<UserSchool>? UserSchools { get; set; }
	}
}

