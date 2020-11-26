using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DTO.Book
{
    public class ListBookResponse
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
