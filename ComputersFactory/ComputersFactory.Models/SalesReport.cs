using System;
using System.Collections.Generic;

using ComputersFactory.Data.Models;

namespace ComputersFactory.Models
{
    public class SalesReport
    {
        private ICollection<Sale> sales;

        public SalesReport()
        {
            this.sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime Date { get; set; }

        public int ComputerShopId { get; set; }

        public virtual ComputerShop ComputerShop { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get
            {
                return this.sales;
            }

            set
            {
                this.sales = value;
            }
        }
    }
}
