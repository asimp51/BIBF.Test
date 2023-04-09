using Abp.Application.Services;
using BIBF.Test.MultiTenancy.Dto;

namespace BIBF.Test.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

