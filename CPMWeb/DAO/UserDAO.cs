using CPMWeb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPMWeb.DAO
{
    public class UserDAO
    {
        CPMDbContext db = null;
        public UserDAO()
        {
            db = new CPMDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;        }
        public bool Login (string userName, string passWord)
        {
            var result = db.Users.Count(x => x.UserName == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                false;
            }


        }
    }
}