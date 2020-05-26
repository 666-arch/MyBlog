using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using Model.EF;

namespace BLL
{
    public class CategoryBLL
    {
        public static List<cate> Index(int page = 1)
        {
            return CategoryDAL.Index(page);
        }
        public static int IsCheckAddCate(cate cate)
        {
            return CategoryDAL.IsCheckAddCate(cate);
        }
        public static cate UpdateCate(int id) 
        {
            return CategoryDAL.UpdateCate(id);
        }
        public static int IsCheckUpdateCate(int cateId, string cateName)
        {
            return CategoryDAL.IsCheckUpdateCate(cateId, cateName);
        }
        public static void DeleteCate(int id) 
        {
            CategoryDAL.DeleteCate(id);
        }
        public static void SelectAllDelete(int idStr)
        {
            CategoryDAL.SelectAllDelete(idStr);
        }
    }
}
