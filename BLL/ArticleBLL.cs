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
    public class ArticleBLL
    {
        public static List<article> Index()
        {
            return ArticleDAL.Index();
        }
        public static List<article> Index(string username)
        {
            return ArticleDAL.Index(username);
        }
        public static void ArticleDelete(int id)
        {
            ArticleDAL.ArticleDelete(id);
        }
        public static void ArticleAllDelete(int ids)
        {
            ArticleDAL.ArticleAllDelete(ids);
        }
        public static List<cate> SelectCateToAricle()
        {
            return ArticleDAL.SelectCateToAricle();
        }
        public static int IsCheckedAddArticle(article article, string author)
        {
            return ArticleDAL.IsCheckedAddArticle(article, author);
        }
        public static article UpdateArticle(int id)
        {
            return ArticleDAL.UpdateArticle(id);
        }
        public static int IsCheckArticleUpdate(article article)
        {
            return ArticleDAL.IsCheckArticleUpdate(article);
        }
        public static article Detail(int id)
        {
            return ArticleDAL.Detail(id);
        }
    }
}
