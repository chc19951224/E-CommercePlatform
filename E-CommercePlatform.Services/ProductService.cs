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
    public class ProductService
    {
        //【查询】查询所有商品数据。
        public List<Product> FindAllProducts()
        {
            //【备注1 语法糖】using 用来显示释放资源，等价于 try...finally 语句。
            using (var context = new E_CommerceContext())
            {
                return context.Products.ToList(); // 查询所有商品数据，并转换为列表返回
            }
        }

        //【查询】通过传入整型 id 参数，查询指定的商品数据。
        public Product FindProductById(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var product = context.Products.Find(id); // 查询指定的商品数据
                return product; // 以对象类型返回
            }
        }

        //【新增】通过传入对象 category 参数，新增商品数据。
        public void AddProduct(Product product)
        {
            using (var context = new E_CommerceContext())
            {
                context.Products.Add(product); // 新增商品数据
                context.SaveChanges(); // 提交新增
            }
        }

        //【修改】通过传入整型 id 参数，修改指定的商品数据。
        public void ModifyProduct(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var product = context.Products.Find(id); // 查询指定的商品数据
                context.Entry(product).State = EntityState.Modified; // 修改商品数据
                context.SaveChanges(); // 提交修改
            }
        }

        //【删除】通过传入整型 id 参数，删除指定的商品数据。
        public void RemoveProductById(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var product = context.Categories.Find(id); // 查询指定的商品数据
                context.Entry(product).State = EntityState.Deleted; // 删除商品数据
                context.SaveChanges(); // 提交删除
            }
        }
    }
}
