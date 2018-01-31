using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.PresentationValidation
{
    public class CustomerDomainModel:Ivalidate
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ValidationDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }


        public DomainResultModel IsObjectValid()
        {
            CustomerDomainManager objCustomerDomainManager = new CustomerDomainManager();
            return objCustomerDomainManager.ValidateCustomerModel(this);
        }
    }
}
