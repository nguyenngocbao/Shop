using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class UserDao
    {
        Shop db = null;
        public UserDao()
        {
            db = new Shop();
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
               
                user.Email = entity.Email;
               
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

       

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
       
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(k => k.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
       
    



}
}
