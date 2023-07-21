
using DtoLayer.DTOS.BannerDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBannerService
    {
        Task<Response<List<ResultBannerDto>>> GetAllAsync();
        Task<Response<ResultBannerDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateBannerDto createBannerDto);
        Task<Response<NoContent>> UpdateAsync(UpdateBannerDto updateBannerDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
