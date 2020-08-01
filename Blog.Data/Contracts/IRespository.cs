using Blog.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Data.Contracts
{
    public interface IRespository
    {
        void Add(BlogDataModel entity);
        IEnumerable<BlogDataModel> Find(Expression<Func<BlogDataModel, bool>> predicate);
        BlogDataModel GetById(Guid id);
        IEnumerable<BlogDataModel> Page(int pageNumber, int pageSize);
        void RemoveById(Guid Id);
    }
}