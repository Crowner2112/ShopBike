﻿using Models.DAO;
using Models.EF;
using ShopPhone.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBike.Areas.Admin.Controllers
{
    public class ImageController : BaseController
    {
        private ImageDAO dao = new ImageDAO();
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var Image = new ImageDAO().GetById(id);
            return View(Image);
        }
        [HttpPost]
        public ActionResult Create(Image Image)
        {
            if (ModelState.IsValid)
            {
                var id = dao.Create(Image);
                if (id)
                {
                    return RedirectToAction("Index", "Image");
                }
                else
                {
                    ModelState.AddModelError("", "Add Image successfully");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(Image image)
        {
            dao.Delete(image);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Image Image)
        {
            if (ModelState.IsValid)
            {
                var result = dao.Update(Image);
                if (result)
                {
                    return RedirectToAction("Index", "Image");
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