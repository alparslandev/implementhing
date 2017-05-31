using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyBlog.Models.ViewModels
{
    public class QuestionsVM
    {
        public int QuestionID { get; set; }

        [DisplayName("Başlık")]
        public string Title { get; set; }

        [DisplayName("Soru")]
        public string Summary { get; set; }

        [DisplayName("İsim")]
        public string Name { get; set; }

        [DisplayName("Soyisim")]
        public string Surname { get; set; }

        public string Date { get; set; }
    }
}