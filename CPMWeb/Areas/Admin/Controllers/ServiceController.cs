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
    public class ServiceController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ServiceDAO();
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
            var service = new ServiceDAO().ViewDetail(id);
            return View(service);
        }
        [HttpPost]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                var dao = new ServiceDAO();
                long id = dao.Insert(service);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Service");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Dịch vụ thành công");
                }

            }
            return View("Index");

        }
        [HttpPost]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                var dao = new ServiceDAO();
                var result = dao.Update(service);
                if (result)
                {
                    return RedirectToAction("Index", "Service");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Dịch vụ thành công");
                }

            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ServiceDAO().Delete(id);
            return RedirectToAction("Index");
        }
    }
}