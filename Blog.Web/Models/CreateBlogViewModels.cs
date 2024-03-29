﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Models
{
    public class CreateBlogViewModels
    {
        [Required]

        [Display(Name = "Title of Blog")]
        [StringLength(100, ErrorMessage = "{0} must be at between {2} and {1} characters long", MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Html)]
        [AllowHtml]
        [Display(Name = "Content")]
        public string Post { get; set; }

        [Display(Name = "Picture")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase BlogImage { get; set; }

        [Display(Name = "Tags")]
        [StringLength(200, ErrorMessage = "{0} must be at less than {1} characters long")]
        public string Tags { get; set; }
    }
  
}
