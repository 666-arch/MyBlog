using Model.EF;
using System.Collections.Generic;
using System.Linq;
namespace DAL
{
    public class AdminDAL
    {
        public static List<admin> CheckLogin(string username, string password)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                return db.admin.Where(a => a.username == username)
                    .Where(a => a.password == password)
                    .ToList();
            }
        }
        public static List<admin> PersonInfo(int page=1)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                return (from u in db.admin where u.username != "admin" select u).ToList<admin>();
            }
        }
        public static int UserAdd(string userName, string pwd)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                admin admin = new admin()
                {
                    username = userName,
                    password = pwd
                };
                db.admin.Add(admin);
                return db.SaveChanges();
            }
        }
        public static int IsNewCheckUserName(string userName)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result = from a in db.admin where a.username == userName select a;
                if (result.Count()>0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public static admin UpdateUser(int id)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                var result= db.admin.Find(id);
                return result;
            }
        }

        public static int CheckUpdateUser(int userId, string pwd)
        {
            using (MyBlogEntities db = new MyBlogEntities())
            {
                try
                {
                    var result = db.admin.Find(userId);
                    result.password = pwd;
                    db.SaveChanges();
                    return 1;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
        public static void CheckDeleteUser(int id)
        {
            using (MyBlogEntities db=new MyBlogEntities())
            {
                var result=db.admin.Find(id);
                db.admin.Remove(result);
                db.SaveChanges();
            }

        }
    }
}
