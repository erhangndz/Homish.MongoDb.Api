
using DtoLayer.DTOS.TeamDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITeamService
    {
        Task<Response<List<ResultTeamDto>>> GetAllAsync();
        Task<Response<ResultTeamDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateTeamDto createTeamDto);
        Task<Response<NoContent>> UpdateAsync(UpdateTeamDto updateTeamDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
