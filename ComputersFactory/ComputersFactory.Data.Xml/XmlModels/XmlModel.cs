using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersFactory.Data.Xml.XmlModels
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ComputerShop
    {

        private ComputerShopComputer computerField;

        /// <remarks/>
        public ComputerShopComputer Computer
        {
            get
            {
                return this.computerField;
            }
            set
            {
                this.computerField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ComputerShopComputer
    {

        private decimal computerPriceField;

        private ComputerShopComputerComponents componentsField;

        private byte comuterIDField;

        /// <remarks/>
        public decimal ComputerPrice
        {
            get
            {
                return this.computerPriceField;
            }
            set
            {
                this.computerPriceField = value;
            }
        }

        /// <remarks/>
        public ComputerShopComputerComponents Components
        {
            get
            {
                return this.componentsField;
            }
            set
            {
                this.componentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ComuterID
        {
            get
            {
                return this.comuterIDField;
            }
            set
            {
                this.comuterIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ComputerShopComputerComponents
    {

        private ComputerShopComputerComponentsMotherboard motherboardField;

        private ComputerShopComputerComponentsMemory memoryField;

        private ComputerShopComputerComponentsProcessor processorField;

        private ComputerShopComputerComponentsVideoCard videoCardField;

        private ComputerShopComputerComponentsHardDrive[] hardDrivesField;

        /// <remarks/>
        public ComputerShopComputerComponentsMotherboard Motherboard
        {
            get
            {
                return this.motherboardField;
            }
            set
            {
                this.motherboardField = value;
            }
        }

        /// <remarks/>
        public ComputerShopComputerComponentsMemory Memory
        {
            get
            {
                return this.memoryField;
            }
            set
            {
                this.memoryField = value;
            }
        }

        /// <remarks/>
        public ComputerShopComputerComponentsProcessor Processor
        {
            get
            {
                return this.processorField;
            }
            set
            {
                this.processorField = value;
            }
        }

        /// <remarks/>
        public ComputerShopComputerComponentsVideoCard VideoCard
        {
            get
            {
                return this.videoCardField;
            }
            set
            {
                this.videoCardField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("HardDrive", IsNullable = false)]
        public ComputerShopComputerComponentsHardDrive[] HardDrives
        {
            get
            {
                return this.hardDrivesField;
            }
            set
            {
                this.hardDrivesField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ComputerShopComputerComponentsMotherboard
    {

        private decimal priceField;

        private string manufacturerField;

        private string modelField;

        /// <remarks/>
        public decimal Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        public string Manufacturer
        {
            get
            {
                return this.manufacturerField;
            }
            set
            {
                this.manufacturerField = value;
            }
        }

        /// <remarks/>
        public string Model
        {
            get
            {
                return this.modelField;
            }
            set
            {
                this.modelField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ComputerShopComputerComponentsMemory
    {

        private decimal priceField;

        private string manufacturerField;

        private ushort capacityInGbField;

        /// <remarks/>
        public decimal Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        public string Manufacturer
        {
            get
            {
                return this.manufacturerField;
            }
            set
            {
                this.manufacturerField = value;
            }
        }

        /// <remarks/>
        public ushort CapacityInGb
        {
            get
            {
                return this.capacityInGbField;
            }
            set
            {
                this.capacityInGbField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ComputerShopComputerComponentsProcessor
    {

        private decimal priceField;

        private string manufacturerField;

        private string modelField;

        private ushort frequencyInMhzField;

        /// <remarks/>
        public decimal Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        public string Manufacturer
        {
            get
            {
                return this.manufacturerField;
            }
            set
            {
                this.manufacturerField = value;
            }
        }

        /// <remarks/>
        public string Model
        {
            get
            {
                return this.modelField;
            }
            set
            {
                this.modelField = value;
            }
        }

        /// <remarks/>
        public ushort FrequencyInMhz
        {
            get
            {
                return this.frequencyInMhzField;
            }
            set
            {
                this.frequencyInMhzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ComputerShopComputerComponentsVideoCard
    {

        private decimal priceField;

        private string manufacturerField;

        private string modelField;

        /// <remarks/>
        public decimal Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        public string Manufacturer
        {
            get
            {
                return this.manufacturerField;
            }
            set
            {
                this.manufacturerField = value;
            }
        }

        /// <remarks/>
        public string Model
        {
            get
            {
                return this.modelField;
            }
            set
            {
                this.modelField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ComputerShopComputerComponentsHardDrive
    {

        private ushort capacityField;

        private string manufacturerField;

        private string modelField;

        private decimal priceField;

        /// <remarks/>
        public ushort Capacity
        {
            get
            {
                return this.capacityField;
            }
            set
            {
                this.capacityField = value;
            }
        }

        /// <remarks/>
        public string Manufacturer
        {
            get
            {
                return this.manufacturerField;
            }
            set
            {
                this.manufacturerField = value;
            }
        }

        /// <remarks/>
        public string Model
        {
            get
            {
                return this.modelField;
            }
            set
            {
                this.modelField = value;
            }
        }

        /// <remarks/>
        public decimal Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }
    }
}
