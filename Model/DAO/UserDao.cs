using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public List<User> list()
        {
            return db.Users.ToList();
        }
        public void insert(User user)
        {

            db.Users.Add(user);
            db.SaveChanges();


        }


        public User findByID(long? id)
        {
            return db.Users.Find(id);
            throw new NotImplementedException();

        }
        public void update(User menu)
        {
            db.Entry(menu).State = EntityState.Modified;
            db.SaveChanges();
        }
        public long delete(long id)
        {
            User menu = db.Users.Find(id);
            db.Users.Remove(menu);
            db.SaveChanges();
            return id;
        }
        public void dispose()
        {
            db.Dispose();
        }

        public int Login(String username, String password)
        {
            //đặt biến result trả về đối 1 user bằng cách tìm xem trong bảng User có UserName giống với username nhận vào không?
            {
                var result = db.Users.SingleOrDefault(x => x.UserName == username);
                //nếu không có user 
                if (result == null)
                //user này không tồn tại <==> trả về 0
                { return 0; }
                else    //nếu tồn tại
                {            //nếu trang thái == false thì báo user này đang bị khóa  <==>  trả về -1
                    if (result.Status == false)
                    { return -1; }
                    else
                    // nếu đúng tài khoản và mật khẩu thì  <==>  trả về 1
                    {
                        if (result.Password == password)
                            return 1;
                        else
                            // nếu đúng tài khoản và  sai mật khẩu thì  <==>  trả về 2
                            return -2;
                    }
                }
            }
        }
    }








    }
