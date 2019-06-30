using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entity
{
    [Table("Blog")]
    public class BlogDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Post { get; set; }
        public int? ImageId { get; set; }
        public string Tags { get; set; }
        public string Author { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Active { get; set; }

        public virtual ImageDataModel Image { get; set; }
    }
}
