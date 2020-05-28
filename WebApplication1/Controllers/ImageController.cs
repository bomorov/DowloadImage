using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        HostelContext db = new HostelContext();
        [HttpGet]
        public ActionResult Add_Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Student(Student student)
        {
            string fileName = Path.GetFileNameWithoutExtension(student.ImageFile.FileName);
            string extension = Path.GetExtension(student.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            student.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            student.ImageFile.SaveAs(fileName);
            db.Students.Add(student);
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Student_List", "Image");
        }


        public ActionResult Student_List()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(int? id)
        {
            var student = db.Students.FirstOrDefault(s => s.Id == id);

            return View(student);
        }


     
    }
}