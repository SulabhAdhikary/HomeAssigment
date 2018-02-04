using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DataAccessLayer.Models;
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
      if (objDomainResult.Success) {
        CompanyActivity objcompanyActivityModel;
        if (activityDomain.id==null || activityDomain.id == "0")
        {
          objcompanyActivityModel = new CompanyActivity();
          objcompanyActivityModel.ActivityId = Int32.Parse(activityDomain.activityId);
          objcompanyActivityModel.FirstName = activityDomain.firstName;
          objcompanyActivityModel.LastName = activityDomain.lastName;
          objcompanyActivityModel.Email = activityDomain.email;
          Ocasrepo.AddCompanyActivity(objcompanyActivityModel);
        }
        else
        {
          objcompanyActivityModel = new CompanyActivity();
          objcompanyActivityModel.Id = Int32.Parse(activityDomain.id);
          objcompanyActivityModel.ActivityId = Int32.Parse(activityDomain.activityId);
          objcompanyActivityModel.FirstName = activityDomain.firstName;
          objcompanyActivityModel.LastName = activityDomain.lastName;
          objcompanyActivityModel.Email = activityDomain.email;
          Ocasrepo.UpdateCompanyActivity(objcompanyActivityModel);
        }

        OkResult obj = new OkResult();
        return obj;
      }
      else
      {
        return BadRequest(((object)objDomainResult.Errors));
      }
     
    }

  
  }
}
