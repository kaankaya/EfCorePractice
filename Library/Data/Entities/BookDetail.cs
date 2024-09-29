﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class BookDetail
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }

        public int BookId { get; set; } //foreign
        //[ForeignKey(nameof(BookId))]
        public Book Book { get; set; } //navigation foregin
    }
}
