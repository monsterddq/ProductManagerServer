using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Services
{
    public class UnitImp : IUnit
    {
        private ProductManagerDBContext db;

        public UnitImp() => db = new ProductManagerDBContext();
        
        public bool AddUnit(Unit u)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                if (db.Units.Any(w => w.Name.Equals(u.Name))) return false;
                db.Units.Add(u);
                db.SaveChanges();
                tran.Commit();
                return true;
            }
        }

        public void EditUnit(Unit u)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                db.Entry(u).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                tran.Commit();
            }
        }

        public List<Unit> GetAll() => db.Units.ToList();

        public Unit GetUnit(int id) => db.Units.Find(id);

        public bool RemoveUnit(int id)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                if (db.Products.Any(w => w.UnitId == id)) return false;
                db.Units.Remove(GetUnit(id));
                db.SaveChanges();
                tran.Commit();
                return true;
            }
        }

        public List<Unit> FindByName(string id) => db.Units.Where(w => w.Name.Contains(id.Trim())).ToList();
    }
}
