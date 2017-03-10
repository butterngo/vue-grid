namespace WebApi.Core.Dto
{
    using System;
    using System.Collections.Generic;

    public class RegionDto
    {
        public RegionDto()
        {
            Territories = new HashSet<TerritoriesDto>();
        }

        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<TerritoriesDto> Territories { get; set; }
    }
}
