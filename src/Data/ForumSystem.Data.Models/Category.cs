﻿namespace ForumSystem.Data.Models
{
    using System.Collections.Generic;

    using ForumSystem.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
