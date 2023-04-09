using System.Threading.Tasks;
using Abp.Application.Services;
using BIBF.Test.Authorization.Accounts.Dto;

namespace BIBF.Test.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
