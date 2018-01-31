using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

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
     public IEnumerable<string> Get()
     {
       var disco= Ocasrepo.GetAll();


         return new string[] { "value1", "value2" };
     }
      
     
    }
}
