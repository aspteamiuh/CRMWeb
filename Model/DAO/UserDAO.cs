
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
    }
}