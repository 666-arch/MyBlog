using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using PagedList;
using Model.EF;

namespace MVC.Controllers
{
    public class LinkController : Controller
    {
        // GET: Link
        public ActionResult Index(int page=1)
        {
            int pagesize = 5;
            if (Session["username"]==null)
            {
                Response.Redirect("/Admin/Login");
            }
            var result = LinkBLL.Index();
            return View(result.ToPagedList<link>(page,pagesize));
        }
        public ActionResult AddLink()
        {
            return View();
        }
        public JsonResult IsCheckLinkAdd(string title,string url, string desc)
        {
            link link = new link();
            link.title = title;
            link.url = url;
            link.desc = desc;
            var result= LinkBLL.IsCheckLinkAdd(link);
            if (result==0)
            {
                return Json(new { status = 0, data = "链接已存在，请重新添加！" });
            }
            else
            {
                return Json(new { status = 1, data = "添加成功！" });
            }
        }
        public ActionResult UpdateLinks(int id)
        {
            link link= LinkBLL.UpdateLinks(id);
            ViewBag.lid = link.id;
            ViewBag.tit = link.title;
            ViewBag.url = link.url;
            ViewBag.des = link.desc;
            return View();
        }
        public JsonResult IsCheckUpdateLinks(int linkId,string title, string url, string desc)
        {
            var result= LinkBLL.IsCheckUpdateLinks(linkId, title, url, desc);
            if (result==0)
            {
                return Json(new { status = 0, data = "该友情链接已存在,请重新输入！" });
            }
            else
            {
                return Json(new { status = 1, data = "修改成功！" });
            }
        }
        public void DeleteLink(int id)
        {
            LinkBLL.DeleteLink(id);
        }
        public void ManyDelete(string idStr)
        {
            string str = idStr.Substring(0, idStr.LastIndexOf(','));
            string[] idTemp = str.Split(',');
            foreach (var item in idTemp)
            {
                int daa = int.Parse(item);
                LinkBLL.ManyDelete(daa);
            }
        }
    }
}