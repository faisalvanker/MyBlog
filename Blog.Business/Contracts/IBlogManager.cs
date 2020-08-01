using Blog.Dto;
using System;
using System.Collections.Generic;

namespace Blog.Business.Contracts
{
    public interface IBlogManager
    {
        void CreateBlogPost(string title, string post, string filename, byte[] image, string tag, string user);
        BlogImageDto GetImageForBlogPost(int imageId);
        EditBlogDto LoadBlogById(Guid Id);
        List<PagedBlogDto> LoadFrontPageBlogPosts();
        List<PagedBlogDto> LoadBlogPosts(int page, int size);
        void UpdateBlogPost(EditBlogDto dto);
    }
}