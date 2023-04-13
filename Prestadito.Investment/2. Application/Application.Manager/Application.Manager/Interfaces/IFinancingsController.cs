using Microsoft.AspNetCore.Http;
using Prestadito.Investment.Application.Dto.Financing.CreateFinancing;
using Prestadito.Investment.Application.Dto.Financing.GetFinancingById;
using Prestadito.Investment.Application.Dto.Financing.UpdateFinancing;

namespace Prestadito.Investment.Application.Manager.Interfaces
{
    public interface IFinancingsController
    {
        ValueTask<IResult> CreateFinancing(CreateFinancingRequest request, string path);
        ValueTask<IResult> GetAllFinancings();
        ValueTask<IResult> GetActiveFinancings();
        ValueTask<IResult> GetFinancingById(GetFinancingByIdRequest request);
        ValueTask<IResult> UpdateFinancing(UpdateFinancingRequest request);
        ValueTask<IResult> DisableFinancing(string id);
        ValueTask<IResult> DeleteFinancing(DeleteFinancingRequest request);
    }
}
