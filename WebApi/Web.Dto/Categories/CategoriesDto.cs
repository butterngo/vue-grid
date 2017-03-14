namespace WebApi.Dto
{
    using System;
    using System.Collections.Generic;

    public class CategoriesDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public IEnumerable<ProductsDto> Products { get; set; }
    }
}
