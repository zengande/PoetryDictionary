using System;
using System.Collections.Generic;
using System.Text;

namespace PoetryDictionary.Database.Models
{
    public class Excerpt
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
        public long? SourceId { get; set; }
    }
}
