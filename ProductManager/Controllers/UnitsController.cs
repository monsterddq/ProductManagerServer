using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Services;
using ProductManager.Models;

namespace UnitManager.Controllers
{
    public class UnitsController : Controller
    {
        private IUnit Unit;
        public UnitsController() => Unit = new UnitImp();

        [HttpPost]
        [Route("api/unit/create")]
        public bool Create(Unit p) => Unit.AddUnit(p);

        [HttpGet]
        [Route("api/unit/getall")]
        public List<Unit> GetAll() => Unit.GetAll();

        [HttpGet]
        [Route("api/unit/get")]
        public Unit Get(int id) => Unit.GetUnit(id);

        [HttpGet]
        [Route("api/unit/search")]
        public List<Unit> SearchByName(string id) => Unit.FindByName(id);

        [HttpPut]
        [Route("api/unit/edit")]
        public void Edit(Unit p) => Unit.EditUnit(p);

        [HttpDelete]
        [Route("api/unit/delete")]
        public bool Delete(int id) => Unit.RemoveUnit(id);
    }
}