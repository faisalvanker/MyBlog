using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using Blog.Data.Entity;

namespace Blog.Data.Repository
{
    public class ImageRespository 
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

        public virtual void Add(BlogDataModel entity)
        {
            AddOrUpdate(entity);
        }

        public void AddOrUpdate(BlogDataModel entity)
        {
            _context.Set<BlogDataModel>().AddOrUpdate(entity);

        }
    }
}
