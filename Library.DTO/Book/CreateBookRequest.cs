﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DTO.Book
{
    public class CreateBookRequest
    {
        public int AuthorId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
    }
}
