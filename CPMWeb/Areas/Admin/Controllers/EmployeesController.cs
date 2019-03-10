using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using PagedList;

namespace CPMWeb.Areas.Admin.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new EmployeeDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var employee = new EmployeeDAO().ViewDetail(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var dao = new EmployeeDAO();
                long id = dao.Insert(employee);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Employee thành công");
                }

            }
            return View("Index");

        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var dao = new EmployeeDAO();
                var result = dao.Update(employee);
                if (result)
                {
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Employee thành công");
                }

            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new EmployeeDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}