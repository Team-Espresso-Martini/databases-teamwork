using System;
using System.Collections.Generic;
using System.Data.Entity;

using ComputersFactory.Data.Repositories.Repositories.Contracts;
using ComputersFactory.Models;

namespace ComputersFactory.Data.Repositories.Repositories
{
    public class ComputersRepository : IComputersRepository
    {
        public ComputersRepository(DbContext context)
        {

        }

        public void Add(Computer entity)
        {
            throw new NotImplementedException();
        }

        public Computer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Computer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Computer entity)
        {
            throw new NotImplementedException();
        }
    }
}
