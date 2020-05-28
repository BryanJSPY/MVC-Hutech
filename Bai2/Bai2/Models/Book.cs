using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bai2.Models
{
    public class Book
    {
        public Book()
        {

        }

        public Book(int id, string title, string author, string imageCover)
        {
            Id = id;
            Title = title;
            Author = author;
            ImageCover = imageCover;
        }
        [Display(Name = "Ma Sach")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tieu de khong duoc trong")]
        [StringLength(250,ErrorMessage ="Tieu de khong vuot qua 250 ki tu")]
        [Display(Name ="Tieu De")]
        public string Title { get; set; }
        [Display(Name = "Tac Gia")]
        public string Author { get; set; }
        [Display(Name = "Duong Dan Anh")]
        public string ImageCover { get; set; }
    }

}