namespace WebApi.Core.Dto
{
    using System;
    using System.Collections.Generic;

    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual OrdersDto Order { get; set; }
        public virtual ProductsDto Product { get; set; }
    }
}
