using FluentValidation.Attributes;

namespace KatlaSport.Services.OrderManagement
{
    [Validator(typeof(UpdateDeliveryRequestValidator))]
    public class UpdateDeliveryRequest
    {
        /// <summary>
        /// Gets or sets a Address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets a TelephoneNumber.
        /// </summary>
        public string TelephoneNumber { get; set; }

        public int? OrderId { get; set; }
    }
}
