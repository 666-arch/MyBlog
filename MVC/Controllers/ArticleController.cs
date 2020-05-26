using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using Model.EF;
using PagedList;

namespace MVC.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index(int page=1)
        {
            if (Session["username"]==null)
            {
                return RedirectToAction("Login", "Admin");
            }
            int pagesize = 6;
            if (Session["username"].ToString()=="admin")
            {
                var result= ArticleBLL.Index();
                return View(result.ToPagedList<article>(page,pagesize));
            }
            else
            {
                string username = Session["username"].ToString();
                var result = ArticleBLL.Index(username);
                return View(result.ToPagedList<article>(page,pagesize));
            }
        }
        public void ArticleDelete(int id)
        {
            ArticleBLL.ArticleDelete(id);
        }
        public void ArticleAllDelete(string idStr) 
        {
            string str = idStr.Substring(0, idStr.LastIndexOf(','));
            string[] idTemp = str.Split(',');
            foreach (var item in idTemp)
            {
                int ids = int.Parse(item);
                ArticleBLL.ArticleAllDelete(ids);
            }
        }
        public ActionResult AddArticle()
        {
            var result=ArticleBLL.SelectCateToAricle();
            ViewBag.author = Session["username"].ToString(); ;
            return View(result);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult IsCheckedAddArticle(string title,int catid,string author,string desc,string content)
        {
            article article = new article();
            article.title = title;
            article.cateid = catid;
            article.content = content;
            article.desc = desc;
            //article.creator = author;
            article.time = DateTime.Now;
            var result= ArticleBLL.IsCheckedAddArticle(article, author);
            if (result==1)
            {
                return Json(new { status = 1, data = "添加成功！" });
            }
            else
            {
                return Json(new { status = 0, data = "添加失败！" });
            }
        }
        public ActionResult UpdateArticle(int id)
        {
            article article = ArticleBLL.UpdateArticle(id);
            ViewBag.id = article.id;
            ViewBag.atitle = article.title;
            ViewBag.author = article.admin.username;
            ViewBag.cateName = article.cate.catname;
            ViewBag.content = article.content;
            ViewBag.desc = article.desc;
            ViewBag.aid = article.creator;
            var result = ArticleBLL.SelectCateToAricle();
            return View(result);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult IsCheckArticleUpdate(int creator,int id, string title, int catid, string desc, string content, string author )
        {
            article article = new article();
            article.id = id;
            article.title = title;
            article.cateid = catid;
            article.content = content;
            article.desc = desc;
            article.time = DateTime.Now;
            article.creator = creator;
            var result= ArticleBLL.IsCheckArticleUpdate(article);
            if (result==1)
            {
                return Json(new { status = 1, data = "修改成功！" });
            }
            else
            {
                return Json(new { status = 0, data = "修改失败！" });
            }
        }
        public ViewResult Detail(int id)
        {
            var result = ArticleBLL.Detail(id);
            ViewBag.atitle = result.title;
            ViewBag.author = result.admin.username;
            ViewBag.creatTime = result.time;
            ViewBag.cateName = result.cate.catname;
            ViewBag.content = result.content;
            return View();
        }
    }
}