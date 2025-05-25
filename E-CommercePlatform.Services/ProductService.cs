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
    public class ProductService
    {
        #region 实体模型-视图模型
        #region 一般用户实体映射
        // 通过传入对象 Product 类型参数，将实体模型映射到一般用户视图模型。
        private ProductUserViewModel MapToUserViewModel(Product product)
        {
            return new ProductUserViewModel
            {
                CategoryId = product.AssociatedCategory.Id,
                CategoryName = product.AssociatedCategory.Name,

                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                Price = product.Price,
                Feature = product.Feature
            };
        }
        #endregion

        #region 超级用户实体映射
        private ProductAdminViewModel MapToAdminViewModel(Product product)
        {
            return new ProductAdminViewModel
            {
                CategoryId = product.AssociatedCategory.Id,
                CategoryName = product.AssociatedCategory.Name,

                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                Price = product.Price,
                Feature = product.Feature
            };
        }
        #endregion
        #endregion

        #region 一般用户服务
        #region 查询服务
        //【查询】查询所有商品数据。
        public List<ProductUserViewModel> FindAllProductsForUser()
        {
            //【备注1 语法糖】using 方法用来显示释放资源。
            using (var context = new E_CommerceContext())
            {
                //【备注2】Include 方法用于指定要加载导航数据。
                var products = context.Products.Include(p => p.AssociatedCategory).ToList();
                return products.Select(p => MapToUserViewModel(p)).ToList();
            }
        }

        //【查询】通过传入整型 id 参数，查询指定的商品数据。
        public ProductUserViewModel FindProductByIdForUser(int id)
        {
            using (var context = new E_CommerceContext())
            {
                //【备注3】使用 Include 方法就需要改用 FirstOrDefault 方法，因为 Find 方法不支持延迟加载。
                var product = context.Products.Include(p => p.AssociatedCategory).FirstOrDefault(p => p.Id == id);
                return product != null ? MapToUserViewModel(product) : null;
            }
        }

        //【查询】通过传入整型 searchKey 参数，查询名称包含关键字的相关商品数据。
        public List<ProductUserViewModel> FindProductByKeyForUser(string searchKey)
        {
            using (var context = new E_CommerceContext())
            {
                //【备注3】AsQueryable 方法将查询结果转换为 IQueryable 接口对象，以便进行进一步的LINQ查询操作。
                var query = context.Products.Include(x => x.AssociatedCategory).AsQueryable();

                // 如果 searchKey 不为无效或空字符串，则进行关键字筛选
                if (!string.IsNullOrEmpty(searchKey))
                {
                    query = query.Where(p => p.Name.Contains(searchKey) || p.AssociatedCategory.Name.Contains(searchKey));
                }

                return query.ToList().Select(p => MapToUserViewModel(p)).ToList(); //将实体模型数据映射到视图模型
            }
        }

        //【查询】查询指定的关联类别数据。
        public List<ProductUserViewModel> FindAssociatedCategoryForUser()
        {
            using (var context = new E_CommerceContext())
            {
                var model = context.Products.Include(p => p.AssociatedCategory).ToList();
                return model.Select(p => MapToUserViewModel(p)).ToList();
            }
        }
        #endregion
        #endregion

        #region 超级用户服务
        #region 查询服务
        //【查询】查询所有商品数据。
        public List<ProductAdminViewModel> FindAllProductsForAdmin()
        {
            using (var context = new E_CommerceContext())
            {
                var products = context.Products.Include(p => p.AssociatedCategory).ToList();
                return products.Select(p => MapToAdminViewModel(p)).ToList();
            }
        }

        //【查询】通过传入整型 id 参数，查询指定的商品数据。
        public ProductAdminViewModel FindProductByIdForAdmin(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var product = context.Products.Include(p => p.AssociatedCategory).FirstOrDefault(p => p.Id == id);
                return MapToAdminViewModel(product);
            }
        }

        //【查询】通过传入整型 searchKey 参数，查询名称包含关键字的相关商品数据。
        public List<ProductAdminViewModel> FindProductByKeyForAdmin(string searchKey)
        {
            using (var context = new E_CommerceContext())
            {
                var query = context.Products.Include(x => x.AssociatedCategory).AsQueryable();

                if (!string.IsNullOrEmpty(searchKey))
                {
                    query = query.Where(p => p.Name.Contains(searchKey) || p.AssociatedCategory.Name.Contains(searchKey));
                }

                return query.ToList().Select(p => MapToAdminViewModel(p)).ToList();
            }
        }

        //【查询】查询指定的关联类别数据。
        public List<ProductAdminViewModel> FindAssociatedCategoryForAdmin()
        {
            using (var context = new E_CommerceContext())
            {
                var associatedCategories = context.Products.Include(p => p.AssociatedCategory).ToList();
                return associatedCategories.Select(p => MapToAdminViewModel(p)).ToList();
            }
        }
        #endregion

        #region 新增服务
        //【新增】通过传入对象 product 参数，新增商品数据。
        public void AddProduct(Product product)
        {
            using (var context = new E_CommerceContext())
            {
                context.Products.Add(product); // 新增商品数据
                context.SaveChanges(); // 提交新增
            }
        }
        #endregion

        #region 修改服务
        public void ModifyProduct(ProductFormAdminViewModel viewModel)
        {
            using (var context = new E_CommerceContext())
            {
                var product = context.Products.Include(p => p.AssociatedCategory).FirstOrDefault(p => p.Id == viewModel.Product.Id);
                if (product == null)
                {
                    throw new Exception("未找到该商品！");
                }

                product.Name = viewModel.Product.Name;
                product.ImageUrl = viewModel.Product.ImageUrl;
                product.Description = viewModel.Product.Description;
                product.Price = viewModel.Product.Price;
                product.Feature = viewModel.Product.Feature;

                var category = context.Categories.Find(viewModel.Product.CategoryId);
                if (category != null)
                {
                    product.AssociatedCategory = category;
                }

                context.SaveChanges();
            }
        }
        #endregion

        #region 删除服务
        //【删除】通过传入整型 id 参数，删除指定的商品数据。
        public void RemoveProductById(int id)
        {
            using (var context = new E_CommerceContext())
            {
                var product = context.Products.Find(id); // 查询指定的商品数据
                context.Entry(product).State = EntityState.Deleted; // 删除商品数据
                context.SaveChanges(); // 提交删除
            }
        }
        #endregion
        #endregion
    }
}
