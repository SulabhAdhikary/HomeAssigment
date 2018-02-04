﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Repository
{
    public class CompanyActivityRepository :ICompanyActivityRepository
    {
        OcasAssignmentContext _context;

        public CompanyActivityRepository(OcasAssignmentContext context)
        {
            _context = context;
        }

        public void AddCompanyActivity(CompanyActivity item)
        {
            _context.CompanyActivity.Add(item);
            _context.SaveChanges();
        }

        public void  UpdateCompanyActivity(CompanyActivity item)
        {
            _context.CompanyActivity.Update(item);
            _context.SaveChanges();
        }

        public IEnumerable<CompanyActivity> GetAll()
        {
            return _context.CompanyActivity.Include("Activity");
        }

        public IEnumerable<Activity> GetAllActivity()
        {
            return _context.Activity;
        }
    }
}
