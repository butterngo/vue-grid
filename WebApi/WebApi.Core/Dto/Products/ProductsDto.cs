namespace WebApi.Core.Dto
{
    using System;
    using System.Collections.Generic;

    public class ProductsDto
    {
        public ProductsDto()
        {
            OrderDetails = new HashSet<OrderDetailsDto>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual ICollection<OrderDetailsDto> OrderDetails { get; set; }
        public virtual CategoriesDto Category { get; set; }
        public virtual SuppliersDto Supplier { get; set; }
    }
}
