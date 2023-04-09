using Abp.Application.Services.Dto;

namespace BIBF.Test.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

