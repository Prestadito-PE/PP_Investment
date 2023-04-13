using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Prestadito.Investment.Application.Dto.Financing.CreateFinancing;
using Prestadito.Investment.Application.Dto.Financing.DisableFinancing;
using Prestadito.Investment.Application.Dto.Financing.GetFinancingById;
using Prestadito.Investment.Application.Dto.Financing.GetFinancingsActive;
using Prestadito.Investment.Application.Dto.Financing.UpdateFinancing;
using Prestadito.Investment.Application.Manager.Interfaces;
using Prestadito.Investment.Application.Manager.QueryBuilder;
using Prestadito.Investment.Application.Manager.Utilities;
using Prestadito.Investment.Domain.MainModule.Entities;
using Prestadito.Investment.Infrastructure.Data.Constants;
using Prestadito.Investment.Infrastructure.Data.Interface;
using Prestadito.Investment.Infrastructure.Data.Utilities;

namespace Prestadito.Investment.Application.Manager.Controller
{
    public class FinancingsController : IFinancingsController
    {
        private readonly IFinancingRepository _financingRepository;
        private readonly IMapper _mapper;

        public FinancingsController(IFinancingRepository financingRepository, IMapper mapper)
        {
            _financingRepository = financingRepository;
            _mapper = mapper;
        }

        public async ValueTask<IResult> CreateFinancing(CreateFinancingRequest request, string path)
        {
            ResponseModel<CreateFinancingResponse> responseModel;

            var entity = _mapper.Map<FinancingEntity>(request);

            await _financingRepository.InsertOneAsync(entity);
            if (string.IsNullOrEmpty(entity.Id))
            {
                responseModel = ResponseModel<CreateFinancingResponse>.GetResponse(ConstantMessages.Financings.USER_FAILED_TO_CREATE);
                return Results.UnprocessableEntity(responseModel);
            }

            responseModel = ResponseModel<CreateFinancingResponse>.GetResponse(_mapper.Map<CreateFinancingResponse>(entity));
            return Results.Created($"{path}/{responseModel.Item.StrId}", responseModel);
        }

        public async ValueTask<IResult> DisableFinancing(string id)
        {
            ResponseModel<DisableFinancingResponse> responseModel;

            var (filterDefinition, updateDefinition) = FinancingQueryBuilder.UpdateFinancingDisable(id);
            var entity = await _financingRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<DisableFinancingResponse>.GetResponse(ConstantMessages.Financings.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }
            entity.BlnActive = false;

            var isFinancingUpdated = await _financingRepository.UpdateOneAsync(filterDefinition, updateDefinition);
            if (!isFinancingUpdated)
            {
                responseModel = ResponseModel<DisableFinancingResponse>.GetResponse(ConstantMessages.Financings.USER_FAILED_TO_DISABLE);
                return Results.UnprocessableEntity(responseModel);
            }

            var mapperResponse = _mapper.Map<DisableFinancingResponse>(entity);
            responseModel = ResponseModel<DisableFinancingResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetActiveFinancings()
        {
            ResponseModel<GetFinancingsActiveResponse> responseModel;

            var filterDefinition = FinancingQueryBuilder.FindFinancingsActive();
            var entities = await _financingRepository.GetAsync(filterDefinition);

            var mapperResponse = _mapper.Map<List<GetFinancingsActiveResponse>>(entities.ToList());
            responseModel = ResponseModel<GetFinancingsActiveResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetAllFinancings()
        {
            ResponseModel<FinancingEntity> responseModel;

            var filterDefinition = FinancingQueryBuilder.FindAllFinancings();
            var entities = await _financingRepository.GetAsync(filterDefinition);

            responseModel = ResponseModel<FinancingEntity>.GetResponse(entities.ToList());
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetFinancingById(GetFinancingByIdRequest request)
        {
            ResponseModel<GetFinancingByIdResponse> responseModel;

            var filterDefinition = FinancingQueryBuilder.FindFinancingById(request.StrId);
            var entity = await _financingRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<GetFinancingByIdResponse>.GetResponse(ConstantMessages.Financings.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }

            var mapperResponse = _mapper.Map<GetFinancingByIdResponse>(entity);
            responseModel = ResponseModel<GetFinancingByIdResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }
        public async ValueTask<IResult> UpdateFinancing(UpdateFinancingRequest dto)
        {
            ResponseModel<UpdateFinancingResponse> responseModel;

            var filterDefinition = FinancingQueryBuilder.FindFinancingById(dto.StrId);
            var entity = await _financingRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<UpdateFinancingResponse>.GetResponse(ConstantMessages.Financings.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }

            entity.BlnActive = dto.BlnActive;
            entity.DteUpdatedAt = DateTime.Now;
            entity.StrUpdateFinancing = ConstantAPI.System.SYSTEM_USER;

            var updateDefinition = FinancingQueryBuilder.UpdateFinancing(entity);
            var isFinancingUpdated = await _financingRepository.UpdateOneAsync(filterDefinition, updateDefinition);
            if (!isFinancingUpdated)
            {
                responseModel = ResponseModel<UpdateFinancingResponse>.GetResponse(ConstantMessages.Financings.USER_FAILED_TO_DELETE);
                return Results.UnprocessableEntity(responseModel);
            }

            var mapperResponse = _mapper.Map<UpdateFinancingResponse>(entity);
            responseModel = ResponseModel<UpdateFinancingResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> DeleteFinancing(DeleteFinancingRequest request)
        {
            ResponseModel<DeleteFinancingResponse> responseModel;

            var filterDefinition = FinancingQueryBuilder.FindFinancingById(request.StrId);
            var entity = await _financingRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<DeleteFinancingResponse>.GetResponse(ConstantMessages.Financings.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }

            var isFinancingUpdated = await _financingRepository.DeleteOneAsync(filterDefinition);
            if (!isFinancingUpdated)
            {
                responseModel = ResponseModel<DeleteFinancingResponse>.GetResponse(ConstantMessages.Financings.USER_FAILED_TO_DELETE);
                return Results.UnprocessableEntity(responseModel);
            }

            var mapperResponse = _mapper.Map<DeleteFinancingResponse>(entity);
            responseModel = ResponseModel<DeleteFinancingResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }
    }
}
