using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Model.DAO
{
    public class ServiceDAO
    {
        CPM db = null;
        public ServiceDAO()
        {
            db = new CPM();
        }
        public long Insert(Service entity)
        {
            db.Services.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<Service> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Service> model = db.Services;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public Service ViewDetail(int ID)
        {
            return db.Services.Find(ID);
        }
        public bool Delete(int id)
        {
            try
            {
                var service = db.Services.Find(id);
                db.Services.Remove(service);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Update(Service entity)
        {
            try
            {
                var service = db.Services.Find(entity.ID);
                service.Name = entity.Name;
                service.Price = entity.Price;
                service.Detail = entity.Detail;
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
