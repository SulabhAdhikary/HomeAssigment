using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class CompanyActivity
    {
        public int Id { get; set; }
        public int? ActivityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Activity Activity { get; set; }
    }
}
