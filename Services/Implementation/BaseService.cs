using System;
using Data;

namespace Services.Implementation
{
    public class BaseService
    {
        protected readonly SchoolContext _schoolContext;

        public BaseService(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }
    }
}

