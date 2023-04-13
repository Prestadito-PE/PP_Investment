using FluentValidation;
using Prestadito.Investment.Application.Dto.Financing.CreateFinancing;
using Prestadito.Investment.Application.Dto.Financing.DisableFinancing;
using Prestadito.Investment.Application.Dto.Financing.GetFinancingById;
using Prestadito.Investment.Application.Dto.Financing.UpdateFinancing;
using Prestadito.Investment.Application.Manager.Interfaces;
using Prestadito.Investment.Infrastructure.Data.Constants;

namespace Prestadito.Investment.API.Endpoints
{
    public static class FinancingEndpoints
    {
        readonly static string collection = "financings";
        public static WebApplication UseFinancingEndpoints(this WebApplication app, string basePath)
        {
            string path = $"{basePath}/{collection}";

            app.MapPost(path,
                async (IValidator<CreateFinancingRequest> validator, CreateFinancingRequest dto, IFinancingsController controller) =>
                {
                    var validationResult = await validator.ValidateAsync(dto);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.CreateFinancing(dto, $"~{path}");
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapGet(path + "/all",
                async (IFinancingsController controller, HttpContext httpContext) =>
                {
                    return await controller.GetAllFinancings();
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapGet(path,
                async (IFinancingsController controller) =>
                {
                    return await controller.GetActiveFinancings();
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapGet(path + "/{id}",
                async (IValidator<GetFinancingByIdRequest> validator, string id, IFinancingsController controller) =>
                {
                    var request = new GetFinancingByIdRequest { StrId = id };
                    var validationResult = await validator.ValidateAsync(request);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.GetFinancingById(request);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapPut(path,
                async (IValidator<UpdateFinancingRequest> validator, UpdateFinancingRequest dto, IFinancingsController controller) =>
                {
                    var validationResult = await validator.ValidateAsync(dto);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.UpdateFinancing(dto);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapPut(path + "/disable/{id}",
                async (IValidator<DisableFinancingRequest> validator, string id, IFinancingsController controller) =>
                {
                    var request = new DisableFinancingRequest { StrId = id };
                    var validationResult = await validator.ValidateAsync(request);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.DisableFinancing(id);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapDelete(path + "/delete/{id}",
                async (IValidator<DeleteFinancingRequest> validator, string id, IFinancingsController controller) =>
                {
                    var request = new DeleteFinancingRequest { StrId = id };
                    var validationResult = await validator.ValidateAsync(request);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.DeleteFinancing(request);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            return app;
        }
    }
}
