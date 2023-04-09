using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BIBF.Test.MultiTenancy;

namespace BIBF.Test.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
