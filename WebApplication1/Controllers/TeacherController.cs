using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        TeacherEntities dbobj = new TeacherEntities();
        public ActionResult Teacher(Teacher Obj)
        {
            return View(Obj);
        }
        [HttpPost]
        public ActionResult AddTeacher(Teacher model)
        {
            Teacher obj = new Teacher();
            if (ModelState.IsValid)
            {
                obj.TeacherID= model.TeacherID;
                obj.Salary = model.Salary;
                obj.Position = model.Position;
                obj.CNIC = model.CNIC;
                if (model.TeacherID==0) {
                    dbobj.Teachers.Add(obj);
                    dbobj.SaveChanges();
                }
                else
                {
               
                    
                    dbobj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbobj.SaveChanges();
                }

            }
            ModelState.Clear();
            return View("Teacher");
        }


        public ActionResult TeacherList()
        {
            var res=dbobj.Teachers.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbobj.Teachers.Where(x => x.TeacherID == id).First();
            dbobj.Teachers.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.Teachers.ToList();

            return View("TeacherList", list);
        }
    }
}