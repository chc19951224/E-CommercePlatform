using E_CommercePlatform.Data;
using E_CommercePlatform.Entities;
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
        //【查询】查询所有类别数据。
        public List<Category> FindAllCategories()
        {
            //【备注1 语法糖】using 用来显示释放资源，等价于 try...finally 语句。
            using (var context = new E_CommerceContext())
            {
                return context.Categories.ToList(); // 查询所有类别数据，并转换为列表返回
            }
        }

        //【查询】通过传入整型 id 参数，查询指定的类别数据。
        public Category FindCategoryById(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var category = context.Categories.Find(id); // 查询指定的类别数据
                return category; // 以对象类型返回
            }
        }

        //【新增】通过传入对象 category 参数，新增类别数据。
        public void AddCategory(Category category)
        {
            using (var context = new E_CommerceContext())
            {
                context.Categories.Add(category); // 新增类别数据
                context.SaveChanges(); // 提交新增
            }
        }

        //【修改】通过传入整型 id 参数，修改指定的类别数据。
        public void ModifyCategory(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var category = context.Categories.Find(id); // 查询指定的类别数据
                context.Entry(category).State = EntityState.Modified; // 修改类别数据
                context.SaveChanges(); // 提交修改
            }
        }

        //【删除】通过传入整型 id 参数，删除指定的类别数据。
        public void RemoveCategoryById(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var category = context.Categories.Find(id); // 查询指定的类别数据
                context.Entry(category).State = EntityState.Deleted; // 删除类别数据
                context.SaveChanges(); // 提交删除
            }
        }
    }
}
