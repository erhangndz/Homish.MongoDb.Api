using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOS.PropertyDtos
{
    public class ResultPropertyDto
    {
        public string PropertyID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Bedroom { get; set; }
        public string Bathroom { get; set; }
        public string Square { get; set; }
    }
}
