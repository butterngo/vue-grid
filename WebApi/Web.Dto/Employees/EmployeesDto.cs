namespace WebApi.Dto
{
    using System;
    using System.Collections.Generic;

    public class EmployeesDto
    {               
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

        public IEnumerable<EmployeeTerritoriesDto> EmployeeTerritories { get; set; }
        public IEnumerable<OrdersDto> Orders { get; set; }
        public EmployeesDto ReportsToNavigation { get; set; }
        public IEnumerable<EmployeesDto> InverseReportsToNavigation { get; set; }
    }
}
