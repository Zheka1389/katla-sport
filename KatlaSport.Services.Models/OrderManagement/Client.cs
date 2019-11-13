namespace KatlaSport.Services.OrderManagement
{
    public class Client
    {
        /// <summary>
        /// Gets or sets a Client.
        /// </summary>
        public int ClientId { get; set; }

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

        ///// <summary>
        ///// Gets or sets a Employee.
        ///// </summary>
        //public virtual ICollection<Employee> Employees { get; set; }
    }
}
