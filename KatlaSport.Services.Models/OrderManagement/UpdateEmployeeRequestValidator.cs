using FluentValidation;

namespace KatlaSport.Services.OrderManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateEployeeRequestValidator"/>
    /// </summary>
    public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEmployeeRequestValidator"/> class.
        /// </summary>
        public UpdateEmployeeRequestValidator()
        {
            RuleFor(r => r.FirstName).Length(4, 60);
            RuleFor(r => r.LastName).Length(4, 60);
            RuleFor(r => r.Position).Length(4, 60);
            RuleFor(r => r.Department).Length(4, 60);
            RuleFor(r => r.ClientId).GreaterThan(0);
        }
    }
}
