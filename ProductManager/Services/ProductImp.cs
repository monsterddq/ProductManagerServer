using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductManager.Services
{
    public class ProductImp : IProduct
    {
        private ProductManagerDBContext db;

        public ProductImp() => db = new ProductManagerDBContext();

        public bool AddProduct(Product p)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                if (db.Products.Any(w => w.Name.Equals(p.Name))) return false;
                db.Products.Add(p);
                db.SaveChanges();
                tran.Commit();
                return true;
            }
        }

        public void EditProduct(Product p)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                tran.Commit();
            }
        }

        public List<Product> FindByName(string id) => db.Products.Where(w => w.Name.Contains(id.Trim())).ToList();

        public List<Product> GetAll() => db.Products.ToList();
        public Product GetProduct(int id) => db.Products.Find(id);
        public void RemoveProduct(int id)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                db.Products.Remove(GetProduct(id));
                db.SaveChanges();
                tran.Commit();
            }
        }
    }
}
