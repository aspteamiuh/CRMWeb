using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace CPMWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            var dao = new ProductDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(int iD)
        {
            new ProductDAO().Delete(iD);
            return RedirectToAction("Index");
        }

    }
}