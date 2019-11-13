namespace KatlaSport.Services.OrderManagement
{
    using FluentValidation;

    /// <summary>
    /// Represents a validator for <see cref="UpdateOrderRequestValidator"/>
    /// </summary>
    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOrderRequestValidator"/> class.
        /// </summary>
        public UpdateOrderRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
        }
    }
}
