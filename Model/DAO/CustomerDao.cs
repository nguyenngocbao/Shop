using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CustomerDao
    {
        Shop db = null;


        public CustomerDao()
        {

            db = new Shop();


        }

        public List<Customer> list()
        {
            return db.Customers.ToList();
        }
        public void insert(Customer c)
        {

            db.Customers.Add(c);
            db.SaveChanges();


        }


        public Customer findByID(long? id)
        {
            return db.Customers.Find(id);
            throw new NotImplementedException();

        }
        public void update(Customer c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
        }
        public long delete(long id)
        {
            Customer c = db.Customers.Find(id);
            db.Customers.Remove(c);
            db.SaveChanges();
            return id;
        }
        public void dispose()
        {
            db.Dispose();
        }
    }


}
