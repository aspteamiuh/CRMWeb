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
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index(string searchString, int page=1,int  pageSize = 10)
        {
            var dao = new CustomerDAO();
            var model = dao.ListAllPaging(searchString,page, pageSize);
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
            var customer = new CustomerDAO().ViewDetail(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDAO();
                long id = dao.Insert(customer);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Customer thành công");  
                }

            }
            return View("Index");

        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDAO();
                var result = dao.Update(customer);
                if (result)
                {
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Customer thành công");
                }

            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CustomerDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}