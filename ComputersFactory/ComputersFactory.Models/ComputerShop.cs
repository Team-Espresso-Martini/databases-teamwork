using ComputersFactory.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputersFactory.Models
{
    public class ComputerShop
    {
        private ICollection<Computer> computers;

        public ComputerShop()
        {
            this.computers = new HashSet<Computer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Computer> Computers
        {
            get { return this.computers; }
            set { this.computers = value; }
        }
    }
}
