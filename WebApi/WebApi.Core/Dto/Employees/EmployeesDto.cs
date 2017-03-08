namespace WebApi.Core.Dto
{
    using System;
    using System.Collections.Generic;

    public class EmployeesDto
    {               
        public EmployeesDto()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritoriesDto>();
            Orders = new HashSet<OrdersDto>();
        }

        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<EmployeeTerritoriesDto> EmployeeTerritories { get; set; }
        public virtual ICollection<OrdersDto> Orders { get; set; }
        public virtual EmployeesDto ReportsToNavigation { get; set; }
        public virtual ICollection<EmployeesDto> InverseReportsToNavigation { get; set; }
    }
}
