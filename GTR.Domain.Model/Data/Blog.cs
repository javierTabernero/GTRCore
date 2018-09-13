using System;
using System.Collections.Generic;
using System.Text;

namespace GTR.Domain.Model.Data
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public IEnumerable<Post> Post { get; set; }
    }
}
