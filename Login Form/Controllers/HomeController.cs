using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_Form.Models;
using System.Data.Entity;

namespace Login_Form.Controllers
{
    public class HomeController : Controller
    {
        StudentConlrol db = new StudentConlrol();
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
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
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            db.Students.Add(s);
            int a = db.SaveChanges();
            if (a > 0)
            {
                // ViewBag.InsertMessage = "<script>alert('Data Inserted Sucessfully !!!')</script>";
               // TempData["InsertMessage"] = "<script>alert('Data Inserted Sucessfully !!!')</script>";
                TempData["InsertMessage"] = "Data Inserted Sucessfully !!!";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.InsertMessage = "<script>alert('Data Inserted Faild!!!')</script>";
            }
            return View();
        }

        public ActionResult Edit(int id)  
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "Data Updated Sucessfully !!!";
                    return RedirectToAction("Index");
                }

                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Update Faild!!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
                if(row != null)
                {
                    db.Entry(row).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "Data Deleted Sucessfully !!!";
                        return RedirectToAction("Index");
                    }

                    else
                    {
                        ViewBag.DeleteMessage = "<script>alert('Data Delete Faild!!!')</script>";
                    }
                }
            }
            return RedirectToAction("Index");
        }

      //  [HttpPost]
        //public ActionResult Delete(Student s)
        //{
        //    db.Entry(s).State = EntityState.Deleted;
        //    int a = db.SaveChanges();
        //    if (a > 0)
        //    {
        //        TempData["DeleteMessage"] = "Data Deleted Sucessfully !!!";
        //        return RedirectToAction("Index");
        //    }

        //    else
        //    {
        //        ViewBag.DeleteMessage = "<script>alert('Data Delete Faild!!!')</script>";
        //    }
        //    return RedirectToAction("Index");
        //}

    }
}