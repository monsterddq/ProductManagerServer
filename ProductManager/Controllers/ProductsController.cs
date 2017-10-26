using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Services;

namespace ProductManager.Controllers
{
    public class ProductsController : Controller
    {
        private IProduct product;
        public ProductsController() => product = new ProductImp();

        [HttpPost]
        [Route("api/product/create")]
        public bool Create(Product p) => product.AddProduct(p);

        [HttpGet]
        [Route("api/product/getall")]
        public List<Product> GetAll() => product.GetAll();

        [HttpGet]
        [Route("api/product/get")]
        public Product Get(int id) => product.GetProduct(id);

        [HttpGet]
        [Route("api/product/search")]
        public List<Product> SearchByName(string id) => product.FindByName(id);

        [HttpPut]
        [Route("api/product/edit")]
        public void Edit(Product p) => product.EditProduct(p);

        [HttpDelete]
        [Route("api/product/delete")]
        public void Delete(int id) => product.RemoveProduct(id);
    }
}