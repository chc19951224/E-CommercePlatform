using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommercePlatform.Shared
{
    public class CategoryAdminViewModel
    {
        public int Id { get; set; } // 类别的序号
        public string Name { get; set; } // 类别的名称
        public string ImageUrl { get; set; } // 类别的图片地址
        public string Description { get; set; } // 类别的描述
        public bool Feature { get; set; } // 特色的类别
    }
}
