using OCASWeb.PresentationValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;


namespace OCASWeb.ViewDomains
{
    public class CompanyActivityViewDomain: Ivalidate
  {
      public string id { get; set; }
      public string activityId { get; set; }
      public string firstName { get; set; }
      public string lastName { get; set; }
      public string email { get; set; }
      public string activityName { get; set; }

    public DomainResultModel IsObjectValid()
    {
      CompanyActivityDomainManagercs objCompanyActivityDomainManagercs = new CompanyActivityDomainManagercs();
      return objCompanyActivityDomainManagercs.ValidateCustomerModel(this);
    }
  }


  
}
