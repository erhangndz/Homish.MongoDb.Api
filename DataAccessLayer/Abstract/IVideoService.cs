
using DtoLayer.DTOS.VideoDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IVideoService
    {
        Task<Response<List<ResultVideoDto>>> GetAllAsync();
        Task<Response<ResultVideoDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateVideoDto createVideoDto);
        Task<Response<NoContent>> UpdateAsync(UpdateVideoDto updateVideoDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
