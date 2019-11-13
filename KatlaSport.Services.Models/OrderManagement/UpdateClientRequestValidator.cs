using FluentValidation;

namespace KatlaSport.Services.OrderManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateClientRequestValidator"/>
    /// </summary>
    public class UpdateClientRequestValidator : AbstractValidator<UpdateClientRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateClientRequestValidator"/> class.
        /// </summary>
        public UpdateClientRequestValidator()
        {
            RuleFor(r => r.FirstName).Length(4, 60);
            RuleFor(r => r.LastName).Length(4, 60);
            RuleFor(r => r.Address).Length(4, 60);
            RuleFor(r => r.TelephoneNumber).Length(4, 60);
            RuleFor(r => r.OrderId).GreaterThan(0);
        }
    }
}
