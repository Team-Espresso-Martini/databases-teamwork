using System;
using System.Collections.Generic;

using ComputersFactory.Data.Models;

namespace ComputersFactory.Models
{
    public class SalesReport
    {
        private ICollection<Computer> computers;

        public SalesReport()
        {
            this.computers = new HashSet<Computer>();
        }

        public int Id { get; set; }

        public decimal Sales { get; set; }

        public DateTime Date { get; set; }

        public int ComputerShopId { get; set; }

        public virtual ComputerShop ComputerShop { get; set; }

        public virtual ICollection<Computer> Computers
        {
            get
            {
                return this.computers;
            }

            set
            {
                this.computers = value;
            }
        }
    }
}
