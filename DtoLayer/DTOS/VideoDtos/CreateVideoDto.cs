using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOS.VideoDtos
{
    public class CreateVideoDto
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoURL { get; set; }
    }
}
