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
    public class CateController : Controller
    {
        // GET: Cate
        public ActionResult Index(int page=1)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("/Admin/Login");
            }
            int pagesize = 6;
            var result= CategoryBLL.Index(page);
            return View(result.ToPagedList<cate>(page,pagesize));
        }
        public ActionResult AddCate()
        {
            return View();
        }

        public JsonResult IsCheckAddCate(string cateName)
        {
            cate cate = new cate();
            cate.catname = cateName;
            var result = CategoryBLL.IsCheckAddCate(cate);
            if (result==1)
            {
                return Json(new { status = 1, data = "新增成功！" });
            }
            else
            {
                return Json(new { status = 0, data = "新增失败！" });
            }
        }
        public ActionResult UpdateCate(int id)
        {
            var result= CategoryBLL.UpdateCate(id);
            ViewBag.cid = result.id;
            ViewBag.cname = result.catname;
            return View();
        }
        public JsonResult IsCheckUpdateCate(int cateId, string cateName)
        {
            var result = CategoryBLL.IsCheckUpdateCate(cateId, cateName);
            if (result==1)
            {
                return Json(new { status = 1, data = "修改成功！" });
            }
            else
            {
                return Json(new { status = 0, data = "修改失败！" });
            }
        }
        //单个删除
        public void DeleteCate(int id)
        {
            CategoryBLL.DeleteCate(id);
        }
        //批量删除
        public void SelectAllDelete(string idStr)
        {
            string str = idStr.Substring(0, idStr.LastIndexOf(","));
            string[] idArry = str.Split(',');
            foreach (var item in idArry)
            {
                int s = int.Parse(item);
                CategoryBLL.SelectAllDelete(s);
            }
        }
    }
}