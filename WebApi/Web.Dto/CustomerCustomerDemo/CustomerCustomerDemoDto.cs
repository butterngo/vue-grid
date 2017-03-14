namespace WebApi.Dto
{
    using System;
    using System.Collections.Generic;

    public class CustomerCustomerDemoDto
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public virtual CustomersDto Customer { get; set; }
        public virtual CustomerDemographicsDto CustomerType { get; set; }
    }
}
