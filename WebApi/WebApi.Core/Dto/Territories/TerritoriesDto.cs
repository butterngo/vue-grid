namespace WebApi.Core.Dto
{
    using System;
    using System.Collections.Generic;

    public class TerritoriesDto
    {
        public TerritoriesDto()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritoriesDto>();
        }

        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public virtual ICollection<EmployeeTerritoriesDto> EmployeeTerritories { get; set; }
        public virtual RegionDto Region { get; set; }
    }
}
