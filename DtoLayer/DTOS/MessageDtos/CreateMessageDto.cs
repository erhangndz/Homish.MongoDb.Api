using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOS.MessageDtos
{
    public class CreateMessageDto
    {
        
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string MessageContent { get; set; }
    }
}
