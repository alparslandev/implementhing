
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Questions
    {
        public Questions()
        {
            Date = DateTime.Now.ToString();
        }

        [Key]
        public int ID { get; set; }

        [DisplayName("Soru Başlığınız")]
        [Required(ErrorMessage = "Soru başlığı yazmadan soru kayıt işlemi tamamlanamaz")]
        public string Title { get; set; }

        [DisplayName("Sorunuz")]
        [StringLength(500, MinimumLength = 7, ErrorMessage = "Sorunuz 7-500 karakter olabilir")]
        [Required(ErrorMessage = "Sorunuzu yazmadan soru kayıt işlemi tamamlanamaz")]
        public string Question { get; set; }

        [DisplayName("Adınız")]
        [Required(ErrorMessage = "Adınızı yazmanız gerekmektedir")]
        public string Name { get; set; }

        [DisplayName("Soyadınız (Site yöneticisinden başkası görmeyecektir.)")]
        [Required(ErrorMessage = "Soyadınızı yazmanız gerekmektedir")]
        public string Surname { get; set; }

        [DisplayName("E-mail Adresiniz (Zorunlu Değildir)")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Bu bir E-Mail adresi değildir")]
        public string EMail { get; set; }

        public bool IsConfirmed { get; set; }
        public string Date { get; set; }
    }
}