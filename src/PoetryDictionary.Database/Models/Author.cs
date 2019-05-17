using System;
using System.Collections.Generic;
using System.Text;

namespace PoetryDictionary.Database.Models
{
    public class Author
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Dynasty { get; set; }
    }
}
