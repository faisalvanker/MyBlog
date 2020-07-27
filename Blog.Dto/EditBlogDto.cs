using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dto
{
    public class EditBlogDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Post { get; set; }
        public string Filename { get; set; }
        public byte[] Image { get; set; }
        public int? ImageId { get; set; }
        public string Tags { get; set; }
        public string Author { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Active { get; set; }
    }
}
