using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace WebProjectTest
{
    [TestClass]
    public class UnitTestApi
    {

        private Mock<ICompanyActivityRepository> _mock;
        [TestMethod]
        public void TestMethod1()
        {
            var activity = new Activity();
            activity.Id = 1;
            activity.Name = "Activity 1";
            var data = new List<CompanyActivity>
            {
                 new CompanyActivity { Id=1,Activity=activity,Email="firstlast1@gmail.com",FirstName="first1",LastName=  "BBB" },
                  new CompanyActivity { Id=1,Activity=activity,Email="firstlast2@gmail.com",FirstName="first2",LastName=  "BBB" },
                  new CompanyActivity { Id=1,Activity=activity,Email="firstlast3@gmail.com",FirstName="first3",LastName=  "BBB" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<CompanyActivity>>();
            mockSet.As<IQueryable<CompanyActivity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<CompanyActivity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<CompanyActivity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<CompanyActivity>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<OcasAssignmentContext>();
            mockContext.Setup(m => m.CompanyActivity).Returns(mockSet.Object);

            CompanyActivityRepository objcom = new CompanyActivityRepository(mockContext.Object);
            var test = objcom.GetAll();
            Assert.AreEqual(3, test.Count());
        }
    }
}
