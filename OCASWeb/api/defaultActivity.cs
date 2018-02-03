using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OCASWeb.api
{
    [Route("api/[controller]")]
    public class DefaultActivityController : Controller
    {

    public ICompanyActivityRepository Ocasrepo { get; set; }
    public DefaultActivityController(ICompanyActivityRepository repo)
    {
      Ocasrepo = repo;
    }


        [HttpGet]
        public Dictionary<int,string> Get()
        {
          var defaulActivities = Ocasrepo.GetAllActivity();
         return defaulActivities.ToDictionary(keyvalue => keyvalue.Id, keyvalue => keyvalue.Name);

        }

      
    }
}
