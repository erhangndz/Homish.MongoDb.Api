using DtoLayer.DTOS.CityDtos;
using DtoLayer.DTOS.MessageDtos;

namespace Homish.ApiConsume.Models
{
    public class UpdateMessageViewModel
    {
        public UpdateMessageDto Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
