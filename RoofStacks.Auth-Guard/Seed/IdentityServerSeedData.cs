using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System.Linq;

namespace RoofStacks.Auth_Guard.Seed
{
    /// <summary>
    /// Provides methods for seeding IdentityServer configuration data.
    /// </summary>
    public static class IdentityServerSeedData
    {
        /// <summary>
        /// Seeds IdentityServer configuration data into the database.
        /// </summary>
        /// <param name="context">The ConfigurationDbContext instance.</param>
        public static void Seed(ConfigurationDbContext context)
        {
            // Seed Clients
            if (!context.Clients.Any())
            {
                // Adds each client from Config to the Clients table
                Config.GetClients().ToList().ForEach(x =>
                {
                    context.Clients.Add(x.ToEntity());
                });
            }

            // Seed ApiResources
            if (!context.ApiResources.Any())
            {
                // Adds each API resource from Config to the ApiResources table
                Config.GetApiResources().ToList().ForEach(x =>
                {
                    context.ApiResources.Add(x.ToEntity());
                });
            }

            // Seed ApiScopes
            if (!context.ApiScopes.Any())
            {
                // Adds each API scope from Config to the ApiScopes table
                Config.GetApiScopes().ToList().ForEach(x =>
                {
                    context.ApiScopes.Add(x.ToEntity());
                });
            }

            // Commit changes to the database
            context.SaveChanges();
        }
    }
}