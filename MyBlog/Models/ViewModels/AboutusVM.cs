using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBlog.Models.ViewModels
{
    public class AboutusVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        [DataType(DataType.Html, ErrorMessage = "İçerik HTML formatında olmalıdır.")]
        public string Content { get; set; }
    }
}