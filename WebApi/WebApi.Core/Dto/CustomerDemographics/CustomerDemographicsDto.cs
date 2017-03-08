namespace WebApi.Core.Dto
{
    using System;
    using System.Collections.Generic;

    public class CustomerDemographicsDto
    {
        public CustomerDemographicsDto()
        {
            CustomerCustomerDemo = new HashSet<CustomerCustomerDemoDto>();
        }

        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

        public virtual ICollection<CustomerCustomerDemoDto> CustomerCustomerDemo { get; set; }
    }
}
