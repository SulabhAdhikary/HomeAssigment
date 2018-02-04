using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository
{
    public interface ICompanyActivityRepository
    {

        void AddCompanyActivity(CompanyActivity item);
        void UpdateCompanyActivity(CompanyActivity item);
        IEnumerable<CompanyActivity> GetAll();
        IEnumerable<Activity> GetAllActivity();

    }
}
