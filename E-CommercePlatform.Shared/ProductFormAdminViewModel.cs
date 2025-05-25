using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommercePlatform.Shared
{
    public class ProductFormAdminViewModel
    {
        public List<CategoryAdminViewModel> CategoriesList { get; set; } // 商品所属分类列表
        public ProductAdminViewModel Product { get; set; } // 商品数据
    }
}
