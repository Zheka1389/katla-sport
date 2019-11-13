namespace KatlaSport.DataAccess.OrderCatalogue
{
    public class Employee
    {
        /// <summary>
        /// Gets or sets a Employee.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets a FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a Position.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets a Department.
        /// </summary>
        public string Department { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
