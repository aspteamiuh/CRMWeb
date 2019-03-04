using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Model.DAO
{
    public class CustomerDAO
    {
        CPM db = null;
        public CustomerDAO()
        {
            db = new CPM();
        }
        public long Insert(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<Customer> ListAllPaging(int page,int pageSize)
        {
            return db.Customers.OrderByDescending(x=>x.ID).ToPagedList(page,pageSize);
        }
    }
}
