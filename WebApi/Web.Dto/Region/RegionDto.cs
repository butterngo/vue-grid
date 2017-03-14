namespace WebApi.Dto
{
    using System;
    using System.Collections.Generic;

    public class RegionDto
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public IEnumerable<TerritoriesDto> Territories { get; set; }
    }
}
