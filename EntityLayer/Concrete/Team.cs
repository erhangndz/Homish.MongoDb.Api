using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TeamID { get; set; }
        public string Image { get; set; }
        public string NameSurname { get; set; }
        public string JobTitle { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
    }
}
