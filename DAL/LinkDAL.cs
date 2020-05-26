using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.EF;
namespace DAL
{
    public class LinkDAL
    {
        public static List<link> Index()
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result = db.link.ToList();
                return result;
            }
        }
        public static int IsCheckLinkAdd(link link)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result = from l in db.link where l.title == link.title select l;
                if (result.Count()>0)
                {
                    return 0;
                }
                else
                {
                    db.link.Add(link);
                    db.SaveChanges();
                    return 1;
                }
                
            }
        }
        public static link UpdateLinks(int id)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                return db.link.Find(id);
            }
        }
        public static int IsCheckUpdateLinks(int linkId, string title, string url, string desc)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {

                var result = from l in db.link where l.title == title select l;
                if (result.Count()>0)
                {
                    return 0;
                }
                else
                {
                    link link = db.link.Find(linkId);
                    link.title = title;
                    link.url = url;
                    link.desc = desc;
                    db.Entry(link).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return 1;
                }
            }
        }
        public static void DeleteLink(int id)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                link link= db.link.Find(id);
                db.link.Remove(link);
                db.SaveChanges();
            }
        }
        public static void ManyDelete(int idStr)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                link link = db.link.Find(idStr);
                db.link.Remove(link);
                db.SaveChanges();
            }
        }
    }
}
