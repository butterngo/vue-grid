namespace WebApi.Dto
{
    using System;
    using System.Collections.Generic;

    public class EmployeeTerritoriesDto
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public EmployeesDto Employee { get; set; }
        public TerritoriesDto Territory { get; set; }
    }
}
