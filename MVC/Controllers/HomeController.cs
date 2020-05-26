using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.EF;
using BLL;
using PagedList;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int page=1)
        {
            int pagesize = 6;
            var result = ReceptionBLL.HomeIndex();
            return View(result.ToPagedList<article>(page,pagesize));
        }
        public PartialViewResult showCates()
        {
            var result = ReceptionBLL.GetCates();
            return PartialView(result);
        }
        public PartialViewResult showLastest()
        {
            var result = ReceptionBLL.ShowLastest();
            return PartialView(result);
        }
        public PartialViewResult showLinks()
        {
            var result = ReceptionBLL.ShowLinks();
            return PartialView(result);
        }
        public ActionResult CateToArticle(int id,int page=1)
        {
            int pagesize = 6;
            var result = ReceptionBLL.ArticlesOfCate(id);
            return View("Index", result.ToPagedList<article>(page,pagesize));
        }
    }
}