using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOS.BannerDtos
{
    public class ResultBannerDto
    {
        
        public string BannerID { get; set; }
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
    }
}
