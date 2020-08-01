using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Data.Entity;

namespace Blog.Data.Contracts
{
    public interface IImageRespository
    {
        ImageDataModel GetById(int id);
        IEnumerable<ImageDataModel> Find(Expression<Func<ImageDataModel, bool>> predicate);
        void Add(ImageDataModel entity);
    }
}