
using DtoLayer.DTOS.SubscribeDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISubscribeService
    {
        Task<Response<List<ResultSubscribeDto>>> GetAllAsync();
        Task<Response<ResultSubscribeDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateSubscribeDto createSubscribeDto);
        Task<Response<NoContent>> UpdateAsync(UpdateSubscribeDto updateSubscribeDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
