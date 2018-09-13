using System;
using System.Collections.Generic;
using System.Text;

namespace GTR.Domain.Model.Data
{
    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public Blog Blog { get; set; }
    }
}
