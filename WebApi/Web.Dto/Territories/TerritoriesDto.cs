namespace WebApi.Dto
{
    using System.Collections.Generic;

    public class TerritoriesDto
    {
        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }
        public IEnumerable<EmployeeTerritoriesDto> EmployeeTerritories { get; set; }
        public RegionDto Region { get; set; }
    }
}
