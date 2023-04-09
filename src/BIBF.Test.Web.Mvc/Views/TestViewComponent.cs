using Abp.AspNetCore.Mvc.ViewComponents;

namespace BIBF.Test.Web.Views
{
    public abstract class TestViewComponent : AbpViewComponent
    {
        protected TestViewComponent()
        {
            LocalizationSourceName = TestConsts.LocalizationSourceName;
        }
    }
}
