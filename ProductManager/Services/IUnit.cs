using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.Services
{
    interface IUnit
    {
        bool AddUnit(Unit u);
        List<Unit> GetAll();
        void EditUnit(Unit u);
        bool RemoveUnit(int id);
        List<Unit> FindByName(string id);
        Unit GetUnit(int id);
    }
}
