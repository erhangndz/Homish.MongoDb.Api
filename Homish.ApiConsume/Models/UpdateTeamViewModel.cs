using DtoLayer.DTOS.PropertyDtos;
using DtoLayer.DTOS.TeamDtos;

namespace Homish.ApiConsume.Models
{
    public class UpdateTeamViewModel
    {
        public UpdateTeamDto Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
