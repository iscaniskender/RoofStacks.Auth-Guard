using RoofStacks.CompanyAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace RoofStacks.CompanyAPI.Services
{
    /// <summary>
    /// Implements the <see cref="ICompanyService"/> interface to provide methods that operate on companies.
    /// This class uses an in-memory list to store company data.
    /// </summary>
    public class CompanyService : ICompanyService
    {
        /// <summary>
        /// In-memory storage of companies.
        /// </summary>
        public static List<Company> _companies = new List<Company>
        {
            new Company { Id = 1, Name = "TechCorp", Address = "123 Tech St.", Industry = "Technology" },
            new Company { Id = 2, Name = "MediCare", Address = "456 Health Rd.", Industry = "Healthcare" },
            new Company { Id = 3, Name = "BuildWorks", Address = "789 Construct Ln.", Industry = "Construction" },
            new Company { Id = 4, Name = "EduLearn", Address = "101 Academy Blvd.", Industry = "Education" }
        };

        /// <summary>
        /// Retrieves all companies.
        /// </summary>
        /// <returns>A list of all companies.</returns>
        public List<Company> GetCompanys()
        {
            return _companies;
        }

        /// <summary>
        /// Retrieves a company by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the company.</param>
        /// <returns>The company with the given ID.</returns>
        public Company GetCompanyById(int id)
        {
            return _companies.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Adds a new company.
        /// </summary>
        /// <param name="company">The company to add.</param>
        /// <returns>The added company with the new ID.</returns>
        public Company AddCompany(Company company)
        {
            var maxId = _companies.Any() ? _companies.Max(e => e.Id) : 0;
            company.Id = maxId + 1;
            _companies.Add(company);
            return company;
        }

        /// <summary>
        /// Updates an existing company.
        /// </summary>
        /// <param name="updatedCompany">The new details for the company.</param>
        public void UpdateCompany(Company updatedCompany)
        {
            var existingCompany = _companies.FirstOrDefault(e => e.Id == updatedCompany.Id);
            if (existingCompany != null)
            {
                existingCompany.Address = updatedCompany.Address;
                existingCompany.Industry = updatedCompany.Industry;
                existingCompany.Name = updatedCompany.Name;
            }
        }

        /// <summary>
        /// Deletes a company by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the company to delete.</param>
        public void DeleteCompany(int id)
        {
            var company = _companies.FirstOrDefault(e => e.Id == id);
            if (company != null)
            {
                _companies.Remove(company);
            }
        }
    }
}
