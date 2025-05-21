using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommercePlatform.Entities
{
    // BaseEntity类：表示所有实体模型的通用属性。
    public class BaseEntity
    {
        public int Id { get; set; } // 序号，主键
        public string Name { get; set; } // 名称
        public string Description { get; set; } // 描述
        public bool Feature { get; set; } // 特色
        public string ImageUrl { get; set; } // 图片URL
    }
}
