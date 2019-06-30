using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Business;
using Blog.Web.Models;

namespace Blog.Web.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            var manager = new BlogManager();
            var blog = manager.LoadBlog(id);

            return View(
                new BlogDetailsViewModels
                {
                    Title = blog.Title,
                    Post = blog.Post,
                    ImageId = blog.ImageId,
                    Tags = blog.Tags == null ? new List<string> { } : blog.Tags.Split(',').ToList(),
                    Author=blog.Author,
                    LastUpdate = blog.LastUpdate,
                    Active = blog.Active,

                }
            ); ;

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateBlogViewModels model)
        {

            if (!ModelState.IsValid || !IsFileValid(model.BlogImage)) return View();

            var manager = new BlogManager();
            var uploadedFile = GetFile(model.BlogImage);
            manager.CreateBlogPost(model.Title, model.Post, model.BlogImage.FileName, uploadedFile, model.Tags, HttpContext.User.Identity.Name);

            return RedirectToAction("Index");

        }

        public ActionResult Edit(Guid id)
        {
            var manager = new BlogManager();
            var blog = manager.LoadBlog(id);

            return View(
                new EditBlogViewModels
                {
                    Title = blog.Title,
                    Post = blog.Post,
                    ImageId = blog.ImageId,
                    Tags = blog.Tags,
                    Active = blog.Active,

                }
            );
        }


        [HttpPost]
        public ActionResult Edit(EditBlogViewModels model)
        {
            if (!ModelState.IsValid || (model.BlogImage != null && !IsFileValid(model.BlogImage))) return View();

            var manager = new BlogManager();

            manager.UpdateBlogPost(new Blog.Dto.EditBlogDto
            {
                Id = model.Id,
                Title = model.Title,
                Post = model.Post,
                Tags = model.Tags,
                Filename = model.BlogImage?.FileName,
                Image = model.BlogImage != null ? GetFile(model.BlogImage) : null,
                Author = HttpContext.User.Identity.Name,
                Active = model.Active,
            });

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Loads blog posts on the home page using paging. The page size is determined in the webconfig
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPagedResult(int page)
        {
            var manager = new BlogManager();
            return Json(manager.LoadBlogPosts(page, BlogConfig.DefaultPageSize), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetImage(int imageId)
        {
            var manager = new BlogManager();
            var image = manager.GetImageForBlogPost(imageId);

            string contentType = MimeMapping.GetMimeMapping(image.Filename);
            return new FileContentResult(image.Data, contentType);

        }


        #region Private Methods

        private bool IsFileValid(HttpPostedFileBase BlogImage)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (BlogImage == null || BlogImage?.ContentLength == 0)
            {
                ModelState.AddModelError("BlogImage", "No file was uploaded. Please choose either a GIF, JPG or PNG image.");
                return false;
            }

            if (!validImageTypes.Contains(BlogImage.ContentType))
            {
                ModelState.AddModelError("BlogImage", "Only GIF, JPG or PNG images are allowed");
                return false;
            }

            return true;

        }

        private byte[] GetFile(HttpPostedFileBase BlogImage)
        {
            using (var ms = new MemoryStream())
            {
                BlogImage.InputStream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        #endregion
    }
}
