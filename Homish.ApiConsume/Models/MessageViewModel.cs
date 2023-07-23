
using DtoLayer.DTOS.MessageDtos;
using System.Collections.Generic;

namespace Homish.ApiConsume.Models
{
    public class MessageViewModel
    {
        public List<ResultMessageDto> Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
