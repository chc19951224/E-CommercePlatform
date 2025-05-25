using E_CommercePlatform.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommercePlatform.Shared
{
    public class ProductAdminViewModel
    {
        // 额外属性
        public int CategoryId { get; set; } // 商品所属分类的序号
        public string CategoryName { get; set; } // 商品所属的分类名称

        // 基本属性
        public int Id { get; set; } // 商品的序号
        public string Name { get; set; } // 商品的名称
        public string ImageUrl { get; set; } // 商品的图片地址
        public string Description { get; set; } // 商品的描述
        public decimal Price { get; set; } // 商品的价格
        public bool Feature { get; set; } // 特色的商品
    }
}
