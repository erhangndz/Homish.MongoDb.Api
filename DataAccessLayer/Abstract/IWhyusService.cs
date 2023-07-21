
using DtoLayer.DTOS.WhyusDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWhyusService
    {
        Task<Response<List<ResultWhyusDto>>> GetAllAsync();
        Task<Response<ResultWhyusDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateWhyusDto createWhyusDto);
        Task<Response<NoContent>> UpdateAsync(UpdateWhyusDto updateWhyusDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
