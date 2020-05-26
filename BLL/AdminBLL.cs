using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.EF;

namespace BLL
{
    public class AdminBLL
    {
        public static List<admin> CheckLogin(string username, string password)
        {
            return AdminDAL.CheckLogin(username, password);
        }
        public static List<admin> PersonInfo(int page = 1)
        {
            return AdminDAL.PersonInfo(page);
        }
        public static int UserAdd(string userName, string pwd)
        {
            return AdminDAL.UserAdd(userName, pwd);
        }
        public static int IsNewCheckUserName(string userName)
        {
            return AdminDAL.IsNewCheckUserName(userName);
        }
        public static admin UpdateUser(int id)
        {
            return AdminDAL.UpdateUser(id);
        }
        public static int CheckUpdateUser(int userId,string pwd)
        {
            return AdminDAL.CheckUpdateUser(userId, pwd);
        }
        public static void CheckDeleteUser(int id)
        {
            AdminDAL.CheckDeleteUser(id);
        }
    }
}
