using Books.Core.Contracts;
using Books.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Web.Models
{
    public class HomeDetailsViewModel
    {
        
        public SelectList publisherNames;

        [Display(Name = "Verlag ändern: ")]
        public int SelectedId { get; set; }

        public List<Book> Books;

        public void LoadModelData(IUnitOfWork uow, int publisherId)
        {
            if (publisherId != 0)
            {
                Books = uow.BookRepository.GetBooksByPublisher(publisherId).ToList();
            }
            else
            {
                Books = uow.BookRepository.GetAllBooks().ToList();
            }         
            List<Publisher> publishers = uow.PublisherRepository.GetAllPublishers();
            publishers = publishers.OrderBy(p => p.Name).ToList();
            publishers.Insert(0,new Publisher { Id = 0, Name = "< Alle anzeigen >" });
            publisherNames = new SelectList(publishers,nameof(Publisher.Id),nameof(Publisher.Name));
            foreach (var name in publisherNames)
            {
                if (name.Value == publisherId.ToString())
                {
                    SelectedId = publisherId;
                }
            }
        }
    }
}