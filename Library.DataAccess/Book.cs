using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.DataAccess
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Author")]
        public virtual int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        [ForeignKey("Type")]
        public virtual int TypeId { get; set; }
        public virtual Type Type { get; set; }
    }
}
