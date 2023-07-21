using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOS.CityDtos
{
    public class CreateCityDto
    {
        
        public string CityName { get; set; }
        public string Description { get; set; }
        public string PropCount { get; set; }
    }
}
