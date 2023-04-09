

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using BIBF.Test.Dtos;
using Abp.Application.Services.Dto;
using BIBF.Test.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using BIBF.Test.Authorization;
using BIBF.Test;

namespace FSC.CarRental
{
	[AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductsAppService : TestAppServiceBase, IProductsAppService
    {
		 private readonly IRepository<Product> _productRepository;
		 

		  public ProductsAppService(IRepository<Product> productRepository) 
		  {
			_productRepository = productRepository;
			
		  }

		 public async Task<PagedResultDto<GetProductForViewDto>> GetAll(GetAllProductInput input)
         {

			var filteredProducts = _productRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => e.Name == input.Name);

            var pagedAndFilteredProducts = filteredProducts
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var Products = from o in pagedAndFilteredProducts
                         select new GetProductForViewDto() {
							Product = new ProductDto
							{
                                Name = o.Name,
                                Description = o.Description,
                                Price = o.Price,
                                Id = o.Id
							}
						};

            var totalCount = await filteredProducts.CountAsync();

            return new PagedResultDto<GetProductForViewDto>(
                totalCount,
                await Products.ToListAsync()
            );
         }
		 
		 public async Task<GetProductForViewDto> GetProductForView(int id)
         {
            var Product = await _productRepository.GetAsync(id);

            var output = new GetProductForViewDto { Product = ObjectMapper.Map<ProductDto>(Product) };
			
            return output;
         }
		 
		 [AbpAuthorize(PermissionNames.Pages_Products_Edit)]
		 public async Task<GetProductForEditOutput> GetProductForEdit(EntityDto input)
         {
            var Product = await _productRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetProductForEditOutput {Product = ObjectMapper.Map<CreateOrEditProductDto>(Product)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditProductDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(PermissionNames.Pages_Products_Create)]
		 protected virtual async Task Create(CreateOrEditProductDto input)
         {
            var Product = ObjectMapper.Map<Product>(input);

			
			if (AbpSession.TenantId != null)
			{
				Product.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _productRepository.InsertAsync(Product);
         }

		 [AbpAuthorize(PermissionNames.Pages_Products_Edit)]
		 protected virtual async Task Update(CreateOrEditProductDto input)
         {
            var Product = await _productRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, Product);
         }

		 [AbpAuthorize(PermissionNames.Pages_Products_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _productRepository.DeleteAsync(input.Id);
         } 

    }
}