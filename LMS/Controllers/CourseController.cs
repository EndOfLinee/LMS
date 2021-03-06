﻿using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class CourseController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            CourseWrapper model = new CourseWrapper();
            model.ListOfCourses = (db.Courses.OrderByDescending(c => c.DateCreated).ToList());
            if (model.ListOfCourses.Count > 0 )
            {
                model.SelectedCourse = model.ListOfCourses[0];
                model.Entries = (db.CourseEntries.Where(x => x.CourseId == model.SelectedCourse.Id).ToList());
            }
            else
            {
                model.SelectedCourse = new Course();
                model.Entries = new List<CourseEntry>();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            CourseWrapper model = new CourseWrapper();
            model.ListOfCourses = (db.Courses.OrderByDescending(c => c.DateCreated).ToList());
            model.SelectedCourse = db.Courses.Where(c => c.Id == id).ToList()[0];
            model.Entries = (db.CourseEntries.Where(x => x.CourseId == model.SelectedCourse.Id).OrderByDescending(c => c.DateCreated).ToList());
            return View("Index", model);
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

        [HttpPost]
        public ActionResult addCourseEntry(CourseEntry model)
        {
            try
            {
                if (model.Title != "" && model.Content != "")
                {
                    model.DateCreated = DateTime.Now.ToUniversalTime();
                    model.Deleted = false;
                    db.CourseEntries.Add(model);
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
            throw new Exception("not all fields are filled");
        }
    }
}