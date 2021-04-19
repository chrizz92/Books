using System;
using System.Collections.Generic;
using System.Text;
using Books.Core.Entities;

namespace Books.Core.Contracts
{
    public interface IPublisherRepository
    {
        int Count();
        List<Publisher> GetAllPublishers();
    }
}
