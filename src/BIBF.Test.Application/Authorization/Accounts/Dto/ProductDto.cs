
using System;
using Abp.Application.Services.Dto;

namespace BIBF.Test.Dtos
{
    public class ProductDto : EntityDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }


    }
}