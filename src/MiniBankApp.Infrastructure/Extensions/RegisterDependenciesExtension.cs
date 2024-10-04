using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MiniBankApp.Application.UseCases.Accounts.GetById;
using MiniBankApp.Application.UseCases.Accounts.Register;
using MiniBankApp.Infrastructure.DataAccess;
using MiniBankApp.Infrastructure.UseCases.Accounts.GetById;
using MiniBankApp.Infrastructure.UseCases.Accounts.Register;

namespace MiniBankApp.Infrastructure.Extensions
{
    public static class RegisterDependenciesExtension
    {
        public static void RegisterInfrastructureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MiniBankAppDbContext>();
            builder.Services.AddScoped<IGetAccountByIdRepository, GetAccountByIdRepository>();
            builder.Services.AddScoped<IRegisterAccountRepository, RegisterAccountRepository>();
        }
    }
}
