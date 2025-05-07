using E_CommercePlatform.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace E_CommercePlatform.Data
{
    // Context类：表示数据库上下文，继承自DbContext类(Entity Framework的核心类)、IDisposable接口(用于释放资源)。
    public class E_CommerceContext : DbContext, IDisposable
    {
        public E_CommerceContext() : base("name=E_CommerceContext")
        {
        }

        // DbSets集合，表示数据库中的表
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
