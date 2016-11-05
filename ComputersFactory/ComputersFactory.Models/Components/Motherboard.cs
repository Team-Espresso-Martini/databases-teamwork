using ComputersFactory.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputersFactory.Models.Components
{
    public class Motherboard
    {
        private ICollection<Computer> computers;

        public Motherboard()
        {
            this.computers = new HashSet<Computer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(50)]
        public string Manufacturer { get; set; }

        public virtual ICollection<Computer> Computers
        {
            get { return this.computers; }
            set { this.computers = value; }
        }
    }
}
