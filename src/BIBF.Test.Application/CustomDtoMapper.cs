using  BIBF.Test.Dtos;
using  BIBF.Test;
using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.EntityHistory;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using Abp.UI.Inputs;
using Abp.Webhooks;
using AutoMapper;
using BIBF.Test.Authorization.Accounts.Dto;

using BIBF.Test.Authorization.Roles;
using BIBF.Test.Authorization.Users;

using BIBF.Test.MultiTenancy;
using BIBF.Test.MultiTenancy.Dto;


using BIBF.Test.Sessions.Dto;

namespace BIBF.Test
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
         
           
            configuration.CreateMap<CreateOrEditProductDto, Product>().ReverseMap();
            configuration.CreateMap<ProductDto, Product>().ReverseMap();
           


            /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */
        }
    }
}
