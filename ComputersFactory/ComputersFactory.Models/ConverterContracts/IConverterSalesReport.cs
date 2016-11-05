using System;
using System.Collections.Generic;

namespace ComputersFactory.Models.ConverterContracts
{
    public interface IConverterSalesReport
    {
        decimal TotalAmount { get; set; }

        DateTime Date { get; set; }

        int ComputerShopId { get; set; }

        ICollection<IConverterSale> Sales { get; set; }
    }
}
