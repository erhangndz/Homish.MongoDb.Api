using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOS.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public string TestimonialID { get; set; }
        public string NameSurname { get; set; }
        public string City { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
    }
}
