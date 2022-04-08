using PIA.DotNet.Interview.Core.Database;
using PIA.DotNet.Interview.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PIA.DotNet.Interview.Core.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly IDbContext _dbContext;
        private readonly ICollection<T> _dataset;


        public GenericRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dataset = _dbContext.GetDataset<T>();
        }

        public ICollection<T> Get()
        {
            return _dataset;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _dataset.AsQueryable().Where(expression);
        }

        public T Get(Guid id)
        {
            return _dataset.FirstOrDefault(e => e.Id.Equals(id));
        }

        public bool Create(T model)
        {
            if (model == null)
                return false;

            model.Id = Guid.NewGuid();

            _dataset.Add(model);
            _dbContext.Save();
            return true;
        }

        public bool Update(Guid id, T model)
        {
            if (model == null || model.Id != id)
                return false;

            if (!_dataset.Remove(model))
                return false;

            _dataset.Add(model);
            _dbContext.Save();
            return true;
        }

        public bool Delete(Guid id, T model)
        {
            if (model == null || model.Id != id)
                return false;

            if (!_dataset.Remove(model))
                return false;

            _dbContext.Save();
            return true;
        }
    }
}
