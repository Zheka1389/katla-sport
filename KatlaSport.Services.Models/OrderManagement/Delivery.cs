namespace KatlaSport.Services.OrderManagement
{
    public class Delivery
    {
        ///// <summary>
        ///// Gets or sets a Delivery identifier.
        ///// </summary>
        //public int DeliveryId { get; set; }

        /// <summary>
        /// Gets or sets a Address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a TelephoneNumber.
        /// </summary>
        public string TelephoneNumber { get; set; }

        public int? OrderId { get; set; }

        //public Order Order { get; set; }
    }
}
