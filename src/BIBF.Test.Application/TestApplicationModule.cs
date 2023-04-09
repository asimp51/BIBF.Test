using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BIBF.Test.Authorization;

namespace BIBF.Test
{
    [DependsOn(
        typeof(TestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TestAuthorizationProvider>();
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
            Configuration.BackgroundJobs.IsJobExecutionEnabled = true;
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
