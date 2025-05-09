using E_CommercePlatform.Entities;
using E_CommercePlatform.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommercePlatform.Web.Controllers
{
    public class CategoryController : Controller
    {
        //***** 全局变量声明 *****//
        CategoryService categoryService = new CategoryService();


        //***** 显示视图 *****//
        //【浏览类别】
        [HttpGet]
        public ActionResult CategoryIndex()
        {
            var categorise = categoryService.FindAllCategories(); // 调用服务层方法，查询出所有类别数据
            return View(categorise);
        }

        //【新增视图】
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return PartialView();
        }

        //【修改视图】
        [HttpGet]
        public ActionResult UpdateCategory()
        {
            return PartialView();
        }


        //***** 视图操作 *****//
        //【表格视图操作】通过传入对象 Category 参数，新增类别数据。
        [HttpPost]
        public ActionResult CreateCategory(Category formData, HttpPostedFileBase ImageUrl)
        {
            try
            {
                // 判断用户是否上传图片，并且图片是否有效(字节数大于0)。
                if (ImageUrl != null && ImageUrl.ContentLength > 0)
                {
                    // 去除用户上传文件时的路径信息，只保留文件名，并赋值给变量。
                    string fileName = Path.GetFileName(ImageUrl.FileName);

                    // 使用Guid生成结构体的唯一标识符，并转为字符 + 原文件的扩展名，避免重名文件覆盖
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);

                    // 将控制器路由的相对路径转换为物理实体路径，并与文件名拼接成完整的文件路径。
                    string serverFilePath = Path.Combine(Server.MapPath("~/Content/Images/"), uniqueFileName);

                    // 将本机图片完整路径，保存实体路径(服务器硬盘)
                    ImageUrl.SaveAs(serverFilePath);

                    // 表单数据中的图片路径 = 数据库的图片路径
                    formData.ImageUrl = "/Content/Images/" + uniqueFileName;
                }

                // 调用服务层方法，新增类别信息到数据库
                categoryService.AddCategory(formData);
                return Json(new
                {
                    Success = true,
                    Message = "新增类别成功~！",
                    RedirectUrl = Url.Action("Index", "Category") // 重定向到类别首页视图
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }); // 返回给前端的数据错误信息
            }
        }

        //【修改视图操作】通过传入对象 Category 参数，修改类别数据。
        [HttpPost]
        public ActionResult EditCategory(Category feTableForm)
        {
            return PartialView();
        }
    }
}