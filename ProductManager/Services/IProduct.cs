using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.Services
{
    interface IProduct
    {
        bool AddProduct(Product p);
        List<Product> GetAll();
        List<Product> FindByName(string id);
        Product GetProduct(int id);
        void EditProduct(Product p);
        void RemoveProduct(int id);
    }
}
