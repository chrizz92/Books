using Books.Core.Contracts;
using Books.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Web.Models
{
    public class BookCreateViewModel
    {
        public Book Book { get; set; }
        public SelectList Publishers { get; set; }
        public void LoadModelData(IUnitOfWork uow, int publisherId)
        {
            Book = new Book();
            Book.Publisher_Id = publisherId;
            Publishers = new SelectList(uow.PublisherRepository.GetAllPublishers(),nameof(Publisher.Id),nameof(Publisher.Name));
        }
    }
}
