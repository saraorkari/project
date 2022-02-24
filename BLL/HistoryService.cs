using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class HistoryService
    {
        public List<HistoryDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.HistoryConvertion.Convert(db.histories.ToList());
            }
        }

        // GET: api/Areas/5
        public HistoryDTO Get(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.HistoryConvertion.Convert(db.histories.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }
        public List<HistoryDTO> Get(string UserId)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.HistoryConvertion.Convert(db.histories.Where(x => x.UserId == UserId).ToList());
            }
        }
        // POST: api/Areas
        public List<ProductWhithShop> Post(HistoryDTO h)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                if (h.UserId != null)
                {
                    history history = db.histories.FirstOrDefault(x => x.UserId == h.UserId && x.ProductName == h.ProductName);
                    if (history == null)
                    {
                        history = db.histories.Add(Convertion.HistoryConvertion.Convert(h));
                        db.SaveChanges();
                    };
                }
                return Convertion.ProductConvertion.Convert1(db.products.Where(x => x.Name.Contains(h.ProductName)).ToList()).OrderBy(x=>x.Id).ToList();
            }
        }

        // PUT: api/Areas/5
        public HistoryDTO Put(int id, HistoryDTO h)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                history hh = db.histories.FirstOrDefault(x => x.Id == id);
                if (hh != null)
                {
                    hh.ProductName = h.ProductName;
                    hh.UserId = h.UserId;
                    db.SaveChanges();
                    return Convertion.HistoryConvertion.Convert(hh);
                }
                return null;
            }
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                history h = db.histories.FirstOrDefault(x => x.Id == id);
                db.histories.Remove(h);
                db.SaveChanges();
            }
        }
    }
}
