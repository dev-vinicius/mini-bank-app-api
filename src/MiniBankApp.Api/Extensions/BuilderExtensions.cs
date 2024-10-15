using MiniBankApp.Application.Configuration;

namespace MiniBankApp.Api.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.Database.ConnectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }
    }
}
