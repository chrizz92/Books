using Books.Core.Contracts;
using Books.Core.Entities;
using Books.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public BookController(ILogger<BookController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Create(int publisherId)
        {
            BookCreateViewModel model = new BookCreateViewModel();
            model.LoadModelData(_unitOfWork,publisherId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(BookCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookRepository.SaveNewBook(model.Book);
                try
                {
                    _unitOfWork.Save();
                    return RedirectToAction("Details", "Home", new { publisherId = model.Book.Publisher_Id });
                }
                catch(ValidationException ValidationException)
                {
                    ModelState.AddModelError($"{nameof(Book)}.{nameof(Book.Title)}", ValidationException.ValidationResult.ErrorMessage);
                }          
            }       
            model.LoadModelData(_unitOfWork,model.Book.Publisher_Id);
            return View(model);            
        }
        public IActionResult Delete(int bookId)
        {
            int publisher = _unitOfWork.BookRepository.GetAllBooks().Where(b=>b.Id==bookId).First().Publisher_Id;
            _unitOfWork.BookRepository.DeleteBook(bookId);
            return RedirectToAction("Details","Home",new {publisherId = publisher});
        }
    }
}
