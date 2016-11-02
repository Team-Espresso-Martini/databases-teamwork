using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ComputersFactory.Models.Components;
using ComputersFactory.Models;

namespace ComputersFactory.Data.Models
{
    public class Computer
    {
        private ICollection<HardDrive> hardDrives;

        public Computer()
        {
            this.hardDrives = new HashSet<HardDrive>();
        }

        public int Id
        {
            get; set;
        }

        [Required]
        [MaxLength(50)]
        public string Model
        {
            get; set;
        }

        [Required]
        public Decimal Price
        {
            get; set;
        }

        public int MemoryId
        {
            get; set;
        }

        public virtual Memory Memory
        {
            get; set;
        }

        public int MotherboardId
        {
            get; set;
        }

        public virtual Motherboard Motherboard
        {
            get; set;
        }

        public int ProcessorId
        {
            get; set;
        }

        public virtual Processor Processor
        {
            get; set;
        }

        public int VideocardId
        {
            get; set;
        }

        public virtual VideoCard Videocard
        {
            get; set;
        }

        public virtual ICollection<HardDrive> HardDrives
        {
            get
            {
                return this.hardDrives;
            }
            set
            {
                this.hardDrives = value;
            }
        }

        public int ComputerShopId
        {
            get; set;
        }

        public virtual ComputerShop ComputerShop
        {
            get; set;
        }
    }
}