using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class CategoryDao
    {
        Shop db = null;


        public CategoryDao()
        {
            db = new Shop();


        }

        public List<Category> list()
        {
            return db.Categories.ToList();
        }
        public void insert(Category c)
        {
            
            db.Categories.Add(c);
            db.SaveChanges();
           

        }


        public Category findByID(long? id)
        {
            return db.Categories.Find(id);
            throw new NotImplementedException();

        }
        public void update(Category c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
        }
        public long delete(long id)
        {
            Category c = db.Categories.Find(id);
            db.Categories.Remove(c);
            db.SaveChanges();
            return id;
        }
        public void dispose()
        {
            db.Dispose();
        }
    }
}
