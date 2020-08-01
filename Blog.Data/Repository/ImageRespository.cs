using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using Blog.Data.Contracts;
using Blog.Data.Entity;

namespace Blog.Data.Repository
{
    public class ImageRespository : IImageRespository
    {
        private readonly BlogContext _context;

        public ImageRespository(BlogContext context)
        {
            _context = context;
        }

        public ImageDataModel GetById(int id)
        {
            var result = _context.Image.Find(id);

            if (result == null) throw new Exception($"No Record Found for Id {id}");

            return result;
        }

        public IEnumerable<ImageDataModel> Find(Expression<Func<ImageDataModel, bool>> predicate)
        {
            return _context.Set<ImageDataModel>().Where(predicate).ToList();
        }

        public void Add(ImageDataModel entity)
        {
            AddOrUpdate(entity);
        }

        private void AddOrUpdate(ImageDataModel entity)
        {
            _context.Set<ImageDataModel>().AddOrUpdate(entity);
        }
    }
}
