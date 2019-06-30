using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dto
{
    public class PagedBlogDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Snippet { get; set; }
        public int? ImageId { get; set; }
        public string ImageUrl { get { return string.Format("/Blog/GetImage?ImageId={0}", ImageId); } }
        public string EditUrl { get { return string.Format("/Blog/Edit/{0}", Id); } }
        public string ViewUrl { get { return string.Format("/Blog/Details/{0}", Id); } }
    }
}

