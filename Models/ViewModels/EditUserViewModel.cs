using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class EditUserViewModel
    {
        
        public User User { get; set; }
        public List<UserType> UserTypeList { get; set; }
        public List<School> SchoolList { get; set; }
        public List<YearGroup> YearGroupList { get; set; }
    }
}

