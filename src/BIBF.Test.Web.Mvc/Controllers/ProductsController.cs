using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using BIBF.Test.Web.Controllers;
using BIBF.Test.Authorization;
using BIBF.Test.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using BIBF.Test.Controllers;
using BIBF.Test.Web.Models.Products;
using BIBF.Test.Users;

namespace BIBF.Test.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Products)]
    public class ProductsController : TestControllerBase
    {
        private readonly IProductsAppService _ProductsAppService;
		private readonly IUserAppService _userAppService;

		public ProductsController(IUserAppService userAppService,IProductsAppService ProductsAppService)
        {
            _ProductsAppService = ProductsAppService;
			_userAppService = userAppService;

		}

        public ActionResult Index()
        {
            var model = new ProductsViewModel
			{
				FilterText = ""
			};

            return View(model);
        } 
       
[AbpMvcAuthorize(PermissionNames.Pages_Products_Create, PermissionNames.Pages_Products_Edit)]
			public async Task<ActionResult> CreateOrEdit(int? id)
			{
				GetProductForEditOutput getProductForEditOutput;

				if (id.HasValue){
					getProductForEditOutput = await _ProductsAppService.GetProductForEdit(new EntityDto { Id = (int) id });
				}
				else {
					getProductForEditOutput = new GetProductForEditOutput{
						Product = new CreateOrEditProductDto()
					};
				}

				var viewModel = new CreateOrEditProductViewModel()
				{
					Product = getProductForEditOutput.Product,
				//	CreatorName = (getProductForEditOutput.Product.CreatorUserId != null) ? _userAppService.GetAsync(new EntityDto<long>(getProductForEditOutput.Product.CreatorUserId.Value)).Result.FullName : "",
				//	ModifierName = (getProductForEditOutput.Product.LastModifierUserId != null) ? _userAppService.GetAsync(new EntityDto<long>(getProductForEditOutput.Product.LastModifierUserId.Value)).Result.FullName : ""
				};

				return View(viewModel);
			}
			

        public async Task<ActionResult> ViewProduct(int id)
        {
			var getProductForViewDto = await _ProductsAppService.GetProductForView(id);

            var model = new ProductViewModel()
            {
                Product = getProductForViewDto.Product
            };

            return View(model);
        }


    }
}