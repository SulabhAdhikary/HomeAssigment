using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class CompanyActivity
    {
        public virtual int Id { get; set; }
        public virtual int? ActivityId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
