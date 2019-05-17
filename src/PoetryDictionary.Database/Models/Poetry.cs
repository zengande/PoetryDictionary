using System;
using System.Collections.Generic;
using System.Text;

namespace PoetryDictionary.Database.Models
{
    public class Poetry
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Dynasty { get; set; }
        public string AuthorName { get; set; }
        public string Rhythm { get; set; }
        public long? AuthorId { get; set; }
    }
}
