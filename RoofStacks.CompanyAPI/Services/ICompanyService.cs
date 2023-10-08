using RoofStacks.CompanyAPI.Model;
using System.Collections.Generic;

/// <summary>
/// Defines a contract for a service that provides various operations on companies.
/// This interface outlines methods for retrieving, adding, updating, and deleting companies.
/// </summary>
public interface ICompanyService
{
    /// <summary>
    /// Retrieves a list of all companies.
    /// </summary>
    /// <returns>A list of all companies.</returns>
    List<Company> GetCompanys();

    /// <summary>
    /// Retrieves a specific company by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier for the company.</param>
    /// <returns>The company with the given ID.</returns>
    Company GetCompanyById(int id);

    /// <summary>
    /// Adds a new company to the system.
    /// </summary>
    /// <param name="company">The company to add.</param>
    /// <returns>The added company with the new ID.</returns>
    Company AddCompany(Company company);

    /// <summary>
    /// Updates an existing company's details.
    /// </summary>
    /// <param name="company">The new details for the company.</param>
    void UpdateCompany(Company company);

    /// <summary>
    /// Deletes a specific company by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier for the company to delete.</param>
    void DeleteCompany(int id);
}