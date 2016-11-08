using ComputersFactory.Data.Models;

namespace ComputersFactory.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int ComputerId { get; set; }

        public virtual Computer Computer { get; set; }
    }
}
