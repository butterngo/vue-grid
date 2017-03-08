namespace WebApi.Core.Dto
{
    using System;
    using System.Collections.Generic;

    public class ShippersDto
    {
        public ShippersDto()
        {
            Orders = new HashSet<OrdersDto>();
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<OrdersDto> Orders { get; set; }
    }
}
