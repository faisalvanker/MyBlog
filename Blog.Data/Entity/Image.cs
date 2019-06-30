using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entity
{
    [Table("Image")]
    public class ImageDataModel
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public byte[] Data { get; set; }
    }
}
