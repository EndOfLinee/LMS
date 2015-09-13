using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            List<News> models = db.News.Where(m => m.Deleted == false).OrderByDescending(c => c.DateCreated).ToList();
            return View(models);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addNews(News model)
        {
            try
            {
                if (model.Title != "" && model.Content != "")
                {
                    model.Deleted = false;
                    model.DateCreated = DateTime.Now.ToUniversalTime();
                    db.News.Add(model);
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
        public ActionResult deleteNews(int Id)
        {
            try
            {
                News original = db.News.Find(Id);
                News deleted = new News();

                deleted.Id = original.Id;
                deleted.Content = original.Content;
                deleted.DateCreated = original.DateCreated;
                deleted.Title = original.Title;
                deleted.ImageUrl = original.Title;
                deleted.Deleted = true;

                db.Entry(original).CurrentValues.SetValues(deleted);
                db.SaveChanges();
                return Json(new { Message = "success" });
            }
            catch (Exception e)
            {
                return Json(new { Message = e.Message.ToString() });
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addContact(Contact model)
        {
            try
            {
                if (model.Name != "" && model.Email != "" && model.Phone != "" && model.Message != "")
                {
                    model.DateCreated = DateTime.Now.ToUniversalTime();
                    db.Contacts.Add(model);
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}