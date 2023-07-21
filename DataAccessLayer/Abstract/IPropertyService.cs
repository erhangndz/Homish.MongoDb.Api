
using DtoLayer.DTOS.PropertyDtos;
using DtoLayer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPropertyService
    {
        Task<Response<List<ResultPropertyDto>>> GetAllAsync();
        Task<Response<ResultPropertyDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> CreateAsync(CreatePropertyDto createPropertyDto);
        Task<Response<NoContent>> UpdateAsync(UpdatePropertyDto updatePropertyDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
