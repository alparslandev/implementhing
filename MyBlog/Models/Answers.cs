using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Answers
    {
        public Answers()
        {
            Date = DateTime.Now.ToString();
        }

        [Key]
        public int ID { get; set; }

        public int QuestionID { get; set; }

        [Required(ErrorMessage = "Cevap boş bırakılamaz")]
        public string Answer { get; set; }

        public string UserID { get; set; }

        public string Date { get; set; }

    }
}