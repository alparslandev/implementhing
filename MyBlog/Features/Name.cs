using System;
using System.Linq;
using System.Web;
using MyBlog.Models;
using Microsoft.Ajax.Utilities;

namespace MyBlog.Controllers
{
    public class Name
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static string getName(string userid)
        {
            string userName = "";
            if (!String.IsNullOrWhiteSpace(userid))
            {
                var tempUserName = db.Users.Where(e => e.Id == userid).Select(e => e.UserName).FirstOrDefault();
                if (!tempUserName.IsNullOrWhiteSpace())
                {
                    // Siteye yeni birisi yazı yazmak isterse burada gerekli değişiklikler yapılacak.
                    // userName = "Alparslan Selçuk DEVELİOĞLU";
                }
            }
            userName = "Alparslan Selçuk DEVELİOĞLU";
            return userName;
        }

        public static bool IsEnglish()
        {
            return (string) HttpContext.Current.Session["Lang"] == "English";
        }
    }
}