using Models.DAO;
using Models.EF;
using ShopPhone.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBike.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private ProductDAO dao = new ProductDAO();
        private readonly CategoryDAO cateDao = new CategoryDAO();
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var selectList = new SelectList(cateDao.GetAll(),"ID","Name",1);
            ViewData["Categories"] = selectList;
            return View();
        }
        public ActionResult Edit(int id)
        {
            var Product = dao.GetById(id);
            return View(Product);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product Product)
        {
            if (ModelState.IsValid)
            {
                var id = dao.Create(Product);
                if (id)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Add Product successfully");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var item = dao.GetById(id);
            if (dao.Delete(item))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Delete Product successfully");
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product Product)
        {
            if (ModelState.IsValid)
            {
                var result = dao.Update(Product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Modify successfully");
                }
            }
            return View("Index");
        }
    }
}