<<<<<<< HEAD
﻿using System.Data.Entity;
using ComputersFactory.Models;
using ComputersFactory.Models.Components;
using ComputersFactory.Data.Models;
=======
﻿using ComputersFactory.Data.Contracts;
>>>>>>> 17418bae6717a3272d3c082a8dbb85bbafcbb37b

namespace ComputersFactory.Data
{
    public class ComputersFactoryDbContext : AbstractComputersFactoryDbContext
    {
        public ComputersFactoryDbContext()
            : base("ComputersFactoryConnection")
        {
        }
    }
}
