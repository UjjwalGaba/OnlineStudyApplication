using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineStudyApplication.Controllers;
using OnlineStudyApplication.Data;
using OnlineStudyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStudyApplication_Tests
{
    [TestClass]
    public class StudyControllerTest
    {
        // this in an in-memory db context
        private ApplicationDbContext _context;
        // empty list of study material
        List<Study> studies = new List<Study>();
        // declare the controller that will be tested
        StudiesController controller;
        // create a initialize method
        
        [TestInitialize]
        public void TestInitialize()
        {
            // instantiate in-memory db

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);

            // create mock data in db
            // create 1 course
            var course = new Course { Id = 100, CourseName = "Test Course" };
            _context.Courses.Add(course);
            _context.SaveChanges();

            // create 3 study material

            studies.Add(new Study { Id = 101, ChapterName = "Chapter", Course = course, ChapterDescription= "" });
            studies.Add(new Study { Id = 102, ChapterName = "Another Chapter", Course = course, ChapterDescription = "" });
            studies.Add(new Study { Id = 103, ChapterName = "Extra Chapter", Course = course, ChapterDescription = "" });

            foreach (var s in studies)
            {
                _context.Studies.Add(s);
            }
            _context.SaveChanges();


            // instantiate the controller class with mock db context
            controller = new StudiesController(_context);

        }
        /*
        [TestMethod]
        public void IndexViewLoads()
        {
            // Arrange
            // already done in TestInitialize
            // Act 
            var result = controller.Index();
            var viewResult = (ViewResult)result.Result;

            // Assert
            Assert.AreEqual("Index", viewResult.ViewName);


        }*/
        /*
        [TestMethod]
        public void TestDetialView()
        {

            // Act
            var result = controller.Details(101);
            var viewResult = (ViewResult)result.Result;

            // Assert
            Assert.AreEqual("Details", viewResult.ViewName);
        }
        */
        [TestMethod]
        public void TestDeleteId()
        {
            var result = controller.Delete(101);
            var viewResult = (ViewResult)result.Result;

            Assert.AreEqual("Delete", viewResult.ViewName);
        }

        [TestMethod]
        public void TestCreate1()
        {
            var result = controller.Create();
            var viewResult = (ViewResult)result;

            Assert.AreEqual("Create", viewResult.ViewName);
        }

        [TestMethod]
        public void TestCreate2()
        {
            controller.ModelState.AddModelError("ChapterDiscription", "StringLength");

            var result = controller.Create();
            var viewResult = (ViewResult)result;

            Assert.AreEqual("Create", viewResult.ViewName);
            
        }
        public void TestCreate3()
        {

        }

        /*
            a.	Create (GET)
            b.	Create (POST)
            c.	Edit (GET)
            d.	Edit (POST)
            e.	Delete (GET)
            f.	DeleteConfirmed (POST)

         */

    }
}
