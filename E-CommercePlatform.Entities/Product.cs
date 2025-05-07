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
        public Category AssociatedCategory { get; set; } // 关联的分类，表示多对一关系
        public decimal Price { get; set; } // 价格
    }
}
