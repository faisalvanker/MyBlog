using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Data.Contracts
{
    public interface IBlogRespository
    {
        Entity.BlogDataModel GetById(Guid id);
        IEnumerable<Entity.BlogDataModel> Find(Expression<Func<Entity.BlogDataModel, bool>> predicate);
        IEnumerable<Entity.BlogDataModel> Page(int pageNumber, int pageSize);
        void Add(Entity.BlogDataModel entity);
        void RemoveById(Guid id);
    }
}