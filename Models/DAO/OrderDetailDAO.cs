using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDetailDAO : IRepository<OrderDetail>
    {
        ShopBikeDbContext db = null;
        public OrderDetailDAO()
        {
            db = new ShopBikeDbContext();
        }
        public bool Create(OrderDetail entity)
        {
            try
            {
                db.OrderDetails.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(OrderDetail entity)
        {
            try
            {
                db.OrderDetails.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<OrderDetail> GetListODById(int id)
        {
            return db.OrderDetails.Where(x => x.OrderID == id);
        }

        public IEnumerable<OrderDetail> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<OrderDetail> model = db.OrderDetails;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ProductID == Int32.Parse(searchString));
            }
            return model.OrderBy(x => x.OrderID).ToPagedList(page, pageSize);
        }

        public bool Update(OrderDetail entity)
        {
            try
            {
                var oldItem = db.OrderDetails.Where(x => x.OrderID == entity.OrderID && x.ProductID == entity.ProductID).FirstOrDefault();
                oldItem.Quantity = entity.Quantity;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        OrderDetail IRepository<OrderDetail>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
