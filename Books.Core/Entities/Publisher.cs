using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Entities
{
    public class Publisher : EntityObject
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name ="Anzahl Bücher")]
        public ICollection<Book> Books { get; set; }

        public Publisher()
        {
            Books = new List<Book>();
        }

    }
}
