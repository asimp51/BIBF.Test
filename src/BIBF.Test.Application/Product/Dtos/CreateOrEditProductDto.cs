
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace BIBF.Test.Dtos
{
    public class CreateOrEditProductDto : AuditedEntityDto<int?>
    {

		public string Name { get; set; }



        public decimal Price { get; set; }
        public string Description { get; set; }



    }
}