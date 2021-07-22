using EFCoreMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMySQL.Service
{
    public interface IProduct
    {
        public IEnumerable<Product> getListProduct();

        void addProduct(Product product);

        void editProduct(Product product);

        void deleteProduct(int id);

    }
}
