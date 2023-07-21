
using DtoLayer.DTOS.ServiceWedoDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IServiceWedoService
    {
        Task<Response<List<ResultServiceWedoDto>>> GetAllAsync();
        Task<Response<ResultServiceWedoDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreateServiceWedoDto createServiceWedoDto);
        Task<Response<NoContent>> UpdateAsync(UpdateServiceWedoDto updateServiceWedoDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
