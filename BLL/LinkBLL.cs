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
    public class LinkBLL
    {
        public static List<link> Index()
        {
            return LinkDAL.Index();
        }
        public static int IsCheckLinkAdd(link link)
        {
            return LinkDAL.IsCheckLinkAdd(link);
        }
        public static link UpdateLinks(int id)
        {
            return LinkDAL.UpdateLinks(id);
        }
        public static int IsCheckUpdateLinks(int linkId, string title, string url, string desc)
        {
            return LinkDAL.IsCheckUpdateLinks(linkId, title, url, desc);
        }
        public static void DeleteLink(int id)
        {
            LinkDAL.DeleteLink(id);
        }
        public static void ManyDelete(int idStr)
        {
            LinkDAL.ManyDelete(idStr);
        }
    }
}
