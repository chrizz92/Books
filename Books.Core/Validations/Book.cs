using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Entities
{
    partial class Book
    {
        public static ValidationResult IsbnValidation(string isbn)
        {
            if (!Book.CheckIsbn(isbn))
            {
                return new ValidationResult("Ungültige ISBN-Nummer!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
