using Books.Core.Contracts;
using Books.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Web.Models
{
    public class HomeIndexViewModel
    {
        public List<Publisher> Publishers { get; set; }

        public int FilterFrom { get; set; }

        public int FilterTo { get; set; }

        public Publisher PublisherWithMostBook
        {
            get
            {
                Publisher publisherToReturn = null;
                foreach (var publisher in Publishers)
                {
                    if (publisherToReturn == null)
                    {
                        publisherToReturn = publisher;
                    }
                    else
                    {
                        if (publisher.Books.Count>publisherToReturn.Books.Count())
                        {
                            publisherToReturn = publisher;
                        }
                    }
                }
                return publisherToReturn;
            }
        }

        public void LoadModelData(IUnitOfWork uow)
        {
            Publishers = uow.PublisherRepository.GetAllPublishers();
            foreach (var publisher in Publishers)
            {
                publisher.Books = uow.BookRepository.GetBooksByPublisher(publisher.Id);
            }
        }

        public void LoadFilteredModelData(IUnitOfWork uow, string from, string to)
        {
            FilterFrom = Convert.ToInt32(from);
            FilterTo = Convert.ToInt32(to);
            Publishers = uow.PublisherRepository.GetAllPublishers();
            foreach (var publisher in Publishers)
            {
                publisher.Books = uow.BookRepository.GetBooksByPublisher(publisher.Id);
            }
            if (from != null && to != null)
            {
                Publishers.RemoveAll(p => p.Books.Count() < FilterFrom || p.Books.Count() > FilterTo);
            }
            else if (from != null)
            {
                Publishers.RemoveAll(p => p.Books.Count() < FilterFrom);
            }
            else if(to != null)
            {
                Publishers.RemoveAll(p => p.Books.Count() > FilterTo);
            }
            
        }
    }
}
