using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ListService
    {
        public List<ListDTO> Get()
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                return Convertion.ListsConvertion.Convert(db.lists.ToList());
            }
        }
        // GET: api/Lists/5
        public ListDTO Get(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                Convertion.ListsConvertion.Convert(db.lists.FirstOrDefault(x => x.Id == id));
            }
            return null;
        }
        // POST: api/Lists
        public ListDTO Post(EventDTO l)
        {
            list list = null;
            using (dbprojectEntities db = new dbprojectEntities())
            {
                if (db.lists.Any(x => x.Name == l.Name))
                {
                      db.lists.FirstOrDefault(y => y.Name == l.Name).listDetails = l.Categories.Select(x=> new listDetail() { CategoryId = x }).ToList();
                }
                else
                {
                    list = new list()
                    {
                        Name = l.Name,
                        listDetails = l.Categories.Select(x => new listDetail() { CategoryId = x }).ToList()
                    };
                    list = db.lists.Add(list);
                }
                db.SaveChanges();
                return Convertion.ListsConvertion.Convert(list);
            }
        }
        public void Post(string name)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                if (!db.lists.Any(x => x.Name == name))
                {
                    ListDTO l = new ListDTO();
                    l.Name = name;
                    db.lists.Add(Convertion.ListsConvertion.Convert(l));
                    db.SaveChanges();
                }
            }
        }

        // PUT: api/Lists/5
        public ListDTO Put(int id, ListDTO l)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                list ll = db.lists.FirstOrDefault(x => x.Id == id);
                if (ll != null)
                {
                    ll.Name = l.Name;
                    db.SaveChanges();
                    return Convertion.ListsConvertion.Convert(ll);
                }
                return null;
            }
        }
        // DELETE: api/Lists/5
        public void Delete(int id)
        {
            using (dbprojectEntities db = new dbprojectEntities())
            {
                list l = db.lists.FirstOrDefault(x => x.Id == id);
                db.lists.Remove(l);
                db.SaveChanges();
            }
        }
    }
}
