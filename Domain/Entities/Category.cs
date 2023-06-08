﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category: Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
