using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.EF;
namespace DAL
{
    public class CategoryDAL
    {
        public static List<cate> Index(int page=1)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result = (from c in db.cate where c.catname != "未分类" select c).ToList<cate>();
                return result;
            }
        }
        public static int IsCheckAddCate(cate cate)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                try
                {
                    db.cate.Add(cate);
                    db.SaveChanges();
                    return 1;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static cate UpdateCate(int id)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                cate cate = db.cate.Find(id);
                return cate;
            }
        }
        public static int IsCheckUpdateCate(int cateId, string cateName)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                try
                {
                    var result = db.cate.Find(cateId);
                    result.catname = cateName;
                    db.SaveChanges();
                    return 1;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static void DeleteCate(int id)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result= db.cate.Find(id);
                int cid= result.id;
                var article = from ar in db.article where ar.cateid == cid select ar;
                if (article.Count()>0)
                {
                    foreach (var item in article)
                    {
                        item.cateid = 1;
                    }
                }
                db.cate.Remove(result);
                db.SaveChanges();
            }
        }
        public static void SelectAllDelete(int idStr)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                cate cate = db.cate.Find(idStr);
                db.cate.Remove(cate);
                db.SaveChanges();
            }
        }
    }
}
