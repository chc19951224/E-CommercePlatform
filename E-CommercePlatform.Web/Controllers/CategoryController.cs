using E_CommercePlatform.Entities;
using E_CommercePlatform.Services;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace E_CommercePlatform.Web.Controllers
{
    public class CategoryController : Controller
    {
        #region 单例模式
        CategoryService categoryService = new CategoryService();
        #endregion


        #region 一般用户界面
        #region 首页视图
        [HttpGet]
        public ActionResult CategoryIndex()
        {
            var categorise = categoryService.FindAllCategoriesForUser();
            return View(categorise);
        }
        #endregion
        #endregion


        #region 超级用户界面
        #region 首页视图
        [HttpGet]
        public ActionResult CategoryManagement()
        {
            var categorise = categoryService.FindAllCategoriesForAdmin();
            return View(categorise);
        }
        #endregion

        #region 新增视图
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return PartialView();
        }
        #endregion

        #region 修改视图
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = categoryService.FindCategoryByIdForAdmin(id);
            return PartialView("UpdateCategory", category);
        }
        #endregion
        #endregion

        #region 超级用户界面操作
        #region 查询操作
        [HttpPost]
        public ActionResult GetCategoryByKeyForAdmin(string searchKey)
        {
            var category = categoryService.FindCategoryByKeyForAdmin(searchKey);
            return Json(new { Success = true, Result = category });
        }
        #endregion

        #region 新增操作
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
                    string serverFilePath = Path.Combine(Server.MapPath("~/Content/Images/Categories/"), uniqueFileName);

                    // 将本机图片完整路径，保存实体路径(服务器硬盘)
                    ImageUrl.SaveAs(serverFilePath);

                    // 表单数据中的图片路径 = 数据库的图片路径
                    formData.ImageUrl = "/Content/Images/Categories/" + uniqueFileName;
                }

                categoryService.AddCategory(formData);
                return Json(new
                {
                    Success = true,
                    Message = "新增分类成功~！",
                    RedirectUrl = Url.Action("CategoryManagement", "Category")
                });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
        #endregion

        #region 修改操作
        [HttpPost]
        public ActionResult UpdateCategory(Category formData, HttpPostedFileBase ImageUrl)
        {
            try
            {
                var oldCategory = categoryService.FindCategoryByIdForAdmin(formData.Id); // 先读取原始类别数据
                if (oldCategory == null)
                {
                    return Json(new { success = false, message = "未找到该分类！" });
                }


                // 判断用户是否上传图片，并且图片是否有效(字节数大于0)。
                if (ImageUrl != null && ImageUrl.ContentLength > 0)
                {
                    // 去除用户上传文件时的路径信息，只保留文件名，并赋值给变量。
                    string fileName = Path.GetFileName(ImageUrl.FileName);

                    // 使用Guid生成结构体的唯一标识符，并转为字符 + 原文件的扩展名，避免重名文件覆盖
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);

                    // 将控制器路由的相对路径转换为物理实体路径，并与文件名拼接成完整的文件路径。
                    string serverFilePath = Path.Combine(Server.MapPath("~/Content/Images/Categories/"), uniqueFileName);

                    // 将本机图片完整路径，保存实体路径(服务器硬盘)
                    ImageUrl.SaveAs(serverFilePath);

                    // 表单数据中的图片路径 = 数据库的图片路径
                    formData.ImageUrl = "/Content/Images/Categories/" + uniqueFileName;
                }
                else
                {
                    // 如果没有上传新图片，则保留原有图片路径
                    formData.ImageUrl = oldCategory.ImageUrl;
                }

                // 调用服务层方法，更新类别数据到数据库
                categoryService.ModifyCategory(formData);
                return Json(new
                {
                    Success = true,
                    Message = "更新分类成功~！",
                    RedirectUrl = Url.Action("CategoryManagement", "Category")
                });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
        #endregion

        #region 删除操作
        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                categoryService.RemoveCategoryById(id);
                return Json(new { Success = true, Message = "删除分类成功~！" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
        #endregion
        #endregion
    }
}