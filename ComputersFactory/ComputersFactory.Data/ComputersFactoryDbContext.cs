
﻿using System.Data.Entity;
using ComputersFactory.Models;
using ComputersFactory.Models.Components;
using ComputersFactory.Data.Models;

﻿using ComputersFactory.Data.Contracts;

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
