using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Blog.Web.Models
{
    public class BlogDetailsViewModels
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        [DataType(DataType.Html)]
        public string Post { get; set; }

        public int? ImageId { get; set; }
        public string ImageUrl { get { return string.Format("/Blog/GetImage?ImageId={0}", ImageId); } }

        public List<string> Tags { get; set; }

        public string Author { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}")]
        public DateTime LastUpdate { get; set; }
        public bool Active { get; set; }
    }

}
