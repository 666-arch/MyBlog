using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Model.EF;

namespace BLL
{
    public class ReceptionBLL
    {
        public static List<article> HomeIndex()
        {
            return ReceptionDAL.HomeIndex();
        }
        public static List<cate> GetCates()
        {
            return ReceptionDAL.GetCates();
        }
        public static List<article> ShowLastest()
        {
            return ReceptionDAL.ShowLastest();
        }
        public static List<link> ShowLinks()
        {
            return ReceptionDAL.ShowLinks();
        }
        public static List<article> ArticlesOfCate(int id)
        {
            return ReceptionDAL.ArticlesOfCate(id);
        }
    }
}
