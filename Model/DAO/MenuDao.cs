using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data.Entity;

namespace Model.DAO
{
   public class MenuDao

    {
        Shop db = null;
       

        public  MenuDao()
        {
            db = new Shop();


        }
        
        public List<Menu> list()
        {
            return db.Menus.ToList();
        }
        public long insert(Menu menu)
        {
            
            db.Menus.Add(menu);
            db.SaveChanges();
            return menu.ID;

        }
        

        public Menu findByID(long? id)
        {
            return db.Menus.Find(id);
            throw new NotImplementedException();
           
        }
        public void update(Menu menu)
        {
            db.Entry(menu).State = EntityState.Modified;
            db.SaveChanges();
        }
        public long delete(long id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
            db.SaveChanges();
            return id;
        }
        public void dispose()
        {
            db.Dispose();
        }
    }
}
