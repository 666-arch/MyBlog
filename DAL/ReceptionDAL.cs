using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.EF;
namespace DAL
{
    public class ReceptionDAL
    {
        public static List<article> HomeIndex()
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                return db.article.ToList();
            }
        }
        public static List<cate> GetCates()
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result = (from c in db.cate where c.catname != "未分类" select c).ToList<cate>();
                return result;
            }
        }
        public static List<article> ShowLastest()
        {
            using (MyBlogEntities db = new MyBlogEntities()) 
            {
                var result = (from a in db.article orderby a.time descending select a).ToList<article>();
                return result;
            }
        }
        public static List<link> ShowLinks()
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result = (from li in db.link select li).ToList<link>();
                return result;
            }
        }
        public static List<article> ArticlesOfCate(int id)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result = (from a in db.article where a.cateid == id select a).ToList<article>();
                return result;
            }
        }
    }
}
