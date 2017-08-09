using System;

namespace Entities.Models
{
    public class Review : IdEntity
    {
        public string Authorname { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}