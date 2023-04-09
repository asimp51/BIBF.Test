using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace BIBF.Test
{
	[Table("Products")]
    public class Product : FullAuditedEntity , IMayHaveTenant
    {
			public int? TenantId { get; set; }


        public required string Name { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; } 


    }
}