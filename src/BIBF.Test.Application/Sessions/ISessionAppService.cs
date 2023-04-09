using System.Threading.Tasks;
using Abp.Application.Services;
using BIBF.Test.Sessions.Dto;

namespace BIBF.Test.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
