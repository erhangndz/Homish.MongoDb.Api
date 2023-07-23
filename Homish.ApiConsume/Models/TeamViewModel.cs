using DtoLayer.DTOS.AboutDtos;
using DtoLayer.DTOS.TeamDtos;
using System.Collections.Generic;

namespace Homish.ApiConsume.Models
{
    public class TeamViewModel
    {
        public List<ResultTeamDto> Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public object Errors { get; set; }
    }
}
