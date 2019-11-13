using FluentValidation.Attributes;

namespace KatlaSport.Services.OrderManagement
{
    [Validator(typeof(UpdateOrderRequestValidator))]
    public class UpdateOrderRequest
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
        /// Gets or sets a Client.
        /// </summary>
        //public virtual Client Clients { get; set; }

        ///// <summary>
        ///// Gets or sets a Delivery.
        ///// </summary>
        //public virtual Delivery Deliveries { get; set; }
    }
}
