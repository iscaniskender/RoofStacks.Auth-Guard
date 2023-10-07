using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoofStacks.CompanyAPI.Model;
using RoofStacks.CompanyAPI.Services;

namespace RoofStacks.CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/companies
        [HttpGet]

        [Authorize(Policy = "Read")]
        public IActionResult Get()
        {
            var companies = _companyService.GetCompanys();
            return Ok(companies);
        }

        // GET: api/companies/1
        [HttpGet("{id}")]

        [Authorize(Policy = "Read")]
        public IActionResult Get(int id)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        // POST: api/companies
        [HttpPost]
        [Authorize(Policy = "Write")]
        public IActionResult Post([FromBody] Company company)
        {
            var newCompany = _companyService.AddCompany(company);
            return CreatedAtAction(nameof(Get), new { id = newCompany.Id }, newCompany);
        }

        // PUT: api/companies/1
        [HttpPut("{id}")]

        [Authorize(Policy = "Write")]
        public IActionResult Put(int id, [FromBody] Company updatedCompany)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
                return NotFound();

            _companyService.UpdateCompany(updatedCompany);
            return NoContent();
        }

        // DELETE: api/companies/1
        [HttpDelete("{id}")]

        [Authorize(Policy = "Delete")]
        public IActionResult Delete(int id)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
                return NotFound();

            _companyService.DeleteCompany(id);
            return NoContent();
        }
    }
}
