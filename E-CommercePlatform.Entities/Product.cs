using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommercePlatform.Entities
{
    // Product类：表示商品的实体模型，继承BaseEntity的通用属性。
    public class Product : BaseEntity
    {
        public Category AssociatedCategory { get; set; } // 关联的类别，表示多对一关系
        public int AssociatedCategoryId { get; set; } // 类别的序号(外键)
        public decimal Price { get; set; } // 商品的价格
    }
}
