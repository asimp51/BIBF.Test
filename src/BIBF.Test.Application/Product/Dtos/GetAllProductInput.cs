using Abp.Application.Services.Dto;
using System;

namespace BIBF.Test.Dtos
{
    public class GetAllProductInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; } 
    }
}