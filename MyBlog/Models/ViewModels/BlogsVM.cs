using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBlog.Models.ViewModels
{
    public class BlogsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [AllowHtml]
        [DataType(DataType.Html, ErrorMessage = "İçerik HTML formatında olmalıdır.")]
        public string Content { get; set; }
        public string Summary { get; set; }
        public bool IsPublished { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
    }
}