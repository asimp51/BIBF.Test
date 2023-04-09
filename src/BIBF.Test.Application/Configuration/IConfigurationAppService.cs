using System.Threading.Tasks;
using BIBF.Test.Configuration.Dto;

namespace BIBF.Test.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
