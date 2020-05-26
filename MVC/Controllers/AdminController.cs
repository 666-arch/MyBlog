using BLL;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(int page=1)
        {
            int pagesize = 6;
            if (Session["username"]==null)
            {
                Response.Redirect("Login");
            }
            ViewBag.user = Session["username"];
            var result= AdminBLL.PersonInfo(page);
            return View(result.ToPagedList<admin>(page, pagesize));
        }
        public ActionResult Login()
        {
            if (Session["username"]!=null)
            {
                Response.Redirect("Info");
            }
            return View();
        }
        public JsonResult CheckLogin(string username,string password)
        {
            var result= AdminBLL.CheckLogin(username, password);
            if (result.Count>0)
            {
                Session["username"] = username;
                return Json(new { status = 1, data = "登录成功" });
            }
            return Json(new { status = 0, data = "登录失败" });
        }
        public ActionResult Info()
        {
            ViewBag.serverName = "http://" + Request.Url.Host;
            ViewBag.serverIP = Request.ServerVariables.Get("Local_Addr").ToString();
            ViewBag.serverIIS = Request.ServerVariables["SERVER_SOFTWARE"].ToString();
            ViewBag.serverDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewBag.serverDoname = Request.ServerVariables["SERVER_NAME"].ToString();
            ViewBag.NETVersion = Environment.Version.Major;
            ViewBag.System = Environment.OSVersion.ToString();
            return View();
        }
        public ActionResult UserAdd()
        {
            return View();
        }
        public JsonResult CheckAddUser(string userName,string pwd,string pwds)
        {
            var result= AdminBLL.IsNewCheckUserName(userName);
            if (result >0)
            {
                return Json(new { status = 0, data = "该用户名已存在，清重新设置" });
            }
            else
            {
                AdminBLL.UserAdd(userName, pwd);
                return Json(new { status = 1, data = "添加成功" });
            }
        }
        public ActionResult UpdateUser(int id)
        {
            admin us = AdminBLL.UpdateUser(id);
            ViewBag.id = us.id;
            ViewBag.name= us.username;
            return View();
        }
        public JsonResult CheckUpdateUser(int userId,string userName,string pwd,string pwds)
        {
            int result= AdminBLL.CheckUpdateUser(userId, pwd);
            if (result==1)
            {
                return Json(new { status = 1, data = "修改成功" });
            }
            else
            {
                return Json(new { status = 0, data = "修改失败" });
            }
        }
        public void CheckDeleteUser(int id)
        {
            AdminBLL.CheckDeleteUser(id);
        }
    }
}