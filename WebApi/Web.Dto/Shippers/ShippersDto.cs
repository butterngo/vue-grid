namespace WebApi.Dto
{
    using System.Collections.Generic;

    public class ShippersDto
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<OrdersDto> Orders { get; set; }
    }
}
