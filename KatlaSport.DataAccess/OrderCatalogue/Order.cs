using System;
using System.Collections.Generic;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    public class Order
    {
        /// <summary>
        /// Gets or sets a Order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets a hive name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the Order was accommodation.
        /// </summary>
        public DateTime DateAccommodation { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the Order was destination.
        /// </summary>
        public DateTime DateDestination { get; set; }

        /// <summary>
        /// Gets or sets a timestamp when the Order was execution.
        /// </summary>
        public DateTime DateExecution { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a hive is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        //public int? ClientId { get; set; }

        /// <summary>
        /// Gets or sets a Client.
        /// </summary>
        public virtual ICollection<Client> Clients { get; set; }

        //public int? DeliveryId { get; set; }

        /// <summary>
        /// Gets or sets a Delivery.
        /// </summary>
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
