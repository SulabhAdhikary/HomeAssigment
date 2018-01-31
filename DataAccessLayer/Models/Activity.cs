using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Activity
    {
        public Activity()
        {
            CompanyActivity = new HashSet<CompanyActivity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CompanyActivity> CompanyActivity { get; set; }
    }
}
