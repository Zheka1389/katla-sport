using FluentValidation;

namespace KatlaSport.Services.OrderManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateDeliveryRequestValidator"/>
    /// </summary>
    public class UpdateDeliveryRequestValidator : AbstractValidator<UpdateDeliveryRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateDeliveryRequestValidator"/> class.
        /// </summary>
        public UpdateDeliveryRequestValidator()
        {
            RuleFor(r => r.Address).Length(4, 60);
            RuleFor(r => r.TelephoneNumber).Length(4, 60);
            RuleFor(r => r.OrderId).GreaterThan(0);
        }
    }
}
