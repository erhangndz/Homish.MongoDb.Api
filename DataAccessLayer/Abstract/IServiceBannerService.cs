using DtoLayer.DTOS.MessageDtos;
using DtoLayer.DTOS.ServiceBannerDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IServiceBannerService
    {
        Task<Response<List<ResultServiceBannerDto>>> GetAllAsync();
        Task<Response<ResultServiceBannerDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateServiceBannerDto createServiceBannerDto);
        Task<Response<NoContent>> UpdateAsync(UpdateServiceBannerDto updateServiceBannerDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
