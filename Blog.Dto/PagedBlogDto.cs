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
        public string ImageUrl => $"/Blog/GetImage?ImageId={ImageId}";
        public string EditUrl => $"/Blog/Edit/{Id}";
        public string ViewUrl => $"/Blog/Details/{Id}";
    }
}

