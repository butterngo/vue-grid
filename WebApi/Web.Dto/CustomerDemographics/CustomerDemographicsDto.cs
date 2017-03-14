namespace WebApi.Dto
{
    using System.Collections.Generic;

    public class CustomerDemographicsDto
    {
        public string CustomerTypeId { get; set; }

        public string CustomerDesc { get; set; }

        public IEnumerable<CustomerCustomerDemoDto> CustomerCustomerDemo { get; set; }
    }
}
