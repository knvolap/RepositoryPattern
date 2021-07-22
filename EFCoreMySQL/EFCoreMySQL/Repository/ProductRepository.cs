using EFCoreMySQL.DBContexts;
using EFCoreMySQL.Model;
using EFCoreMySQL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Repository
{
    public class ProductRepository : IProduct
    {
        private MyDBContext context;

        public ProductRepository(MyDBContext context)
        {
            this.context = context;
        }
    
        public IEnumerable<Product> getListProduct() {
            return context.Products.ToList();
        }
       
        public void addProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void deleteProduct(int id)
        {
            Product product = context.Products.Find(id);
            //bất đồng bộ
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public void editProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }


        //làm chung cho tất cả các bản và gọi để sử dụng lại
    }
}
