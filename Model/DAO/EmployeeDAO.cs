using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Model.DAO
{
    public class EmployeeDAO
    {
        CPM db = null;
        public EmployeeDAO()
        {
            db = new CPM();
        }
        public long Insert(Employee entity)
        {
            db.Employees.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<Employee> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Employee> model = db.Employees;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public Employee ViewDetail(int ID)
        {
            return db.Employees.Find(ID);
        }
        public bool Delete(int id)
        {
            try
            {
                var employee = db.Employees.Find(id);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Update(Employee entity)
        {
            try
            {
                var employee = db.Employees.Find(entity.ID);
                employee.Name = entity.Name;
                employee.Phone = entity.Phone;
                employee.Email = entity.Email;
                employee.Address = entity.Address;
                employee.Gender = entity.Gender;
                employee.Position = entity.Position;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
