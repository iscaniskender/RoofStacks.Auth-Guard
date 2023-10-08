using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoofStacks.CompanyAPI.Helper;
using RoofStacks.CompanyAPI.Model;
using RoofStacks.CompanyAPI.Services;

namespace RoofStacks.CompanyAPI.Controllers
{
    /// <summary>
    /// This controller provides a comprehensive API for managing companies. 
    /// It includes functionalities to get, add, update, and delete companies.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        /// <summary>
        /// Constructs the CompaniesController with a company service implementation.
        /// </summary>
        /// <param name="companyService">A service that provides methods to interact with company data.</param>
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        /// <summary>
        /// Retrieves the list of all companies in the system. 
        /// Requires the user to have 'Read' permission.
        /// </summary>
        /// <returns>A list of all companies as IActionResult.</returns>
        [HttpGet]
        [Authorize(Policy = AuthorizePolicys.Read)]
        public IActionResult Get()
        {
            var companies = _companyService.GetCompanys();
            return Ok(companies);
        }

        /// <summary>
        /// Retrieves a specific company by its unique identifier. 
        /// Requires the user to have 'Read' permission.
        /// </summary>
        /// <param name="id">The unique identifier for the company.</param>
        /// <returns>The company details as IActionResult.</returns>
        [HttpGet("{id}")]
        [Authorize(Policy = AuthorizePolicys.Read)]
        public IActionResult Get(int id)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
                return NotFound("The company with the specified ID was not found.");

            return Ok(company);
        }

        /// <summary>
        /// Adds a new company to the system. 
        /// Requires the user to have 'Write' permission.
        /// </summary>
        /// <param name="company">The new company details.</param>
        /// <returns>The created company as IActionResult.</returns>
        [HttpPost]
        [Authorize(Policy = AuthorizePolicys.Write)]
        public IActionResult Post([FromBody] Company company)
        {
            var newCompany = _companyService.AddCompany(company);
            return CreatedAtAction(nameof(Get), new { id = newCompany.Id }, newCompany);
        }

        /// <summary>
        /// Updates an existing company's details in the system. 
        /// Requires the user to have 'Write' permission.
        /// </summary>
        /// <param name="id">The unique identifier for the company to update.</param>
        /// <param name="updatedCompany">The new details for the company.</param>
        /// <returns>No content if the update was successful, otherwise NotFound.</returns>
        [HttpPut("{id}")]
        [Authorize(Policy = AuthorizePolicys.Write)]
        public IActionResult Put(int id, [FromBody] Company updatedCompany)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
                return NotFound("The company with the specified ID was not found.");

            _companyService.UpdateCompany(updatedCompany);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific company from the system by its unique identifier. 
        /// Requires the user to have 'Delete' permission.
        /// </summary>
        /// <param name="id">The unique identifier for the company to delete.</param>
        /// <returns>No content if the deletion was successful, otherwise NotFound.</returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = AuthorizePolicys.Delete)]
        public IActionResult Delete(int id)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
                return NotFound("The company with the specified ID was not found.");

            _companyService.DeleteCompany(id);
            return NoContent();
        }
    }
}
