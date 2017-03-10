namespace WebApi.Core.Dto
{
    using System;
    using System.Collections.Generic;

    public class EmployeeTerritoriesDto
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public virtual EmployeesDto Employee { get; set; }
        public virtual TerritoriesDto Territory { get; set; }
    }
}
