﻿namespace WebApi.Core.Dto
{
    using System;
    using System.Collections.Generic;

    public class CategoriesDto
    {
        public CategoriesDto()
        {
            Products = new HashSet<ProductsDto>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<ProductsDto> Products { get; set; }
    }
}
