using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Prestadito.Investment.Application.Dto.Financing.CreateFinancing;
using Prestadito.Investment.Application.Dto.Financing.DisableFinancing;
using Prestadito.Investment.Application.Dto.Financing.GetFinancingById;
using Prestadito.Investment.Application.Dto.Financing.UpdateFinancing;
using Prestadito.Investment.Application.Manager.Controller;
using Prestadito.Investment.Application.Manager.Interfaces;
using Prestadito.Investment.Application.Manager.Validators;

namespace Prestadito.Investment.Application.Manager.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetFinancingByIdRequest>, GetFinancingByIdValidator>();
            services.AddScoped<IValidator<CreateFinancingRequest>, CreateFinancingValidator>();
            services.AddScoped<IValidator<UpdateFinancingRequest>, UpdateFinancingValidator>();
            services.AddScoped<IValidator<DisableFinancingRequest>, DisableFinancingValidator>();
            services.AddScoped<IValidator<DeleteFinancingRequest>, DeleteFinancingValidator>();

            return services;
        }

        public static IServiceCollection AddInvestmentControllers(this IServiceCollection services)
        {
            services.AddScoped<IFinancingsController, FinancingsController>();
            return services;
        }
    }
}
