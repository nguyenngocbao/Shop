using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDao
    {
        Shop db = null;
        public OrderDao()
        {
            db = new Shop();
        }
        public List<Order> list()
        {
            return db.Orders.ToList();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public Order findByID(long? id)
        {
            return db.Orders.Find(id);
            throw new NotImplementedException();

        }
        public void update(Order menu)
        {
            db.Entry(menu).State = EntityState.Modified;
            db.SaveChanges();
        }
        public long delete(long id)
        {
            Order menu = db.Orders.Find(id);
            db.Orders.Remove(menu);
            db.SaveChanges();
            return id;
        }
        public void dispose()
        {
            db.Dispose();
        }
        public List<OrderDetail> detail(long id)
        {
            var name = from table in db.OrderDetails
                       where table.OrderID == id
                       select table;
            return name.ToList();

        }
    }
}
