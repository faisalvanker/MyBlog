using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;

namespace Blog.Data.Repository
{
    public class BlogRespository
    {
        private readonly BlogContext _context;

        public BlogRespository(BlogContext context)
        {
            _context = context;
        }

        public Entity.BlogDataModel GetById(Guid id)
        {
            var result = _context.Blog.Find(id);

            if (result == null) throw new Exception($"No Record Found for Id{id}");

            return result;
        }

        public IEnumerable<Entity.BlogDataModel> Find(Expression<Func<Entity.BlogDataModel, bool>> predicate)
        {
            return _context.Blog.Where(predicate).ToList();
        }

        public IEnumerable<Entity.BlogDataModel> Page(int pageNumber, int pageSize)
        {
            var skipNumber = (pageNumber - 1) * pageSize;
            return _context.Blog.Where(x => x.Active).OrderByDescending(x => x.LastUpdate).Skip(skipNumber).Take(pageSize);
        }

        public void Add(Entity.BlogDataModel entity)
        {
            AddOrUpdate(entity);
        }

        private void AddOrUpdate(Entity.BlogDataModel entity)
        {
            _context.Blog.AddOrUpdate(entity);
        }

        public void RemoveById(Guid Id)
        {
            var entity = GetById(Id);

            var dbSet = _context.Set<Entity.BlogDataModel>();

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

    }
}
