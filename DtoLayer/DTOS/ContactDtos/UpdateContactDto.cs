using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOS.ContactDtos
{
    public class UpdateContactDto
    {
        public string ContactID { get; set; }
        public string OfficeName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Hours { get; set; }
        public string? Map { get; set; }
    }
}
