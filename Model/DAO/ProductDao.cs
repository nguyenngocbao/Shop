using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.DAO
{
  public  class ProductDao
    {
        Shop db = null;


        public  ProductDao()
        {
            db = new Shop();


        }
        public List<Product> listTopHot(int top)
        {
            return db.Products.OrderByDescending(x => x.TopHot).Take(top).ToList();
        }

        public List<Product> list()
        {
            return db.Products.ToList();
        }

        public Product findByID(long? id)
        {
            return db.Products.Find(id);
            throw new NotImplementedException();
        }

        public void insert(Product prduct)
        {
            db.Products.Add(prduct);
            db.SaveChanges();
        }

        public void update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void delete(long id)
        {
            Product pro = db.Products.Find(id);
            db.Products.Remove(pro);
            db.SaveChanges();

        }

        public void disponse()
        {
            db.Dispose();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
    }
}
