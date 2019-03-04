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
        public ActionResult Index(int page=1,int  pageSize = 10)
        {
            var dao = new CustomerDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
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
    }
}