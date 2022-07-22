using System;


namespace Models.Entities
{
	public class UserSchool
	{
		public Guid UserId { get; set; }
		public int SchoolId { get; set; }


		public User? User { get; set; }
		public School? School { get; set; }
	}
}

