using Models.Entities;
using System;


namespace Models.ViewModels
{
    public class UserResults
    {
        public UserResults()
        {
        }

        public List<User> Users { get; set; }
        public Sorting Sorting { get; set; }
        public Paging Paging { get; set; }
        public User User { get; set; }
    }
}

