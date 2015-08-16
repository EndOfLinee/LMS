using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class CourseController : Controller
    {
        Provider db = new Provider();
        public ActionResult Index()
        {
            List<Course> models = db.Courses.OrderByDescending(c => c.DateCreated ).ToList();
            return View(models);
        }

        [HttpPost]
        public ActionResult addCourse(Course model)
        {
            try
            {
                if (model.Name != "" && model.Description != "")
                {
                    model.DateCreated = DateTime.Now.ToUniversalTime();
                    model.Active = 1;
                    db.Courses.Add(model);
                    db.SaveChanges();
                    return Json(new { Message = "success" });
                }
                else
                {
                    throw new Exception("not all fields are filled");
                }
            }
            catch (Exception e)
            {
                return Json(new { Message = e.Message.ToString() });
            }
        }
    }
}