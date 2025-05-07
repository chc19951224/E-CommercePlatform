using E_CommercePlatform.Entities;
using E_CommercePlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommercePlatform.Web.Controllers
{
    public class ProductController : Controller
    {
        //***** 全局变量声明 *****//
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();

        //***** 显示视图 *****//
        // 【首页视图】
        [HttpGet]
        public ActionResult Index()
        {
            var products = productService.FindAllProducts(); // 调用服务层方法，查询出所有商品数据
            return View(products);
        }

        // 【表格视图】
        [HttpGet]
        public ActionResult ProductTable()
        {
            return PartialView();
        }

        // 【新增视图】
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return PartialView();
        }

        // 【修改视图】
        [HttpGet]
        public ActionResult EditProduct()
        {
            return PartialView();
        }


        //***** 视图操作 *****//
        //【表格视图操作】通过传入对象 Product 参数，新增商品数据。
        [HttpPost]
        public ActionResult CreateProduct(Product feTableForm, HttpPostedFileBase ImageUrl)
        {
            return PartialView();
        }

        //【修改视图操作】通过传入对象 Product 参数，修改商品数据。
        [HttpPost]
        public ActionResult EditProduct(Product feTableForm)
        {
            return PartialView();
        }
    }
}