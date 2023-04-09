using BIBF.Test.Dtos;

using Abp.Extensions;

namespace BIBF.Test.Web.Models.Products
{
    public class CreateOrEditProductViewModel
    {
       public CreateOrEditProductDto Product { get; set; }


        public string CreatorName { get; set; }
        public string ModifierName { get; set; }
        public bool IsEditMode => Product.Id.HasValue;
    }
}