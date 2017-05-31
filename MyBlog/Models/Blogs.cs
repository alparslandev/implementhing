using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Models
{
    public class Blogs
    {
        public Blogs()
        {
            Date = DateTime.Now.ToString();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık Girmek zorundasınız")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Başlık Girmek zorundasınız")]
        public string TitleEnglish { get; set; }

        [AllowHtml]
        [DataType(DataType.Html, ErrorMessage = "İçerik HTML formatında olmalıdır.")]
        [Required(ErrorMessage = "İçerik Girmek Zorundasınız.")]
        public string Content { get; set; }

        [AllowHtml]
        [DataType(DataType.Html, ErrorMessage = "İngilizce İçerik HTML formatında olmalıdır.")]
        [Required(ErrorMessage = "İngilizce İçerik Girmek Zorundasınız.")]
        public string ContentEnglish { get; set; }

        public string UserId { get; set; }

        public bool IsPublished { get; set; }

        public string Date { get; set; }
        public string Summary { get; set; }
        public string SummaryEnglish { get; set; }
    }
}