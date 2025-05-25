using E_CommercePlatform.Data;
using E_CommercePlatform.Entities;
using E_CommercePlatform.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommercePlatform.Services
{
    public class CategoryService
    {
        #region 分类实体模型 -> 分类视图模型
        #region 一般用户实体映射
        private CategoryUserViewModel MapToUserViewModel(Category category)
        {
            return new CategoryUserViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                Description = category.Description,
                Feature = category.Feature
            };
        }
        #endregion

        #region 超级用户实体映射
        private CategoryAdminViewModel MapToAdminViewModel(Category category)
        {
            return new CategoryAdminViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                Description = category.Description,
                Feature = category.Feature
            };
        }
        #endregion
        #endregion


        #region 一般用户服务
        #region 【查询】浏览所有分类
        public List<CategoryUserViewModel> FindAllCategoriesForUser()
        {
            using (var context = new E_CommerceContext())
            {
                var categories = context.Categories.ToList();
                return categories.Select(c => MapToUserViewModel(c)).ToList();
            }
        }
        #endregion
        #region 【查询】根据 id 找到指定分类
        public CategoryAdminViewModel FindCategoryByIdForUser(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var category = context.Categories.FirstOrDefault(c => c.Id == id);
                return MapToAdminViewModel(category);
            }
        }
        #endregion
        #region 【查询】根据 searchKey 找到含有关键字所有分类
        public List<CategoryAdminViewModel> FindCategoryByKeyForUser(string searchKey)
        {
            using (var context = new E_CommerceContext())
            {
                var category = context.Categories.Where(c => c.Name.Contains(searchKey)).ToList();
                return category.Select(c => MapToAdminViewModel(c)).ToList();
            }
        }
        #endregion
        #endregion


        #region 超级用户服务
        #region 【查询】管理所有分类
        public List<CategoryAdminViewModel> FindAllCategoriesForAdmin()
        {
            using (var context = new E_CommerceContext())
            {
                var categories = context.Categories.ToList();
                return categories.Select(c => MapToAdminViewModel(c)).ToList();
            }
        }
        #endregion
        #region 【查询】根据 id 找到指定分类
        public CategoryAdminViewModel FindCategoryByIdForAdmin(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var category = context.Categories.FirstOrDefault(c => c.Id == id);
                return MapToAdminViewModel(category);
            }
        }
        #endregion
        #region 【查询】根据 searchKey 找到含有关键字所有分类
        public List<CategoryAdminViewModel> FindCategoryByKeyForAdmin(string searchKey)
        {
            using (var context = new E_CommerceContext())
            {
                var category = context.Categories.Where(c => c.Name.Contains(searchKey)).ToList();
                return category.Select(c => MapToAdminViewModel(c)).ToList();
            }
        }
        #endregion


        #region 【新增】添加新的分类
        public void AddCategory(Category category)
        {
            using (var context = new E_CommerceContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        #endregion

        #region 【修改】更新已有分类
        public void ModifyCategory(Category category)
        {
            using (var context = new E_CommerceContext())
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        #endregion

        #region 【删除】删除已有分类
        public void RemoveCategoryById(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var category = context.Categories.Find(id);
                context.Entry(category).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        #endregion
        #endregion
    }
}
