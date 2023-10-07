using RoofStacks.CompanyAPI.Model;

namespace RoofStacks.CompanyAPI.Services
{
    public class CompanyService : ICompanyService
    {
        public static List<Company> _companies = new List<Company>
        {
            new Company { Id = 1, Name = "TechCorp", Address = "123 Tech St.", Industry = "Technology" },
            new Company { Id = 2, Name = "MediCare", Address = "456 Health Rd.", Industry = "Healthcare" },
            new Company { Id = 3, Name = "BuildWorks", Address = "789 Construct Ln.", Industry = "Construction" },
            new Company { Id = 4, Name = "EduLearn", Address = "101 Academy Blvd.", Industry = "Education" }
        };

        public List<Company> GetCompanys()
        {
            return _companies;
        }

        public Company GetCompanyById(int id)
        {
            return _companies.FirstOrDefault(e => e.Id == id);
        }

        public Company AddCompany(Company company)
        {
            var maxId = _companies.Any() ? _companies.Max(e => e.Id) : 0;
            company.Id = maxId + 1;
            _companies.Add(company);
            return company;
        }

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
