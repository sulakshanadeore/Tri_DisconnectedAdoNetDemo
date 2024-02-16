using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using DisconnectedAdoNetDemo.Models;
using DisconnectedLibrary;
namespace DisconnectedAdoNetDemo.Controllers
{
    public class DeptController : Controller
    {
        // GET: Dept
        public ActionResult Index()
        {
            List<DeptModel> list = new List<DeptModel>();
            DeptDAL dal=new DeptDAL();
            List<Dept> dlist=dal.GetDeptList();
            foreach (Dept d in dlist) {
            DeptModel model=new DeptModel();
                model.Deptno = d.Deptno;    
                model.Dname = d.Dname;
                model.Loc  =d.Loc;
                model.MgrName = d.MgrName;
                list.Add(model);

            }

            return View(list);
        }

        // GET: Dept/Details/5
        public ActionResult Details(int id)
        {
            DeptDAL dal= new DeptDAL();
            Dept dept=dal.FindDept(id);
            DeptModel model = new DeptModel();
            model.Deptno= dept.Deptno;
            model.Dname=dept.Dname; 
            model.Loc=dept.Loc;
            model.MgrName = dept.MgrName;

            return View(model);
        }

        // GET: Dept/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dept/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                DeptDAL dal=new DeptDAL();
                Dept dept=new Dept();
                dept.Dname = collection["Dname"];
                dept.Loc = collection["Loc"];
                dept.MgrName = collection["MgrName"];

                dal.AddDept(dept);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dept/Edit/5
        public ActionResult Edit(int id)
        {

            DeptDAL dal = new DeptDAL();
            Dept dept = dal.FindDept(id);
            DeptModel model = new DeptModel();
            model.Deptno = dept.Deptno;
            model.Dname = dept.Dname;
            model.Loc = dept.Loc;
            model.MgrName = dept.MgrName;

            return View(model);
        }

        // POST: Dept/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                DeptDAL dal = new DeptDAL();
                Dept d = new Dept();
                d.Deptno = Convert.ToInt32(collection["Deptno"]);
                d.Dname = collection["Dname"].ToString();
                d.Loc = collection["Loc"].ToString();
                d.MgrName = collection["MgrName"].ToString();

                bool status = dal.EditDept(d, id);
                if (status)
                {
                    return RedirectToAction("Index");
                }
                    
                
                
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: Dept/Delete/5
        public ActionResult Delete(int id)
        {

            DeptDAL dal = new DeptDAL();
            Dept dept = dal.FindDept(id);
            DeptModel model = new DeptModel();
            model.Deptno = dept.Deptno;
            model.Dname = dept.Dname;
            model.Loc = dept.Loc;
            model.MgrName = dept.MgrName;

            return View(model);
        }

        // POST: Dept/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DeptDAL dal = new DeptDAL();
           bool status =    dal.RemoveDept(id);
                if (status)
                
                    return RedirectToAction("Index");
                
                
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
              
        }
    }
}
