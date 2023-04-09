using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BIBF.Test.Dtos;


namespace BIBF.Test.Authorization
{
    public interface IProductsAppService : IApplicationService 
    {
        Task<PagedResultDto<GetProductForViewDto>> GetAll(GetAllProductInput input);

        Task<GetProductForViewDto> GetProductForView(int id);

		Task<GetProductForEditOutput> GetProductForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditProductDto input);

		Task Delete(EntityDto input);


		
    }
}