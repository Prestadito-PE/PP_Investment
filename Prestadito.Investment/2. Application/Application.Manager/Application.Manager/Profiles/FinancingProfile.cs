using AutoMapper;
using Prestadito.Investment.Application.Dto.Financing.CreateFinancing;
using Prestadito.Investment.Application.Dto.Financing.DisableFinancing;
using Prestadito.Investment.Application.Dto.Financing.GetFinancingById;
using Prestadito.Investment.Application.Dto.Financing.GetFinancingsActive;
using Prestadito.Investment.Application.Dto.Financing.UpdateFinancing;
using Prestadito.Investment.Domain.MainModule.Entities;
using Prestadito.Investment.Infrastructure.Data.Constants;
using Prestadito.Investment.Infrastructure.Data.Utilities;

namespace Prestadito.Investment.Application.Manager.Profiles
{
    public class FinancingProfile : Profile
    {
        public FinancingProfile()
        {
            CreateMap<CreateFinancingRequest, FinancingEntity>()
                .ForMember(dest => dest.BlnActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.StrCreateUser, opt => opt.MapFrom(src => ConstantAPI.System.SYSTEM_USER));

            CreateMap<FinancingEntity, CreateFinancingResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<FinancingEntity, GetFinancingByIdResponse>();

            CreateMap<UpdateFinancingRequest, FinancingEntity>();

            CreateMap<FinancingEntity, UpdateFinancingResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<FinancingEntity, DisableFinancingResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<FinancingEntity, DeleteFinancingResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<FinancingEntity, GetFinancingsActiveResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
