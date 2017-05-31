using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBlog.Models
{
    public class Aboutus
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string TitleEnglish { get; set; }

        [AllowHtml]
        [DataType(DataType.Html, ErrorMessage = "İçerik HTML formatında olmalıdır.")]
        public string Content { get; set; }

        [AllowHtml]
        [DataType(DataType.Html, ErrorMessage = "İngilizce İçerik HTML formatında olmalıdır.")]
        public string EnglishContent { get; set; }
    }
}