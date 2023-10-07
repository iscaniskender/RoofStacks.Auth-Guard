using RoofStacks.CompanyAPI.Model;

namespace RoofStacks.CompanyAPI.Services
{
    public interface ICompanyService
    {
        List<Company> GetCompanys();
        Company GetCompanyById(int id);
        Company AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int id);
    }
}
