using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.EF;
namespace DAL
{
    public class ArticleDAL
    {
        public static List<article> Index()
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                return db.article.Include("cate").Include("admin").ToList<article>();
            }
        }
        public static List<article> Index(string username)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result = (from a in db.article where a.admin.username == username select a).ToList<article>();
                return result;
            }
        }
        public static void ArticleDelete(int id)
        {
            using (MyBlogEntities db=new MyBlogEntities())
            {
                article article = db.article.Find(id);
                db.article.Remove(article);
                db.SaveChanges();
            }
        }
        public static void ArticleAllDelete(int ids)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                article article= db.article.Find(ids);
                db.article.Remove(article);
                db.SaveChanges();
            }
        }
        public static List<cate> SelectCateToAricle()
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result = (from ca in db.cate select ca).ToList<cate>();
                return result;
            }
        }
        public static int IsCheckedAddArticle(article article, string author)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result = from a in db.admin where a.username == author select a;
                foreach (var item in result)
                {
                    article.creator = item.id;
                }
                db.article.Add(article);
                db.SaveChanges();
                return 1;
            }
        }
        public static article UpdateArticle(int id)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                return db.article.Include("admin").Include("cate").FirstOrDefault(a => a.id == id);
            }
        }
        public static int IsCheckArticleUpdate(article article)
        {
            using (MyBlogEntities db=new MyBlogEntities())
            {
                db.Entry(article).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
        }
        public static article Detail(int id)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                return db.article.Include("admin").Include("cate").FirstOrDefault(a=>a.id==id);
            }
        }
    }
}
