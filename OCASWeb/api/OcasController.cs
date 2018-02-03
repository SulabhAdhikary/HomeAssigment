using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using OCASWeb.PresentationValidation;
using OCASWeb.ViewDomains;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OCASWeb
{
    [Route("api/[controller]")]
    public class OcasController : Controller
    {

    public ICompanyActivityRepository Ocasrepo { get; set; }




    public OcasController(ICompanyActivityRepository repo)
    {
          Ocasrepo = repo;
    }

   
     [HttpGet]
     public IEnumerable<CompanyActivityViewDomain> Get()
     {
      var allActivity = Ocasrepo.GetAll();
      IEnumerable<CompanyActivityViewDomain> activities = allActivity.Select(t => new CompanyActivityViewDomain
      {
          id = t.Id.ToString(),
          activityId = t.ActivityId.ToString(),
          firstName = t.FirstName,
          lastName = t.LastName,
          email = t.Email,
          activityName = t.Activity.Name
       
      }).ToList<CompanyActivityViewDomain>();

      return activities;
     }


    [HttpPost]
    public IActionResult Post([FromBody]CompanyActivityViewDomain activityDomain)
    {
      DomainResultModel objDomainResult = activityDomain.IsObjectValid();
      if (objDomainResult.Success)
      {
        return null;
      }
      return BadRequest(((object)objDomainResult.Errors));
     
    }

  
  }
}
