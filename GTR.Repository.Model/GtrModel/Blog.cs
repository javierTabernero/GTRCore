using System.Collections.Generic;

namespace GTR.Repository.Model
{
    public partial class Blog
    {
        public Blog()
        {
            Post = new HashSet<Post>();
        }

        public int BlogId { get; set; }

        //[Display(Name = nameof(Resources.Resources.Resources.BlogUrl))]
        public string Url { get; set; }

        public ICollection<Post> Post { get; set; }
    }
}
