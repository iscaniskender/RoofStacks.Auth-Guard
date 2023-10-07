using IdentityServer4.Models;

namespace RoofStacks.Auth_Guard.Seed
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new("resource_CompanyAPI")
                {
                    Scopes = { "companyAPI.read", "companyAPI.write", "companyAPI.update", "companyAPI.delete" }
                },
                new("resource_EmployeeAPI")
                {
                    Scopes = { "employeeAPI.read", "employeeAPI.write", "employeeAPI.update", "employeeAPI.delete" }
                },
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new("companyAPI.read", "Company API for Read access"),
                new("companyAPI.write", "Company API for Write access"),
                new("companyAPI.delete", "Company API for delete access"),

                new("employeeAPI.read", "Employee API for Read access"),
                new("employeeAPI.write", "Employee API for Read access"),
                new("employeeAPI.delete", "Employee API for Delete access")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "CompanyAPP",
                    ClientName = "CompanyAPP",
                    ClientSecrets = new[]
                    {
                        new Secret("CompanyAPISecret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "companyAPI.read", "companyAPI.write", "companyAPI.delete", "employeeAPI.read" },
                },

                new Client
                {
                    ClientId = "EmployeeAPP",
                    ClientName = "EmployeeAPP",
                    ClientSecrets = new[]
                    {
                        new Secret("EmployeeAPISecret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "employeeAPI.read", "employeeAPI.write", "employeeAPI.delete", "companyAPI.read" }
                
                }
            };
        }
    }
}
