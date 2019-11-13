using FluentValidation.Attributes;

namespace KatlaSport.Services.OrderManagement
{
    [Validator(typeof(UpdateClientRequestValidator))]
    public class UpdateClientRequest
    {
        /// <summary>
        /// Gets or sets a FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a LastName.
        /// </summary>
        public string LastName { get; set; }

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
