using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommercePlatform.Shared
{
    public class CategoryUserViewModel
    {
        public int Id { get; set; } // 类别ID
        public string Name { get; set; } // 类别名称
        public string ImageUrl { get; set; } // 类别图片URL
        public string Description { get; set; } // 类别描述
        public bool Feature { get; set; } // 特色类别
    }
}
