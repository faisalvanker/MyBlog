using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Blog.Web.Models
{
    public class ListBlogViewModels
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Snippet { get; set; }
        public int? ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string EditUrl { get; set; }
        public string ViewUrl { get; set; }
    }
  
}
