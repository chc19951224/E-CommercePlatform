using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommercePlatform.Entities
{
    // Category类：表示商品类别的实体模型，继承BaseEntity的通用属性。
    public class Category : BaseEntity
    {
        public List<Product> AssociatedProducts { get; set; } // 关联的商品，表示一对多关系
        public string ImageUrl { get; set; } // 图片URL
        public bool IsFeatured { get; set; } // 是否推荐
    }
}
