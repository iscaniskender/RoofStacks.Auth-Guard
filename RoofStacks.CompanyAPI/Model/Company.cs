namespace RoofStacks.CompanyAPI.Model
{
    /// <summary>
    /// Represents a company in the system. A company is an entity that has an ID, a name, an address, and belongs to a specific industry.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Gets or sets the unique identifier for the company.
        /// </summary>
        /// <value>The unique identifier for the company.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the company.
        /// </summary>
        /// <value>The address where the company is located.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the industry that the company belongs to.
        /// </summary>
        /// <value>The industry category of the company.</value>
        public string Industry { get; set; }
    }

}
