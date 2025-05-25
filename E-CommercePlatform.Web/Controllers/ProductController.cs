using E_CommercePlatform.Data;
using E_CommercePlatform.Entities;
using E_CommercePlatform.Services;
using E_CommercePlatform.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace E_CommercePlatform.Web.Controllers
{
    public class ProductController : Controller
    {
        #region 单例模式
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();
        #endregion


        #region 一般用户界面
        #region 首页视图
        [HttpGet]
        public ActionResult ProductIndex()
        {
            var products = productService.FindAllProductsForUser();
            return View(products);
        }
        #endregion
        #endregion


        #region 超级用户界面
        #region 首页视图
        [HttpGet]
        public ActionResult ProductManagement()
        {
            var products = productService.FindAllProductsForAdmin();
            return View(products);
        }
        #endregion

        #region 新增视图
        [HttpGet]
        public ActionResult CreateProduct()
        {
            var model = new ProductFormAdminViewModel
            {
                CategoriesList = categoryService.FindAllCategoriesForAdmin()
            };
            return PartialView(model);
        }
        #endregion

        #region 修改视图
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var model = new ProductFormAdminViewModel
            {
                CategoriesList = categoryService.FindAllCategoriesForAdmin(),
                Product = productService.FindProductByIdForAdmin(id)
            };
            return PartialView(model);
        }
        #endregion
        #endregion


        #region 超级用户界面操作
        #region 查询操作
        //【查询视图操作】通过传入整型 searchKey 参数，查询包含名称关键字的相关类别数据。
        [HttpPost]
        public ActionResult GetProductByKeyForAdmin(string searchKey)
        {
            var products = productService.FindProductByKeyForAdmin(searchKey);
            return Json(new { Success = true, Result = products });
        }
        #endregion

        #region 新增操作
        //【新增视图操作】通过传入对象 Product 参数，新增商品数据。
        [HttpPost]
        public ActionResult CreateProduct(Product formData, HttpPostedFileBase ImageUrl)
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
                    string serverFilePath = Path.Combine(Server.MapPath("~/Content/Images/Products/"), uniqueFileName);

                    // 将本机图片完整路径，保存实体路径(服务器硬盘)
                    ImageUrl.SaveAs(serverFilePath);

                    // 表单数据中的图片路径 = 数据库的图片路径
                    formData.ImageUrl = "/Content/Images/Products/" + uniqueFileName;
                }

                // 调用服务层方法，新增商品信息到数据库
                productService.AddProduct(formData);
                return Json(new
                {
                    Success = true,
                    Message = "新增商品成功~！",
                    RedirectUrl = Url.Action("ProductManagement", "Product") // 重定向到管理商品
                });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }); // 返回给前端的数据错误信息
            }
        }
        #endregion

        #region 更新操作
        [HttpPost]
        public ActionResult UpdateProduct(ProductFormAdminViewModel formData, HttpPostedFileBase ImageUrl)
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
                    string serverFilePath = Path.Combine(Server.MapPath("~/Content/Images/Products/"), uniqueFileName);

                    // 将本机图片完整路径，保存实体路径(服务器硬盘)
                    ImageUrl.SaveAs(serverFilePath);

                    // 表单数据中的图片路径 = 数据库的图片路径
                    formData.Product.ImageUrl = "/Content/Images/Products/" + uniqueFileName;
                }
                else
                {
                    // 如果没有上传新图片，则保留原有图片路径
                    using (var context = new E_CommerceContext())
                    {
                        var originImageUrl = context.Products.Find(formData.Product.Id);
                        if (originImageUrl != null)
                        {
                            formData.Product.ImageUrl = originImageUrl.ImageUrl;
                        }
                    }
                }

                productService.ModifyProduct(formData);
                return Json(new
                {
                    Success = true,
                    Message = "更新商品成功~！",
                    RedirectUrl = Url.Action("ProductManagement", "Product") // 重定向到管理商品
                });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }); // 返回给前端的数据错误信息
            }

        }
        #endregion

        #region 删除操作
        //【删除操作】通过传入整型 id 参数，删除指定的类别数据。
        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                productService.RemoveProductById(id);
                return Json(new { Success = true, Message = "删除类别成功~！" }); // 返回给前端的数据
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }); // 返回给前端的数据错误信息
            }
        }
        #endregion
        #endregion
    }
}