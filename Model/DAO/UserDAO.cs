using PagedList;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.DAO
{
    public class UserDAO
    {
        CPM db = null;
        public UserDAO()
        {
            db = new CPM();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;        }
        public User getByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public bool Login (string userName, string passWord)
        {
            var result = db.Users.Count(x => x.UserName == userName &&  x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return  false;
            }


        }
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public User ViewDetail(int ID)
        {
            return db.Users.Find(ID);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.UserName = entity.UserName;
                user.Password = entity.Password;
                user.Status = entity.Status;
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