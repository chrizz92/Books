using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Books.Core.Contracts;
using Books.Core.Entities;

namespace Books.Persistence
{
    internal class PublisherRepository : IPublisherRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PublisherRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Count()
        {
            return _dbContext.Publishers.Count();
        }

        public List<Publisher> GetAllPublishers()
        {
            return _dbContext.Publishers.OrderBy(p => p.Name).ToList();
        }
    }
}