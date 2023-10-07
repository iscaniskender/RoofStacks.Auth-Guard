using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;

namespace RoofStacks.Auth_Guard.Seed
{
    public static class IdentityServerSeedData
    {
        public static void Seed(ConfigurationDbContext context)
        {
            if(!context.Clients.Any())
            {
                Config.GetClients().ToList().ForEach(x =>
                {
                    context.Clients.Add(x.ToEntity());
                });
            }

            if (!context.ApiResources.Any())
            {
                Config.GetApiResources().ToList().ForEach(x =>
                {
                    context.ApiResources.Add(x.ToEntity());
                });
            }

            if (!context.ApiScopes.Any())
            {
                Config.GetApiScopes().ToList().ForEach(x =>
                {
                    context.ApiScopes.Add(x.ToEntity());
                });
            }

            context.SaveChanges();
        }
    }
}
