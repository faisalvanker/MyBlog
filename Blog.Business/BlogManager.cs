using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Data.Entity;
using Blog.Data.Repository;
using Blog.Dto;

namespace Blog.Business
{
    public class BlogManager
    {
        /// <summary>
        /// Creates an active Blog Post together with an image. Defaults to the current date
        /// </summary>
        /// <param name="title"></param>
        /// <param name="post"></param>
        /// <param name="filename"></param>
        /// <param name="image"></param>
        /// <param name="tag"></param>
        /// <param name="user"></param>
        public void CreateBlogPost(string title, string post, string filename, byte[] image, string tag, string user)
        {
            using (var context = new BlogContext())
            {
                var repo = new BlogRespository(context);

                repo.Add(new BlogDataModel
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Post = post,
                    Tags = tag,
                    Image = new ImageDataModel
                    {
                        Filename = filename,
                        Data = image,
                    },

                    Active = true,
                    LastUpdate = DateTime.Now,
                    Author = user,
                });

                context.Commit();
            }
        }

        /// <summary>
        /// Loads blog post on demand. Based on custom paging. Snippet displays the first 50 charactors from the post
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        public List<PagedBlogDto> LoadBlogPosts(int page, int size)
        {
            using (var context = new BlogContext())
            {
                var repo = new BlogRespository(context);
                var blog = repo.Page(page, size).ToList();
                return blog.Select(item => new PagedBlogDto { Id = item.Id, Title = item.Title, Snippet = item.Post.Substring(10), ImageId = item.ImageId }).ToList();
            }
        }

        public EditBlogDto LoadBlog(Guid Id)
        {
            using (var context = new BlogContext())
            {
                var repo = new BlogRespository(context);
                var blog = repo.GetById(Id);
                return new EditBlogDto
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Post = blog.Post,
                    ImageId = blog.ImageId,
                    Tags = blog.Tags,
                    Active = blog.Active,
                    Author = blog.Author,
                    LastUpdate=blog.LastUpdate
                    
                };
            }
        }
        /// <summary>
        /// Gets an Image from the DB. Send back the filename and binary data
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public BlogImageDto GetImageForBlogPost(int imageId)
        {
            using (var context = new BlogContext())
            {
                var repo = new ImageRespository(context);
                var result = repo.GetById(imageId);

                return new BlogImageDto
                {
                    Filename = result.Filename,
                    Data = result.Data
                };

            }
        }

        /// <summary>
        /// Updates a blog post. When no image is uploaded, the existing image is retained.
        /// The active active status indicates whether a blog post is deleted.
        /// </summary>
        /// <param name="dto"></param>
        public void UpdateBlogPost(EditBlogDto dto)
        {
            using (var context = new BlogContext())
            {
                var repo = new BlogRespository(context);
                var blog = repo.GetById(dto.Id);

                blog.Title = dto.Title;
                blog.Post = dto.Post;

                if (dto.Image != null)
                {
                    blog.Image.Filename = dto.Filename;
                    blog.Image.Data = dto.Image;
                }

                blog.Tags = dto.Tags;
                blog.Author = dto.Author;
                blog.Active = dto.Active;
                blog.LastUpdate = DateTime.Now;

                context.Commit();
            }
        }
    }
}
